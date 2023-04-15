using Microsoft.AspNetCore.Mvc;
using ServerSideDataTable.Models;
using System.Diagnostics;

namespace ServerSideDataTable.Controllers
{
    public class HomeController : Controller
    {

        private readonly JquerytablebasicContext _dbContext;

        public HomeController(JquerytablebasicContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerEmpleado()
        {
            //numero de veces que se ha realiza una peticion
            int nroPeticion = Convert.ToInt32(Request.Form["draw"].FirstOrDefault() ?? "0");

            //cuantos registros va a devolver
            int cantidadRegistros = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");

            //registros a omitir
            int omitirRegistros = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

            //el texto de busqueda 
            string valorBuscado = Request.Form["search[value]"].FirstOrDefault() ?? "0";
                

            //====================Para obtener datos ======================//

            var list = new List<Empleado>();

            IQueryable<Empleado> queryEmpleado = _dbContext.Empleados;

            int totalRegistros = queryEmpleado.Count();

            if(!string.IsNullOrEmpty(valorBuscado))
                queryEmpleado = queryEmpleado.Where(e => e.Nombre.Contains(valorBuscado) || e.Salario.Contains(valorBuscado) || e.Oficina.Contains(valorBuscado) || e.Telefono.ToString().Contains(valorBuscado) 
                || e.Cargo.Contains(valorBuscado) || e.FechaIngreso.ToString().Contains(valorBuscado));

            int totalRegistrosFiltrado = queryEmpleado.Count();

            list = queryEmpleado.Skip(omitirRegistros).Take(cantidadRegistros).ToList();

            return Json(new { draw = nroPeticion,recordsTotal = totalRegistros,recordsFiltered = totalRegistrosFiltrado ,data = list});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}