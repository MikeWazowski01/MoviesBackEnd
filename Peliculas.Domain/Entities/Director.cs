using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Domain.Entities
{
    public class Director
    {
        public int idDirector { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public int age { get; set; }
        public bool active { get; set; }

        public ICollection<Movies> Movies { get; set; } = new List<Movies>();
    }
}
