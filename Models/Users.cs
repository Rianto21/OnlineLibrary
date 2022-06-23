using AspNetCore.Identity.MongoDbCore.Models;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace OnlineLibrary.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string Password { get; set; }
        public string Nama { get; set; }
        public string NIS { get; set; }
        public string Kelas { get; set; }
        public string Jurusan { get; set; }
        public string Role { get; }
        public string[] DaftarPeminjaman { get; set; } = Array.Empty<String>();
    }
}
