using AspNetCore;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        //armo la lista para poder probar el verificar de los admin
        public static List<Administrador> _administradores = new List<Administrador>();
        public IActionResult AdminIndex(string mensaje)
        {
            ViewBag.Mensaje=mensaje;
            return View(_administradores);
        }
        public IActionResult AdminCreate() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminCreate(Administrador administrador)
        {
            try
            {
                administrador.Validar();
                _administradores.Add(administrador);
            }
            catch (DominioExcpetion ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Hubo un error, contactese con el administrador.";
            }
            return View(administrador);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
