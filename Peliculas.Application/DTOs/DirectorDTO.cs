
namespace Peliculas.Application.DTOs
{
    public class DirectorDTO
    {
        public int idDirector { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public int age { get; set; }
        public bool active { get; set; }

        public int CounMovies { get; set; }
    }
}
