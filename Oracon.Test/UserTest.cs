using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Oracon.Controllers;
using Oracon.Models;
using Oracon.Repositorio;
using Oracon.Servicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oracon.Test
{
    class UserTest
    {
        [Test]
        public void Contenido()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IUserRepo>();

            var controller = new UserController(repo.Object, claim.Object);
            var view = controller.Login() as ViewResult;

            Assert.AreEqual("Login", view.ViewName);
        }

        [Test]
        public void LogOut()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IUserRepo>();

            var controller = new UserController(repo.Object, claim.Object);
            var view = controller.LogOut() as RedirectToActionResult;

            Assert.AreEqual("Login", view.ActionName);
        }

        [Test]
        public void Register()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IUserRepo>();

            var controller = new UserController(repo.Object, claim.Object);
            var view = controller.Register() as ViewResult;

            Assert.AreEqual("Register", view.ViewName);
        }

        [Test]
        public void Recover()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IUserRepo>();

            var controller = new UserController(repo.Object, claim.Object);
            var view = controller.Recover() as ViewResult;

            Assert.AreEqual("Recover", view.ViewName);
        }

        [Test]
        public void StartRecover()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IUserRepo>();
            repo.Setup(o => o.GetUsuarioRecover("Token")).Returns(new Usuario());

            var controller = new UserController(repo.Object, claim.Object);
            var view = controller.StartRecover("Token") as ViewResult;

            Assert.AreEqual("StartRecover", view.ViewName);
        }
    }
}
