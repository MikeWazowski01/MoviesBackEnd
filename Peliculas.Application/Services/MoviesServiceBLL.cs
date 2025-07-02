using Microsoft.EntityFrameworkCore;
using Peliculas.Application.DTOs;
using Peliculas.Application.Interfaces;
using Peliculas.Domain.Entities;
using Peliculas.Infrastructure.Data;

namespace Peliculas.Application.Services
{
    public class MoviesServiceBLL : IMoviesBLL
    {
        private AppDbContext _context;

        public MoviesServiceBLL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MoviesDTO>> getMovies()
        {
            var movies = await _context.Movies
               .Include(d => d.Director)
               .ToListAsync();

            return movies.Select(m => new MoviesDTO
            {
                idMovie = m.idMovie,
                idDirector = m.idDirector,
                name = m.name,
                release_year = m.release_year,
                gender = m.gender,
                duration = m.duration,
                nombreDirector = m.Director.name
            }).ToList();
        }

        public async Task<List<MoviesDTO>> getMoviesId(int idDirector)
        {
            var movies = await _context.Movies
               .Include(d => d.Director)
               .Where(d=> d.idDirector == idDirector)
               .ToListAsync();

            return movies.Select(m => new MoviesDTO
            {
                idMovie = m.idMovie,
                idDirector = m.idDirector,
                name = m.name,
                release_year = m.release_year,
                gender = m.gender,
                duration = m.duration,
                nombreDirector = m.Director.name
            }).ToList();
        }

        public async Task<int> insertMovie(MoviesDTO moviesDTO)
        {
            var movie_existente = _context.Movies.FirstOrDefault(d => d.name == moviesDTO.name);

            if (movie_existente != null)
            {
                throw new Exception("La pelicula  ya esta registrada");
            }

            Movies movies = new Movies();

            movies.idDirector = moviesDTO.idDirector;
            movies.name = moviesDTO.name;
            movies.release_year = moviesDTO.release_year;
            movies.gender = moviesDTO.gender;
            movies.duration = moviesDTO.duration;

            _context.Movies.Add(movies);
            int idMovie = await _context.SaveChangesAsync();

            if (idMovie <= 0)
                throw new Exception("Error al registrar la pelicula");

            return movies.idMovie;

        }
        public async Task<int> putMovie(MoviesDTO moviesDTO)
        {

            Movies movies = new Movies();

            movies.idMovie = moviesDTO.idMovie;
            movies.idDirector = moviesDTO.idDirector;
            movies.name = moviesDTO.name;
            movies.release_year = moviesDTO.release_year;
            movies.gender = moviesDTO.gender;
            movies.duration = moviesDTO.duration;

            _context.Movies.Update(movies);
            int idMovie = await _context.SaveChangesAsync();

            if (idMovie <= 0)
                throw new Exception("Error al editar la pelicula");

            return movies.idMovie;

        }

        public async Task<bool> deleteMovie(int idMovie)
        {
            var movie = await _context.Movies.FindAsync(idMovie);

            if (movie == null)
                return false;

            _context.Movies.Remove(movie);
            int idMoviEliminado = await _context.SaveChangesAsync();

            return idMoviEliminado > 0;
        }
    }
}
