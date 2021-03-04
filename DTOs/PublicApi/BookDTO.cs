namespace DTOs.PublicApi
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public int PublishYear { get; set; }
    }
}