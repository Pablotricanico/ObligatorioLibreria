using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Articulo
{
    public class NombreNoVacioException : ArticuloInvalidoException
    {
        public NombreNoVacioException(): base("No tiene que estar vacio") { }
        public NombreNoVacioException(string message) : base(message) { }
    }
}
