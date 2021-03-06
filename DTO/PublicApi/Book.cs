namespace DTO.PublicApi
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public int PublishYear { get; set; }
    }
}