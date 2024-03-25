using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Usuario
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Usuario() { }
        public Usuario(string Email, string Password, string Nombre, string Apellido)
        {
            Email = Email;
            Password = Password;
            Nombre = Nombre;
            Apellido = Apellido;
        }
        public virtual void Validar()
        {
            ValidarEmail();
            ValidarNombre();
        }
        public void ValidarEmail()
        {
            if (!Email.Contains("@") || string.IsNullOrEmpty(Email))
            {
                throw new Exception("Excepcion de email");
            }
        }
        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception();
            }
            if (!(Char.IsLetter(Nombre[0])) || !(Char.IsLetter(Nombre[Nombre.Length - 1])))
            {
                throw new Exception();
            }

        }
    }
}
