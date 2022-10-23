using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalsWebAPI2.Model;

namespace MovieRentalsWebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public static List<Movies> MovieList = new List<Movies>
        {
            new Movies
            {
                id = 1,
                title="ironman",
                description="metal",
                isRented=false,
                dateRented = DateTime.Now,
                isDeleted=false,
            },
            new Movies
            {
                id = 2,
                title="hulk",
                description="green",
                isRented=false,
                dateRented = DateTime.Now,
                isDeleted=false,
            }
        };


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Movies>>> Get()
        {
            return Ok(MovieList);
        }


        [HttpGet("{id}")]   
        public async Task<ActionResult<Movies>> Get(int id)
        {
            var movie = MovieList.Find(m => m.id == id);
            if (movie == null)
                return BadRequest("Movie Not Found");
            return Ok(movie);
        }


        [HttpPost]
        public async Task<ActionResult<List<Movies>>> NewMovie(Movies movie)
        {
            MovieList.Add(movie);
            return Ok(MovieList);
        }


        [HttpPut]
        public async Task<ActionResult<List<Movies>>> UpdateMovie(Movies update)
        {
            var movie = MovieList.Find(m => m.id == update.id);
            if (movie == null)
                return BadRequest("Movie Not Found");

            movie.id = update.id;
            movie.title = update.title;
            movie.isRented = update.isRented;
            movie.description = update.description;
            movie.isDeleted = update.isDeleted;

            return Ok(MovieList);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Movies>>> DeleteMovie(int id)
        {
            var movie = MovieList.Find(m => m.id==id);
            if (movie == null)
                return BadRequest("Movie Not Found");
            MovieList.Remove(movie);
            return Ok(MovieList);
        }

    }
}
