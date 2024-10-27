using Rating_Photo.DBContext;
using Rating_Photo.Models.Authomation;

namespace Rating_Photo.Seed
{
    public class UserCreator
    {
        private readonly RatingSystemDbContext _ratingSystemDb;
        public UserCreator(RatingSystemDbContext ratingSystemDb)
        {
            _ratingSystemDb = ratingSystemDb;
        }

        public void Create()
        {
            CreateUser();
        }

        private void CreateUser()
        {
            if (!_ratingSystemDb.Users.Any())
            {
                _ratingSystemDb.Users.AddRange(
                    new User {UserName = "JohnDoe", Password = "password123", Email = "johndoe@example.com", CreateAt = DateTime.UtcNow },
                    new User {UserName = "JaneSmith", Password = "password123", Email = "janesmith@example.com", CreateAt = DateTime.UtcNow }
                );
            }
        }
    }

}
