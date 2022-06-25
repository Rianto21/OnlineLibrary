using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineLibrary.Models
{
    public class RentBooks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string? BooksId { get; set; }
        public string NISPeminjam { get; set; }
        public string JudulBuku { get; set; }
        public DateTime TanggalPeminjaman { get; set; } = DateTime.Now;
        public DateTime TenggatPengembalian { get; set; } = DateTime.Now.AddDays(7);
        public Pengembalian Pengembalian { get; set; } = new Pengembalian();


        public RentBooks(string Book, string NIS, string Judul)
        {
            NISPeminjam = NIS;
            BooksId = Book;
            JudulBuku = Judul;
        }

    }

    public class Pengembalian
    {
        public Boolean StatusPengembalian { get; set; } = false;
        public DateTime? TanggalPengembalian { get; set; } = null;
        public int NominalDenda { get; set; } = 0;
    }
}
