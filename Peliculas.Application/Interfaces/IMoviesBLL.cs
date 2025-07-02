using Peliculas.Application.DTOs;

namespace Peliculas.Application.Interfaces
{
    public interface IMoviesBLL
    {
        Task<List<MoviesDTO>> getMovies();

        Task<List<MoviesDTO>> getMoviesId(int idDirector);

        Task<int> insertMovie(MoviesDTO moviesDTO);

        Task<int> putMovie(MoviesDTO directorDTO);

        Task<bool> deleteMovie(int idMovie);
    }
}
