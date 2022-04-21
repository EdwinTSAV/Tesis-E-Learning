using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    class AjustestTest
    {
        [Test]
        public void Index()
        {
            var conf = new Mock<IConfiguration>();

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var repo = new Mock<IAjustesRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuario(1)).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var controller = new AjustesController(repo.Object, claim.Object,conf.Object);
            var view = controller.Index() as ViewResult;

            Assert.AreEqual("Index", view.ViewName);
        }
    }
}
