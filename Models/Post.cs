namespace RemoteJobber.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Salary { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
    }
}