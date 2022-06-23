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
            throw new NotImplementedException();
        }

        public void Register(Users user)
        {
            UsersCollection.InsertOne(user);
        }

        public void update(string NIS, Users book)
        {
            throw new NotImplementedException();
        }

        public Users UserLogin(string NIS, string password)
        {
            //var Filter = Builders<Users>.Filter.Eq(user => user.NIS, NIS, )
            var user = UsersCollection.Find(user => user.NIS == NIS & user.Password == password).FirstOrDefault();
            return user;
        }
        public void userorderbooks(string NIS, string BookId)
        {
            throw new NotImplementedException();
        }
    }
}
