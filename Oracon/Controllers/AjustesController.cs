using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Oracon.Models;
using Oracon.Repositorio;
using Oracon.Servicios;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Oracon.Controllers
{
    [Authorize]
    public class AjustesController : Controller
    {
        private readonly IClaimService claim;
        private readonly IAjustesRepo context;
        private readonly IConfiguration configuration;

        public AjustesController(IAjustesRepo context, IClaimService claim, IConfiguration configuration)
        {
            this.context = context;
            this.claim = claim;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            claim.SetHttpContext(HttpContext);
            var user = context.GetUsuario(claim.GetLoggedUser().Id);
            ViewBag.User = user.IdRol;
            ViewBag.Categorias = context.GetCategorias();
            return View("Index", user);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario, IFormFile image)
        {
            claim.SetHttpContext(HttpContext);
            var user = context.GetUsuario(claim.GetLoggedUser().Id);
            ViewBag.User = user.IdRol;
            ViewBag.Categorias = context.GetCategorias();
            user.Nombres = usuario.Nombres;
            user.Apellidos = usuario.Apellidos;
            user.Celular = usuario.Celular;
            user.Twitter = usuario.Twitter;
            user.Facebook = usuario.Facebook;
            user.LinkedIn = usuario.LinkedIn;
            user.YouTube = usuario.YouTube;
            user.Instagram = usuario.Instagram;

            if (ModelState.IsValid)
            {
                context.UpdateUser(user, image);
            }
            return View("Index", user);
        }

        protected string CreateHash(string input)
        {
            input += configuration.GetValue<string>("Token");
            var sha = SHA512.Create();
            var bytes = Encoding.Default.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
