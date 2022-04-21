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
    class AdminTest
    {
        [Test]
        public void Usuario()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var repo = new Mock<IAdminRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuarioId(1)).Returns(new Usuario {Id = 1, Nombres = "Hola", IdRol = 1});
            repo.Setup(o => o.GetUsuariosRol(2)).Returns(new List<Usuario>());

            var controller = new AdminController(repo.Object, claim.Object);
            var view = controller.Usuarios(2) as ViewResult;

            Assert.AreEqual("Usuarios", view.ViewName);
        }

        [Test]
        public void CrearUsuarios()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var repo = new Mock<IAdminRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuarioId(1)).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });
            repo.Setup(o => o.GetRoles()).Returns(new List<Roles>());

            var controller = new AdminController(repo.Object, claim.Object);
            var view = controller.CrearUsuarios() as ViewResult;

            Assert.AreEqual("CrearUsuarios", view.ViewName);
        }

        [Test]
        public void EditarUsuario()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var repo = new Mock<IAdminRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuarioId(1)).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });
            repo.Setup(o => o.GetRoles()).Returns(new List<Roles>());
            repo.Setup(o => o.GetUsuarioId(10)).Returns(new Usuario());

            var controller = new AdminController(repo.Object, claim.Object);
            var view = controller.EditarUsuario(10) as ViewResult;

            Assert.AreEqual("EditarUsuario", view.ViewName);
        }

        [Test]
        public void EliminarUsuario()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var repo = new Mock<IAdminRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuarioId(1)).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });
            repo.Setup(o => o.GetUsuarioId(10)).Returns(new Usuario());
            repo.Setup(o => o.DeleteUser(new Usuario()));

            var controller = new AdminController(repo.Object, claim.Object);
            var view = controller.EliminarUsuario(10) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        [Test]
        public void CrearCursos()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var repo = new Mock<IAdminRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuarioId(1)).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });
            repo.Setup(o => o.GetUsuariosRol(2)).Returns(new List<Usuario>());

            var controller = new AdminController(repo.Object, claim.Object);
            var view = controller.CrearCursos() as ViewResult;

            Assert.AreEqual("CrearCursos", view.ViewName);
        }

        [Test]
        public void EditarCurso()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var repo = new Mock<IAdminRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuarioId(1)).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });
            repo.Setup(o => o.GetCurso(10)).Returns(new Curso());

            var controller = new AdminController(repo.Object, claim.Object);
            var view = controller.EditarCurso(10) as ViewResult;

            Assert.AreEqual("EditarCurso", view.ViewName);
        }

        [Test]
        public void EliminarCurso()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var repo = new Mock<IAdminRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuarioId(1)).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });
            repo.Setup(o => o.GetCurso(10)).Returns(new Curso());
            repo.Setup(o => o.DeleteCurso(new Curso()));

            var controller = new AdminController(repo.Object, claim.Object);
            var view = controller.EliminarCurso(10) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        [Test]
        public void Categorias()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var repo = new Mock<IAdminRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuarioId(1)).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var controller = new AdminController(repo.Object, claim.Object);
            var view = controller.Categorias() as ViewResult;

            Assert.AreEqual("Categorias", view.ViewName);
        }

        [Test]
        public void Compras()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });

            var repo = new Mock<IAdminRepo>();
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetUsuarioId(1)).Returns(new Usuario { Id = 1, Nombres = "Hola", IdRol = 1 });
            repo.Setup(o => o.GetCompras()).Returns(new List<Cesta>());

            var controller = new AdminController(repo.Object, claim.Object);
            var view = controller.Categorias() as ViewResult;

            Assert.AreEqual("Categorias", view.ViewName);
        }
    }
}
