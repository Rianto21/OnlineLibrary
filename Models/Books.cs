using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Books
    {
        public int _id { get; set; }
        public string? Judul { get; set; }

        [DataType(DataType.Date)]
        public DateTime TanggalTerbit { get; set; }
        public string? Jenis { get; set; }
        public string Penulis { get; set; }
        public int JumlahHalaman { get; set; }
        public Boolean StatusKetersediaan { get; set; }


    }
}