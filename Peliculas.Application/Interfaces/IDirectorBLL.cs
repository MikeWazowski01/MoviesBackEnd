using Peliculas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Application.Interfaces
{
    public interface IDirectorBLL
    {
        Task<List<DirectorDTO>> getDirectores();

        Task<List<DirectorDTO>> getDirectoresActivos();
        Task<int> insertDirector( DirectorDTO directorDTO);

        Task<int> putDirector(DirectorDTO directorDTO);

        Task<bool> deleteDirector(int idDirector);
    }
}
