
namespace Peliculas.Domain.Entities
{
    public class Movies
    {
        public int idMovie { get; set; }
        public int idDirector { get; set; }
        public string name { get; set; }
        public DateTime release_year { get; set; }
        public string gender { get; set; }
        public TimeSpan duration { get; set; }

        public Director? Director { get; set; }
    }
}
