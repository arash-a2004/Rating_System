namespace Rating_Photo.Exeptions
{
    public class ImageNotFoundExeption : Exception
    {

        public ImageNotFoundExeption()
        {
            
        }
        public ImageNotFoundExeption(string message)
            :base(message)
        {
            
        }

    }
}
