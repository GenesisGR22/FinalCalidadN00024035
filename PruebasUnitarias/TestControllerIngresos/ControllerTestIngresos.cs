using FinanzasApp.Controllers;
using FinanzasApp.Interface;
using FinanzasApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasUnitarias.TestControllerIngresos
{
    class ControllerTestIngresos
    {
        private Mock<ICuenta> cuentaRepository;
        private Mock<IIngresos> ingresosRepository;

        [SetUp]
        public void SetUp()
        {
            cuentaRepository = new Mock<ICuenta>();
            ingresosRepository = new Mock<IIngresos>();
        }

        [Test]
        public void TestIndexListaIngresosIsOkCase01()
        {

            ingresosRepository.Setup(a => a.getLista()).Returns(new List<Ingresos>());

            var controller = new IngresosController(ingresosRepository.Object, null);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<Ingresos>>(view.Model);


        }

        [Test]
        public void TestCreateIngresosIsOkCase02()
        {
            var cuenta = new List<Cuenta>()
            {
                new Cuenta()
                {
                    Id = 1,
                    Nombre = "Banco Pichincha",
                    Categoria = "Credito",
                    Monto = 1500
                },
                new Cuenta()
                {
                    Id = 2,
                    Nombre = "Banco de la Nación",
                    Categoria = "Propia",
                    Monto = 2000
                },
            };

            cuentaRepository.Setup(a => a.getLista()).Returns(cuenta);

            var controller = new IngresosController(null, cuentaRepository.Object);

            var view = controller.Create() as ViewResult;

            var c = controller.ViewBag.Cuenta;

            Assert.AreEqual(cuenta, c);
        }
    }
}
