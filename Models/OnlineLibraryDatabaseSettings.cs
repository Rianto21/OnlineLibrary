namespace OnlineLibrary.Models
{
    public class OnlineLibraryDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string booksCollectionName { get; set; } = null!;
        public string usersCollectionName { get; set; } = null!;
        public string rentbooksCollectionName { get; set; } = null!;

    }
}
