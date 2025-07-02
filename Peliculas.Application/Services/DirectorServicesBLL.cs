using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Peliculas.Application.DTOs;
using Peliculas.Application.Interfaces;
using Peliculas.Domain.Entities;
using Peliculas.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Application.Services
{
    public class DirectorServicesBLL : IDirectorBLL
    {
        private AppDbContext _context;

        public DirectorServicesBLL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DirectorDTO>> getDirectores()
        {
            var directores = await _context.Director
                .Include(m=>m.Movies)
                .ToListAsync();

            return directores.Select(d => new DirectorDTO
            {
                idDirector = d.idDirector,
                name = d.name,
                age = d.age,
                active = d.active,
                nationality = d.nationality,
                CounMovies = d.Movies.Count()
            }).ToList();

        }

        public async Task<List<DirectorDTO>> getDirectoresActivos()
        {
            var directores = await _context.Director
                .Include(m => m.Movies)
                .Where(m => m.active == true)
                .ToListAsync();

            return directores.Select(d => new DirectorDTO
            {
                idDirector = d.idDirector,
                name = d.name,
                age = d.age,
                active = d.active,
                nationality = d.nationality,
                CounMovies = d.Movies.Count()
            }).ToList();

        }

        public async Task<int> insertDirector(DirectorDTO directorDTO)
        {
            var director_existente = _context.Director.FirstOrDefault(d => d.name == directorDTO.name);

            if (director_existente != null)
            {
                throw new Exception("El director ya esta registrado");
            }

            Director director = new Director();

            director.name = directorDTO.name;
            director.age = directorDTO.age;
            director.nationality = directorDTO.nationality;
            director.active = true;

            _context.Director.Add(director);
            int idDirector = await _context.SaveChangesAsync();

            if (idDirector <= 0)
                throw new Exception("Error al registrar al director");

            return director.idDirector;

        }

        public async Task<int> putDirector(DirectorDTO directorDTO)
        {

            Director director = new Director();

            director.idDirector = directorDTO.idDirector;
            director.name = directorDTO.name;
            director.age = directorDTO.age;
            director.nationality = directorDTO.nationality;
            director.active = directorDTO.active;

            _context.Director.Update(director);
            int idDirector = await _context.SaveChangesAsync();

            if (idDirector <= 0)
                throw new Exception("Error al registrar al director");

            return director.idDirector;

        }
        public async Task<bool> deleteDirector(int idDirector)
        {
            var director = await _context.Director.FindAsync(idDirector);

            if (director == null)
                return false;

            _context.Director.Remove(director);
            int idDirectorEliminado = await _context.SaveChangesAsync();

            return idDirectorEliminado > 0;
        }
    }
}
