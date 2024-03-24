using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Excepciones.Articulo;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ArticuloController : Controller
    {
        private static List<Articulo> _articulos = new List<Articulo>();
        public IActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Articulo UnArticulo)
        {
            try
            {
                UnArticulo.Validar();

                _articulos.Add(UnArticulo);
                return RedirectToAction("Index", new {mensaje = "Se dio de alta el articulo"});

            }catch (ArticuloInvalidoException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            return View("Index");
            
        }
        public IActionResult List()
        {
            return View(_articulos);
        }
    }
}
