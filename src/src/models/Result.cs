using src.Models;

namespace src.models
{
    public sealed class Results
    {
        public int Id { get; set; }
        public int Image1Id { get; set; }
        public int Image2Id { get; set; }
        public RatingValue RateValue { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
