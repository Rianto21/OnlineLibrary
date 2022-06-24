using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineLibrary.Interfaces;
using OnlineLibrary.Models;

namespace OnlineLibrary.Data
{
    public class UsersDBContext : IUsers
    {
        public readonly IMongoDatabase _db;
        public UsersDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(connectionString: "mongodb+srv://Oryto21:M1475963@cluster0.ar1x3.mongodb.net/test");
            _db = client.GetDatabase("online_library");

        }
        //public IMongoCollection<Books> BooksCollection => _db.GetCollection<Books>("users");
        public IMongoCollection<Users> UsersCollection => _db.GetCollection<Users>("users");

        public Users GetUserDetails(string NIS)
        {
            return UsersCollection.Find(user => user.NIS == NIS).FirstOrDefault();
        }

        public void Register(Users user)
        {
            UsersCollection.InsertOne(user);
        }

        public void update(string NIS, Users user)
        {
            var Filter = Builders<Users>.Filter.Eq("NIS", NIS);
            var Update = Builders<Users>.Update
                .Set("NIS", user.NIS)
                .Set("Nama", user.Nama)
                .Set("Jurusan", user.Jurusan)
                .Set("Kelas", user.Kelas)
                .Set("Password", user.Password);
            UsersCollection.UpdateOne(Filter, Update);
        }

        public Users UserLogin(string NIS, string password)
        {
            //var Filter = Builders<Users>.Filter.Eq(user => user.NIS, NIS, )
            var user = UsersCollection.Find(user => user.NIS == NIS & user.Password == password).FirstOrDefault();
            return user;
        }
        public void userorderbooks(string NIS, string RentBookId)
        {
            var update = Builders<Users>.Update.Push(user => user.DaftarPeminjaman, RentBookId);
            UsersCollection.UpdateOne(user => user.NIS == NIS, update);
        }

        public string[] showuserbookorder(string NIS)
        {
            var listorder = UsersCollection.Find(user => user.NIS == NIS).FirstOrDefault().DaftarPeminjaman;
            return listorder;
        }
    }
}
