using FinanzasApp.Interface;
using FinanzasApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Controllers
{
    public class GastosController : Controller
    {
        private readonly IGasto gastoInterface;
        private readonly ICuenta cuentaInterface;

        public GastosController(IGasto gastoInterface, ICuenta cuentaInterface)
        {
            this.gastoInterface = gastoInterface;
            this.cuentaInterface = cuentaInterface;
        }
        public IActionResult Index()
        {
            var listaGastos = gastoInterface.getLista();
            return View(listaGastos);
        }

        public IActionResult Create()
        {
            ViewBag.Cuenta = cuentaInterface.getLista();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Gastos gastos)
        {

            var cuen = cuentaInterface.Cuenta(gastos.CuentaId);

            if(gastos.Monto > cuen.Monto)
            {
                return RedirectToAction("Index");

            }

            if (ModelState.IsValid)
            {
                gastoInterface.createGastos(gastos);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
