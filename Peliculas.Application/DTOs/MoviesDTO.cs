
namespace Peliculas.Application.DTOs
{
    public class MoviesDTO
    {
        public int idMovie { get; set; }
        public int idDirector { get; set; }
        public string name { get; set; }
        public DateTime release_year { get; set; }
        public string gender { get; set; }
        public TimeSpan duration { get; set; }
        public string? nombreDirector { get; set; }
    }
}
