using Peliculas.Application.DTOs;
using Peliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
