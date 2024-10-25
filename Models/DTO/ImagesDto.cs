namespace Rating_Photo.Models.DTO
{
    public sealed class ImagesDto
    {
        public string Image_Description { get; set; }
        public byte[] ImageFile { get; set; }
        public RatingDto Rate { get; set; }
        public ImagesDto()
        {
            Rate = new RatingDto();
        }
    }
}
