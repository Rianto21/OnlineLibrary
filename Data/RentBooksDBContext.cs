using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using OnlineLibrary.Interfaces;
using OnlineLibrary.Models;

namespace OnlineLibrary.Data
{
    public class RentBooksDBContext : IRentBooks
    {
        public readonly IMongoDatabase _db;
        public RentBooksDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(connectionString: "mongodb+srv://Oryto21:M1475963@cluster0.ar1x3.mongodb.net/test");
            _db = client.GetDatabase("online_library");

        }
        public IMongoCollection<Books> BooksCollection => _db.GetCollection<Books>("books");
        public IMongoCollection<RentBooks> RentBooksCollection => _db.GetCollection<RentBooks>("rentbooks");
        public IMongoCollection<Users> UsersCollection => _db.GetCollection<Users>("users");
        public IEnumerable<RentBooks> GetAllRentBooks()
        {
            return RentBooksCollection.Find(a => true).ToList();
        }

        public RentBooks GetRentBookDetails(string id)
        {
            return RentBooksCollection.Find(rentbook => rentbook._id == id).FirstOrDefault();
        }

        public IEnumerable<RentBooks> GetUserRentBooks(string userId)
        {
            var listrentid = UsersCollection.Find(user => user._id == userId).FirstOrDefault().DaftarPeminjaman;
            var filter = Builders<RentBooks>.Filter.In(rb => rb._id, listrentid);
            return RentBooksCollection.Find(filter).ToList();
        }

        public void kembali(string id)
        {
            var rentbooknow = RentBooksCollection.Find(rent => rent._id == id).FirstOrDefault();
            var Denda = (int)((DateTime.Now - rentbooknow.TenggatPengembalian).TotalDays) * 2000;
            if (Denda < 0)
            {
                Denda = 0;
            }
            var update = Builders<RentBooks>.Update
                .Set("Pengembalian.StatusPengembalian", true)
                .Set("Pengembalian.TanggalPengembalian", DateTime.Now)
                .Set("Pengembalian.NominalDenda", Denda);
            RentBooksCollection.UpdateOne(user => user._id == id, update);

            var updateb = Builders<Books>.Update.Set(book => book.StatusKetersediaan, true);
            BooksCollection.UpdateOne(book => book._id == rentbooknow.BooksId, updateb);
        }

        public void pinjam(RentBooks rentbook, string NIS, string BookId)
        {
            RentBooksCollection.InsertOne(rentbook);
            var id = rentbook._id;

            var update = Builders<Users>.Update.Push("DaftarPeminjaman", id);
            UsersCollection.UpdateOne(user => user.NIS == NIS, update);

            var updateb = Builders<Books>.Update.Set("StatusKetersediaan", false);
            BooksCollection.UpdateOne(book => book._id == BookId, updateb);
        }
    }
}
