using FinanzasApp.Interface;
using FinanzasApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Controllers
{
    public class CuentaController : Controller
    {
        private readonly ICuenta cuentaInterface;

        public CuentaController(ICuenta cuentaInterface)
        {
            this.cuentaInterface = cuentaInterface;
        }

        public IActionResult Index()
        {
            var listaCuentas = cuentaInterface.getLista();
            return View(listaCuentas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                cuentaInterface.createCuenta(cuenta);
                return RedirectToAction("Index");
            }

            return View();
        }

       
    }
}
