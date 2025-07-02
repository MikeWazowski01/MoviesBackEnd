using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Peliculas.Application.DTOs;
using Peliculas.Application.Interfaces;

namespace Peliculas_API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DirectorController:ControllerBase
    {
        private IDirectorBLL _directorBLL { get; }
        const string _table = "-directores";
        public DirectorController(IDirectorBLL directorBLL)
        {
            _directorBLL = directorBLL;
        }

        [HttpGet("get-list" + _table)]
        public async Task<ActionResult<List<DirectorDTO>>> getDirectores()
        {
            return await _directorBLL.getDirectores();

        }

        [HttpGet("get-list-activos" + _table)]
        public async Task<ActionResult<List<DirectorDTO>>> getDirectoresActivos()
        {
            return await _directorBLL.getDirectoresActivos();

        }

        [HttpPost("register" + _table)]
        public async Task<ActionResult<int>> insertDirector(DirectorDTO directorDTO)
        {
            return  await _directorBLL.insertDirector(directorDTO);

        }

        [HttpPut]
        public async Task<ActionResult<int>> putDirector(DirectorDTO directorDTO)
        {

            return await _directorBLL.putDirector(directorDTO);
            
        }

        [HttpDelete("{idDirector:int}")]
        public async Task<ActionResult<bool>> deleteDirector(int idDirector)
        {
            return await _directorBLL.deleteDirector(idDirector);
        }
    }
}
