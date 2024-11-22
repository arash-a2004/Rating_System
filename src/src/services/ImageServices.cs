using Microsoft.EntityFrameworkCore;
using src.Data;
using src.models;
using src.models.DTO;

namespace src.services
{
    public class ImageServices
    {
        private readonly ApplicationDbContext _dbcontext;

        public ImageServices(ApplicationDbContext dbcontext)
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
            if (page < 1)
                throw new Exception("Argument with page Number");

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

        public async Task RateImageByPageNumber(string userId,int page, RatingValue RateValue)
        {
            var image1Id = GlobalVariables.pairedDictionary.ElementAt(page).Key;
            var image2Id = GlobalVariables.pairedDictionary.ElementAt(page).Value;


            var result = new models.Results()
            {
                Image1Id = image1Id,
                Image2Id = image2Id,
                RateValue = RateValue,
                UserId = userId
            };
            
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

        public async Task<ResultDTO> CheckImageSelectedOrNot(string userId, int page)
        {
            if (page > GlobalVariables.pairedDictionary.Count)
                throw new Exception();

            var image1Id = GlobalVariables.pairedDictionary.ElementAt(page).Key;
            var image2Id = GlobalVariables.pairedDictionary.ElementAt(page).Value;

            var query = _dbcontext.Results
                .Where(e => e.UserId == userId)
                .Where(e => e.Image1Id == image1Id)
                .Where(e => e.Image2Id == image2Id)
                .OrderBy(e=>e.Id);
            
            var rate = await query.LastOrDefaultAsync();

            if (rate == null)
                return new ResultDTO()
                {
                    Rate = null
                };

            return new ResultDTO
            {
                Rate = rate.RateValue
            };


        }

    }
}
