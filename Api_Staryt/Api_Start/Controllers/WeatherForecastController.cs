using Api_Start.Contexts;
using Api_Start.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Start.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
     
        PustokMVCProject11Context _db { get; }

        public WeatherForecastController(PustokMVCProject11Context db)
        {
            _db = db;
        }



        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var data = await _db.Categories.Select(a => new Category
            {
                Id = a.Id,
                Name = a.Name,
                ParentCategoryId = a.ParentCategoryId,
                IsDeleted = a.IsDeleted,
            }).ToListAsync();
            return Ok(data);
        }

        [HttpPost(Name = "postWeatherForecast")]
        public async Task<IActionResult> post()
        {
            var data = await _db.Categories.Select(a => new Category
            {
                Id = a.Id,
                Name = a.Name,
                ParentCategoryId = a.ParentCategoryId,
                IsDeleted = a.IsDeleted,
            }).ToListAsync();
            return Ok(data);
        }

    }
}