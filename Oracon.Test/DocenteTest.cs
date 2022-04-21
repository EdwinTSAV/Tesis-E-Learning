using Microsoft.AspNetCore.Hosting;
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
    class DocenteTest
    {
        [Test]
        public void CrearCursos()
        {
            var conf = new Mock<IWebHostEnvironment>();

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IDocenteRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuario(2)).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var controller = new DocenteController(repo.Object, claim.Object, conf.Object);
            var view = controller.CrearCursos() as ViewResult;

            Assert.AreEqual("CrearCursos", view.ViewName);
        }

        [Test]
        public void EditarCurso()
        {
            var conf = new Mock<IWebHostEnvironment>();

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IDocenteRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuario(2)).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });
            repo.Setup(o => o.GetCursoIdUsuario(10, 2)).Returns(new Curso());

            var controller = new DocenteController(repo.Object, claim.Object, conf.Object);
            var view = controller.EditarCurso(10) as ViewResult;

            Assert.AreEqual("EditarCurso", view.ViewName);
        }

        [Test]
        public void EliminarCurso()
        {
            var conf = new Mock<IWebHostEnvironment>();

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IDocenteRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuario(2)).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });
            repo.Setup(o => o.GetCursoIdUsuario(10, 2)).Returns(new Curso());
            repo.Setup(o => o.DeleteCurso(new Curso()));

            var controller = new DocenteController(repo.Object, claim.Object, conf.Object);
            var view = controller.EliminarCurso(10) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        [Test]
        public void DetalleCurso()
        {
            var conf = new Mock<IWebHostEnvironment>();

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IDocenteRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuario(2)).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });
            repo.Setup(o => o.GetCursosProceso(2)).Returns(new List<Curso>());

            var controller = new DocenteController(repo.Object, claim.Object, conf.Object);
            var view = controller.DetalleCurso() as ViewResult;

            Assert.AreEqual("DetalleCurso", view.ViewName);
        }

        [Test]
        public void Aprendizaje()
        {
            var conf = new Mock<IWebHostEnvironment>();

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IDocenteRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuario(2)).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });
            repo.Setup(o => o.GetCursosProceso(2)).Returns(new List<Curso>());

            var controller = new DocenteController(repo.Object, claim.Object, conf.Object);
            var view = controller.Aprendizaje() as ViewResult;

            Assert.AreEqual("Aprendizaje", view.ViewName);
        }

        [Test]
        public void Contenido()
        {
            var conf = new Mock<IWebHostEnvironment>();

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });

            var repo = new Mock<IDocenteRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuario(2)).Returns(new Usuario { Id = 2, Nombres = "Hola", IdRol = 2 });
            repo.Setup(o => o.GetCursosProceso(2)).Returns(new List<Curso>());

            var controller = new DocenteController(repo.Object, claim.Object, conf.Object);
            var view = controller.Contenido() as ViewResult;

            Assert.AreEqual("Contenido", view.ViewName);
        }
    }
}
