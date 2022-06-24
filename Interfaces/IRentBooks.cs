using MongoDB.Bson;
using MongoDB.Driver;
using OnlineLibrary.Models;

namespace OnlineLibrary.Interfaces
{
    public interface IRentBooks
    {
        IMongoCollection<RentBooks> BooksCollection { get; }
        IEnumerable<RentBooks> GetAllRentBook();
        IEnumerable<RentBooks> GetListRentBook(string[] listid);
        Books GetBookDetails(string id);
        void create(Books book);
        void update(string id, Books book);
        void delete(string id);
    }
}
}
