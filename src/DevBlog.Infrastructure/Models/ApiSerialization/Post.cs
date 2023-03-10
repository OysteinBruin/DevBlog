namespace BlogClient.Models
{
    public class Post
    {
        public string title { get; set; }

        public string description { get; set; }
        public string content { get; set; }
        public Image image { get; set; }
        public string imageUrl { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string publishedAt { get; set; }
    }
}
