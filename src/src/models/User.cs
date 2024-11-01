namespace src.models
{
    public sealed class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public List<Results> ResultList { get; set; } = new List<Results>();

    }
}
