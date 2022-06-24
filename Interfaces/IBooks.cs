using MongoDB.Bson;
using MongoDB.Driver;
using OnlineLibrary.Models;

namespace OnlineLibrary.Interfaces
{
    public interface IBooks
    {
        IMongoCollection<Books> BooksCollection { get; }
        IEnumerable<Books> GetAllBooks();
        Books GetBookDetails(string id);
        void create(Books book);
        void update(string id, Books book);
        void delete(string id);
    }
}
