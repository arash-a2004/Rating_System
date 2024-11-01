using Microsoft.EntityFrameworkCore;
using src.DBContext;
using src.models;
using src.models.DTO;

namespace src.services
{
    public class ImageServices
    {
        private readonly RatingSystemDbcontext _dbcontext;

        public ImageServices(RatingSystemDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task GetAllImageIds()
        {
            var idList = await _dbcontext.Images
                .Select(x => x.Id)
                .ToListAsync();

            if ((idList.Count) % 2 != 0)
            {
                idList.RemoveAt((idList.Count) - 1);
            }

            Random random = new Random(GlobalVariables.Seed);

            idList = idList.OrderBy(x => random.Next()).ToList();

            GlobalVariables.pairedDictionary = new Dictionary<int, int>();

            for (int i = 0; i < idList.Count - 1; i += 2)
            {
                GlobalVariables.pairedDictionary[idList[i]] = idList[i + 1];
            }
        }


        public async Task<List<ImageDTO>> GetImageDetailByPageNumber(int page)
        {
            var image1Id = GlobalVariables.pairedDictionary.ElementAt(page-1).Key;
            var image2Id = GlobalVariables.pairedDictionary.ElementAt(page-1).Value;

            var image1 = await _dbcontext.Images
                .Where(e => e.Id == image1Id)
                .FirstOrDefaultAsync();
            var image2 = await _dbcontext.Images
                .Where(e => e.Id == image2Id)
                .FirstOrDefaultAsync();

            if (image1 == null || image2 == null)
            {
                throw new Exception($"there is No image with {image1Id} or {image2Id}");
            }

            List<ImageDTO> result = new List<ImageDTO>();
            result.Add(new ImageDTO { ImageURL = image1.ImageURL, Image_Description = image1.Image_Description });
            result.Add(new ImageDTO { ImageURL = image2.ImageURL, Image_Description = image2.Image_Description });

            return result;
        }

        public async Task RateImageByPageNumber(int userId,int page, RatingValue RateValue)
        {
            var image1Id = GlobalVariables.pairedDictionary.ElementAt(page).Key;
            var image2Id = GlobalVariables.pairedDictionary.ElementAt(page).Value;

            var user = await _dbcontext.Users
                .Where(e =>e.Id == userId)
                .FirstOrDefaultAsync();

            if(user == null)
            {
                throw new Exception($"there is no user with id = {userId}");
            }

            var result = new models.Results()
            {
                Image1Id = image1Id,
                Image2Id = image2Id,
                User = user,
                RateValue = RateValue,
                UserId = userId
            };
            
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
        }

        public TotalCount totalImages()
        {
            var totalCount = new TotalCount()
            {
                total = GlobalVariables.pairedDictionary.Count()
            };
            return totalCount;
        }

    }
}
