using LogicaDeNegocio.Excepciones.Usuario;
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
            ValidarApellido();
            ValidarPassword();
        }
        public void ValidarEmail()
        {
            if (string.IsNullOrEmpty(Email)|| !Email.Contains("@"))
            {
                throw new EmailInvalidoException();
            }
        }
        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new NombreInvalidoException();
            }
            if (!(Char.IsLetter(Nombre[0])) || !(Char.IsLetter(Nombre[Nombre.Length - 1])))
            {
                throw new NombreInvalidoException();
            }
            if(Nombre.Length > 2)
            {
                for (int i = 1; i <= Nombre.Length-2; i++)
                {
                    if (!Char.IsLetter(Nombre[i]) && Nombre[i] != '-' && Nombre[i]!=' ' && Nombre[i] != '`')
                    {
                        throw new NombreInvalidoException();
                    }
                }
            }
        }
        public void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new ApellidoInvalidoException();
            }
            if (!(Char.IsLetter(Apellido[0])) || !(Char.IsLetter(Apellido[Apellido.Length - 1])))
            {
                throw new ApellidoInvalidoException();
            }
            if (Apellido.Length > 2)
            {
                for (int i = 1; i <= Apellido.Length - 2; i++)
                {
                    if (!Char.IsLetter(Apellido[i]) && Apellido[i] != '-' && Apellido[i] != ' ' && Apellido[i] != '`')
                    {
                        throw new ApellidoInvalidoException();
                    }
                }
            }
        }
        public void ValidarPassword()
        {
            if(Password == null || Password.Length < 6)
            {
                throw new PasswordInvalidoException();
            }
            bool may = true;
            bool min = true;
            bool dig = true;
            bool punt = true;
            foreach(char c in Password)
            {
                if (char.IsDigit(c))
                { 
                    dig = false;
                }
                if (char.IsLower(c))
                {
                    min = false;
                }
                if (char.IsUpper(c))
                {
                    may = false;
                }
                if (c == '.' || c == ';' || c == ',' || c == '!')
                {
                    punt = false;
                }
            }
            if (dig||min||may||punt)
            {
                throw new PasswordInvalidoException();
            }
        }
    }
}
