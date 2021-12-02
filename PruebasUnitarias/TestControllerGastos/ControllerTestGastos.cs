using FinanzasApp.Controllers;
using FinanzasApp.Interface;
using FinanzasApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasUnitarias.TestControllerGastos
{
    class ControllerTestGastos
    {
        private Mock<IGasto> gastoRepository;
        private Mock<ICuenta> cuentaRepository;

        [SetUp]
        public void SetUp()
        {
            gastoRepository = new Mock<IGasto>();
            cuentaRepository = new Mock<ICuenta>();
        }

        [Test]
        public void TestIndexListaGastosIsOkCase01()
        {

            gastoRepository.Setup(a => a.getLista()).Returns(new List<Gastos>());

            var controller = new GastosController(gastoRepository.Object,null);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<Gastos>>(view.Model);

        }

        [Test]
        public void TestCreateGastosIsOkCase02()
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

            var controller = new GastosController(null, cuentaRepository.Object);

            var view = controller.Create() as ViewResult;

            var c = controller.ViewBag.Cuenta;

            Assert.AreEqual(cuenta, c);
        }
    }
}
