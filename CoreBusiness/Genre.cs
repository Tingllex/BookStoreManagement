using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Note { get; set; }

        public List<Book> Books { get; set; }
    }
}
