using NUnit.Framework;
using Plugins.DataStore.SQLdatabase;

namespace Plugins.DataStore.SQLdatabaseTest
{
    [TestFixture]
    public class BookRepositoryTest
    {
        //private readonly DatabaseContext dbContext;
        //private BookRepository bookRepo;
        [SetUp]
        public void Setup()
        {
            //bookRepo = new BookRepository(dbContext);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}