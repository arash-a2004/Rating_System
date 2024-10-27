namespace Rating_Photo.Models.Authomation
{
    // Dependent (child)-Image Table
    public sealed class Rating
    {
        public int Id { get; set; }
        public RatingValue? RateValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public int UserId { get; set; }
        public User user { get; set; }

        public int ImageId { get; set; }
        public Image RatedImage { get; set; }

    }
}