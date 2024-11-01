namespace src.models.DTO
{
    public sealed class RateImageDTO
    {
        public RatingValue Rate { get; set; }
        public int PageNumber { get; set; }
    }
    public sealed class ResultDTO
    {
        public RatingValue? Rate { get; set; }

    }
}
