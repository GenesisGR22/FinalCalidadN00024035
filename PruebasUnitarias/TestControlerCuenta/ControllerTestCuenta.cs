using FinanzasApp.Controllers;
using FinanzasApp.Interface;
using FinanzasApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasUnitarias.TestControlerCuenta
{
    class ControllerTestCuenta
    {
        private Mock<ICuenta> cuentaRepository;

        [SetUp]
        public void SetUp()
        {
            cuentaRepository = new Mock<ICuenta>();
        }

        [Test]
        public void TestIndexListaCuentasIsOkCase01()
        {

            cuentaRepository.Setup(a => a.getLista()).Returns(new List<Cuenta>());

            var controller = new CuentaController(cuentaRepository.Object);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<Cuenta>>(view.Model);

        }

        [Test]
        public void TestCreateCuentaIsOkCase02()
        {
            cuentaRepository.Setup(a => a.createCuenta(new Cuenta()));
            var controller = new CuentaController(cuentaRepository.Object);

            var view = controller.Create(new Cuenta());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
