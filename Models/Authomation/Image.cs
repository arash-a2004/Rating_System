namespace Rating_Photo.Models.Authomation
{
    // Principal (parent)
    public sealed class Image
    {
        public int Id { get; set; }
        public string Image_Description { get; set; }
        public byte[] ImageFile { get; set; }

        public Rating RatingProp { get; set; }
    }
}