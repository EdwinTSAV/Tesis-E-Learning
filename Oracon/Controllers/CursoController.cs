using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oracon.Models;
using Oracon.Repositorio;
using Oracon.Servicios;
using System.Diagnostics;

namespace Oracon.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoRepo context;
        private readonly IClaimService claim;
        public CursoController(ICursoRepo context, IClaimService claim)
        {
            this.context = context;
            this.claim = claim;
        }

        [HttpGet]
        public IActionResult Cursos()
        {
            ViewBag.Nombre = "Cursos";
            var cursos = context.GetCursos();
            return View("Cursos", cursos);
        }

        [HttpGet]
        public IActionResult Detalle(int idCurso)
        {
            claim.SetHttpContext(HttpContext);
            var curso = context.GetCurso(idCurso);
            if (curso !=null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    ViewBag.Favorito = context.Favorito(claim.GetLoggedUser().Id, idCurso);
                    ViewBag.Cesta = context.Pagado(claim.GetLoggedUser().Id, idCurso);
                }
                ViewBag.Nombre = curso.Nombre;
                return View("Detalle", curso);
            }
            return RedirectToAction("Error", "Curso");
        }

        [Authorize]
        [HttpGet]
        public void Favoritos(int idCurso)
        {
            claim.SetHttpContext(HttpContext);
            var favorito = context.GetFavorito(claim.GetLoggedUser().Id, idCurso);
            if (favorito != null)
            {
                context.DeleteFavorito(favorito);
                ModelState.AddModelError("Elimina", "Curso eliminado de favoritos");
            }
            if (ModelState.IsValid)
                context.SaveFavorito(idCurso, claim.GetLoggedUser().Id);
        }

        [Authorize]
        [HttpGet]
        public void Compras(int idCurso)
        {
            claim.SetHttpContext(HttpContext);
            var compras = context.GetCompra(claim.GetLoggedUser().Id, idCurso);
            var curso = context.GetCurso(idCurso);
            if (compras != null)
            {
                context.DeleteCesta(compras);
                ModelState.AddModelError("Existe", "Ya en cesta");
            }
            if (ModelState.IsValid)
                if (curso.Precio > 0)
                    context.SaveCesta(idCurso, claim.GetLoggedUser().Id);
                else
                    context.SaveGratuito(idCurso, claim.GetLoggedUser().Id);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Comentario(int idCurso, string Comentario)
        {
            var curso = context.GetCurso(idCurso);
            if (User.Identity.IsAuthenticated)
            {
                claim.SetHttpContext(HttpContext);
                if (Comentario != null)
                {
                    context.SaveComentario(claim.GetLoggedUser().Id, idCurso, Comentario);
                }
            }
            ViewBag.Nombre = curso.Nombre;
            return View("Detalle", curso);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Desarrollo(int idCurso)
        {
            var curso = context.GetCurso(idCurso);
            if (curso != null)
            {
                ViewBag.Nombre = curso.Nombre;
                return View("Desarrollo", curso);
            }
            return RedirectToAction("Error", "Curso");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Video(int idClase)
        {
            var video = context.GetClases(idClase);
            return Json(video);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
