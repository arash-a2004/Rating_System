using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using src.Data;
using src.models;
using src.models.DTO;
using src.Models;

namespace src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    //[Authorize]
    public class ImageAPIGateway : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly UserManager<User> _userManager;

        public ImageAPIGateway(ApplicationDbContext dbcontext, UserManager<User> userManager)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Image/GetImageByPageNumber")]
        public async Task<ActionResult<List<ImageDTO>>> GetImageByPageNumber([FromHeader]int page)
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
        public async Task<ActionResult> RateImageByPageNumber( [FromBody] RateImageDTO rateDTO)
        {
            services.ImageServices imageService = new services.ImageServices(_dbcontext);
            try
            {
                await imageService.RateImageByPageNumber(_userManager.GetUserId(User), rateDTO.PageNumber, rateDTO.Rate);
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
        public async Task<ActionResult<ResultDTO>> CheckImageSelectedOrNot( [FromHeader] int page)
        {

            services.ImageServices imageService = new services.ImageServices(_dbcontext);
            try
            {
                var a = await imageService.CheckImageSelectedOrNot(_userManager.GetUserId(User), page);
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
