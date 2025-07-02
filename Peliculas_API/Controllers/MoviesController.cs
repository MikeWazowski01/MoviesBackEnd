using Microsoft.AspNetCore.Mvc;
using Peliculas.Application.DTOs;
using Peliculas.Application.Interfaces;

namespace Peliculas_API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MoviesController:ControllerBase
    {
        private IMoviesBLL _moviesBLL { get; }
        const string _table = "-movies";
        public MoviesController(IMoviesBLL moviesBLL)
        {
            _moviesBLL = moviesBLL;
        }

        [HttpGet("get-list" + _table)]
        public async Task<ActionResult<List<MoviesDTO>>> getMovies()
        {
            return await _moviesBLL.getMovies();

        }
        [HttpGet("{idDirector:int}")]
        public async Task<ActionResult<List<MoviesDTO>>> getMoviesId(int idDirector)
        {
            return await _moviesBLL.getMoviesId(idDirector);
        }

        [HttpPost("register" + _table)]
        public async Task<ActionResult<int>> insertMovie([FromBody] MoviesDTO moviesDTO)
        {
            return await _moviesBLL.insertMovie(moviesDTO);

        }

        [HttpPut]
        public async Task<ActionResult<int>> putMovie([FromBody] MoviesDTO movie)
        {

            return await _moviesBLL.putMovie(movie);

        }

        [HttpDelete("{idMovie:int}")]
        public async Task<ActionResult<bool>> deleteMovie(int idMovie)
        {
            return await _moviesBLL.deleteMovie(idMovie);
        }

    }
}
