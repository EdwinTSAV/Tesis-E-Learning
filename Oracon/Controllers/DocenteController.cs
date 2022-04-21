using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracon.Models;
using Oracon.Repositorio;
using Oracon.Servicios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Oracon.Controllers
{
    [Authorize]
    public class DocenteController : Controller
    {
        private readonly IClaimService claim;
        private readonly IDocenteRepo context;
        public readonly IWebHostEnvironment hosting;

        public DocenteController(IDocenteRepo context, IClaimService claim, IWebHostEnvironment hosting)
        {
            this.context = context;
            this.claim = claim;
            this.hosting = hosting;
        }

        [HttpGet]
        public IActionResult MisCursos(int idCategoria)
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Categorias = context.GetCategorias();
                var cursos = context.GetCursosCategoriaDocente(idCategoria, claim.GetLoggedUser().Id);
                foreach (var item in ViewBag.Categorias)
                {
                    if (idCategoria == item.Id)
                        ViewBag.Nombre = item.Nombre;
                }
                if (ViewBag.Nombre == null)
                    return RedirectToAction("Error", "Home");
                return View("MisCursos", cursos);
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public IActionResult CrearCursos()
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Categorias = context.GetCategorias();
                return View("CrearCursos", new Curso());
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public IActionResult CrearCursos(Curso curso, IFormFile image)
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Categorias = context.GetCategorias();
                if (ModelState.IsValid)
                {
                    context.SaveCurso(curso, claim.GetLoggedUser().Id, image);
                    return RedirectToAction("Index", "Ajustes");
                }
                return View(curso);
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public IActionResult EditarCurso(int idCurso)
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Categorias = context.GetCategorias();
                var curso = context.GetCursoIdUsuario(idCurso, claim.GetLoggedUser().Id);
                if (curso != null)
                    return View("EditarCurso", curso);
                return RedirectToAction("Error", "Home");
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public IActionResult EditarCurso(Curso curso, IFormFile image)
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Categorias = context.GetCategorias();
                if (ModelState.IsValid)
                {
                    context.UpdateCurso(curso, image);
                    return RedirectToAction("Index", "Ajustes");
                }
                return View(curso);
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public IActionResult EliminarCurso(int idCurso)
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Categorias = context.GetCategorias();
                var curso = context.GetCursoIdUsuario(idCurso, claim.GetLoggedUser().Id);
                if (curso != null)
                {
                    context.DeleteCurso(curso);
                    return RedirectToAction("Index", "Ajustes");
                }
                return RedirectToAction("Error", "Home");
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public IActionResult DetalleCurso()
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Cursos = context.GetCursosProceso(claim.GetLoggedUser().Id);
                ViewBag.Categorias = context.GetCategorias();
                return View("DetalleCurso");
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public IActionResult Aprendizaje()
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Cursos = context.GetCursosProceso(claim.GetLoggedUser().Id);
                ViewBag.Categorias = context.GetCategorias();
                return View("Aprendizaje");
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public IActionResult Aprendizaje(Aprendizaje aprendizaje)
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Cursos = context.GetCursosProceso(claim.GetLoggedUser().Id);
                ViewBag.Categorias = context.GetCategorias();
                if (ModelState.IsValid)
                    context.SaveAprendizaje(aprendizaje);
                return View(aprendizaje);
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public IActionResult Requisito(Requisitos requisitos)
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                ViewBag.Cursos = context.GetCursosProceso(claim.GetLoggedUser().Id);
                ViewBag.Categorias = context.GetCategorias();
                if (ModelState.IsValid)
                    context.SaveRequisitos(requisitos);
                return View("Aprendizaje", requisitos);
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public ActionResult Contenido()
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Cursos = context.GetCursosProceso(claim.GetLoggedUser().Id);
                ViewBag.Categorias = context.GetCategorias();
                return View("Contenido");
            }
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public ActionResult Contenido(int IdCurso, int IdModulo, string NombreModulo, int IdClase, string NombreClase, string DescripcionClase, string videoClase, List<IFormFile> tareas)
        {
            claim.SetHttpContext(HttpContext);
            if (claim.GetLoggedUser().IdRol == 2)
            {
                var user = context.GetUsuario(claim.GetLoggedUser().Id);
                ViewBag.User = user.IdRol;
                ViewBag.Cursos = context.GetCursosProceso(claim.GetLoggedUser().Id);
                ViewBag.Categorias = context.GetCategorias();

                var archivos = new List<Recursos>();
                if (tareas.Count > 0)
                {
                    foreach (var item in tareas)
                    {
                        var recurso = new Recursos
                        {
                            Archivo = SaveFiles(item)
                        };
                        archivos.Add(recurso);
                    }
                }

                if (IdCurso == 0)
                    ModelState.AddModelError("IdCurso", "Elige un curso");
                else if(IdModulo == 0)
                {
                    Modulo modulo = new Modulo() {
                        IdCurso = IdCurso,
                        Nombre = NombreModulo,
                        Clases = new List<Clases>
                        {
                            new Clases
                            {
                                Nombre = NombreClase,
                                Video = videoClase,
                                Descripcion = DescripcionClase,
                                Recursos = archivos

                            }
                        }
                    };
                    context.SaveModulos(modulo);
                }
                else if (IdModulo > 0)
                {
                    var modulo = context.GetModulo(IdModulo);
                    if (IdClase == 0)
                    {
                        modulo.Clases = new List<Clases>
                        {
                            new Clases
                            {
                                Nombre = NombreClase,
                                Video = videoClase,
                                Descripcion = DescripcionClase,
                                Recursos = archivos
                            }
                        };
                        context.UpdateModulos(modulo);
                    }
                    else if (IdClase > 0)
                    {
                        var clase = context.GetClase(IdClase);
                        clase.Recursos = archivos;
                        context.UpdateClases(clase);
                    }
                }
                return View();
            }
            else
                return RedirectToAction("Error", "Home");
        }

        private string SaveFiles(IFormFile tarea)
        {
            string relativePath = "";
            if (tarea.Length > 0)
            {
                relativePath = Path.Combine("Recursos", tarea.FileName);
                var filePath = Path.Combine(hosting.WebRootPath, relativePath);
                var stream = new FileStream(filePath, FileMode.Create);
                tarea.CopyTo(stream);
                stream.Close();
            }
            return "/" + relativePath.Replace('\\', '/');
        }

        [HttpGet]
        public IActionResult Modulos(int idCurso)
        {
            var modulos = context.GetModulos(idCurso);
            return Json(modulos);
        }

        [HttpGet]
        public IActionResult Clases(int idModulo)
        {
            var clases = context.GetClases(idModulo);
            return Json(clases);
        }
    }
}
