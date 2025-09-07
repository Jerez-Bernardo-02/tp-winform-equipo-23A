using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public List<Imagen> Imagen { get; set; }
        public double Precio { get; set; }
    }
}
