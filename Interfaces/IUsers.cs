using MongoDB.Driver;
using OnlineLibrary.Models;

namespace OnlineLibrary.Interfaces
{
    public interface IUsers
    {
        IMongoCollection<Users> UsersCollection { get; }
        Users GetUserDetails(string NIS);
        Users UserLogin(string NIS, string password);
        void Register(Users user);
        void update(string NIS, Users book);
        void userorderbooks(string NIS, string BookId);
    }
}
