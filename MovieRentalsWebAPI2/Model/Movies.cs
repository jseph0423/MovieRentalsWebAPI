namespace MovieRentalsWebAPI2.Model
{
    public class Movies
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public bool isRented { get; set; } = false;
        public DateTime dateRented { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
