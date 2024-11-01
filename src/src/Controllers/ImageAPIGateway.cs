using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using src.DBContext;
using src.models;
using src.models.DTO;

namespace src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class ImageAPIGateway : ControllerBase
    {
        private readonly RatingSystemDbcontext _dbcontext;

        public ImageAPIGateway(RatingSystemDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("Image/GetImageByPageNumber")]
        public async Task<ActionResult<List<ImageDTO>>> GetImageByPageNumber(int page)
        {
            services.ImageServices imageService = new services.ImageServices(_dbcontext);
            try
            {
                var images = await imageService.GetImageDetailByPageNumber(page);

                return Ok(images);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString);
                return BadRequest(ex.ToString());
            }
            }


        [HttpPost]
        [Route("Image/RateImageByPageNumber")]
        public async Task<ActionResult> RateImageByPageNumber([FromHeader] int userId, [FromBody] RateImageDTO rateDTO)
        {
            services.ImageServices imageService = new services.ImageServices(_dbcontext);
            try
            {
                await imageService.RateImageByPageNumber(userId, rateDTO.PageNumber, rateDTO.Rate);
                return Ok();    
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString);
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("Image/CheckImageSelectedOrNot")]
        public async Task<ActionResult<ResultDTO>> CheckImageSelectedOrNot([FromHeader] int userId, [FromHeader] int page)
        {

            services.ImageServices imageService = new services.ImageServices(_dbcontext);
            try
            {
                var a = await imageService.CheckImageSelectedOrNot(userId,page);
                return Ok(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString);
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("Image/TotalCountImages")]
        public ActionResult<TotalCount> TotalCountImages()
        {
            services.ImageServices imageService = new services.ImageServices(_dbcontext);
            try
            {
                var total = imageService.totalImages();
                return Ok(total);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString);
                return BadRequest(ex.ToString());
            }


        }

    }
}
