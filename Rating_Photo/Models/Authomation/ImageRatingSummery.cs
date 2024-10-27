namespace Rating_Photo.Models.Authomation
{
    public class ImageRatingSummery
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal AverageRating { get; set; }
        public decimal TotalRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public Image image { get; set; }
    }
}