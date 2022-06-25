using MongoDB.Bson;
using MongoDB.Driver;
using OnlineLibrary.Models;

namespace OnlineLibrary.Interfaces
{
    public interface IRentBooks
    {
        IMongoCollection<RentBooks> RentBooksCollection { get; }
        IEnumerable<RentBooks> GetAllRentBooks();
        IEnumerable<RentBooks> GetUserRentBooks(string userId);
        RentBooks GetRentBookDetails(string id);
        void pinjam(RentBooks rentbook, string NIS, string BookId);
        void kembali(string id);
    }
}
