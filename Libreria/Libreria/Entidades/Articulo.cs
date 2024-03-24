using LogicaDeNegocio.Excepciones.Articulo;
using LogicaDeNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Articulo: IValidable
    {
        public Articulo() { 
        }

        public string Nombre {  get; set; }
        public string Descripcion { get; set; }
        public int Codigo { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new NombreNoVacioException();
            }
        }
    }
}
