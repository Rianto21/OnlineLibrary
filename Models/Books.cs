using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineLibrary.Models
{
    public class Books
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string Judul { get; set; }
        public DateTime TanggalTerbit { get; set; }
        public string Kategori { get; set; }
        public string Penulis { get; set; }
        public int JumlahHalaman { get; set; }
        public Boolean StatusKetersediaan { get; set; }


    }
}