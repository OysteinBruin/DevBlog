namespace BlogClient.Models
{
    public class ImageFormatAttributes
    {
        public string name { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public string? path { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public double size { get; set; }
        public string url { get; set; }
    }
}
