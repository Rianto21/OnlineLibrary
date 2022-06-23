using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineLibrary.Interfaces;
using OnlineLibrary.Models;

namespace OnlineLibrary.Data
{
    public class BooksDBContext : IBooks
    {
        public readonly IMongoDatabase _db;
        public BooksDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(connectionString: "mongodb+srv://Oryto21:M1475963@cluster0.ar1x3.mongodb.net/test");
            _db = client.GetDatabase("online_library");

        }
        public IMongoCollection<Books> BooksCollection => _db.GetCollection<Books>("books");

        public IEnumerable<Books> GetAllBooks()
        {
            return BooksCollection.Find(a => true).ToList();
        }

        public Books GetBookDetails(string judul)
        {
            var Book = BooksCollection.Find(b => b.Judul == judul).FirstOrDefault();
            return Book;
        }

        public void create(Books book)
        {
            BooksCollection.InsertOne(book);
        }

        public void update(string id, Books book)
        {
            var Filter = Builders<Books>.Filter.Eq( c => c._id, id);
            var Update = Builders<Books>.Update
                .Set("Judul", book.Judul)
                .Set("Penulis", book.Penulis)
                .Set("Kategori", book.Kategori)
                .Set("TanggalTerbit", book.TanggalTerbit)
                .Set("Judul", book.Judul)
                .Set("Penerbit", book.Penerbit);
            BooksCollection.UpdateOne(Filter, Update);
        }

        public void delete(string id)
        {
            var Filter = Builders<Books>.Filter.Eq( c => c._id, id);
            BooksCollection.DeleteOne(Filter);
        }

        
    }
}
