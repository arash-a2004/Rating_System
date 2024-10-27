namespace Rating_Photo.Exeptions
{
    public class UserNotfoundExeption : Exception
    {
        public UserNotfoundExeption()
        {

        }
        public UserNotfoundExeption(string message)
            : base(message)
        {

        }

    }
}
