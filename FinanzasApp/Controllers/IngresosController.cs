using FinanzasApp.Interface;
using FinanzasApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Controllers
{
    public class IngresosController : Controller
    {
        private readonly IIngresos ingresoInterface;
        private readonly ICuenta cuentaInterface;

        public IngresosController(IIngresos ingresoInterface, ICuenta cuentaInterface)
        {
            this.ingresoInterface = ingresoInterface;
            this.cuentaInterface = cuentaInterface;
        }

        public IActionResult Index()
        {
            var listaIngresos = ingresoInterface.getLista();
            return View(listaIngresos);
        }

        public IActionResult Create()
        {
            ViewBag.Cuenta = cuentaInterface.getLista();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                ingresoInterface.createIngresos(ingresos);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
