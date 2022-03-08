using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQLdatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases;
using UseCases.DataStorePluginInterfaces;

namespace ASPMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
                );
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", u => u.RequireClaim("Position", "Admin"));
                options.AddPolicy("EmployeeOnly", u => u.RequireClaim("Position", "Employee"));
            });


            //SQL
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            //in memory data
            //services.AddScoped<IGenreRepository, GenreInMemoryRepository>();
            //services.AddScoped<IBookRepository, BookInMemoryRepository>();
            //services.AddScoped<ITransactionsRepository, TransactionInMemoryRepository>();

            //Genres
            services.AddTransient<IViewGenresUseCase, ViewGenresUseCase>(); //UseCases + Repo
            services.AddTransient<IAddGenreUseCase, AddGenreUseCase>(); //same
            services.AddTransient<IEditGenreUseCase, EditGenreUseCase>(); //same
            services.AddTransient<IGetGenreByIdUseCase, GetGenreByIdUseCase>(); //same
            services.AddTransient<IDeleteGenreUseCase, DeleteGenreUseCase>(); //same

            //Books
            services.AddTransient<IViewBooksUseCase, ViewBooksUseCase>(); //UseCases + Repo
            services.AddTransient<IAddBookUseCase, AddBookUseCase>(); //same
            services.AddTransient<IEditBookUseCase, EditBookUseCase>(); //same
            services.AddTransient<IGetBookByIdUseCase, GetBookByIdUseCase>(); //same
            services.AddTransient<IDeleteBookUseCase, DeleteBookUseCase>(); //same

            services.AddTransient<IViewBooksByGenreId, ViewBooksByGenreId>();
            services.AddTransient<ISellBookUseCase, SellBookUseCase>();

            //Transactions
            services.AddTransient<ITransactionsUseCase, TransactionsUseCase>();
            services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
