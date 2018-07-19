using GeaWebMVC.Business.RepositoryInterfaces;
using GeaWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GeaWebMVC.Controllers
{
    [AllowAnonymous]
    public class AutenticationController : Controller
    {
        private readonly IBusinessOperador _businessOperador;
        public AutenticationController(IBusinessOperador businessOperado)
        {
            _businessOperador = businessOperado;
        }
        public ActionResult Login()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Operador operadorExistente = _businessOperador.FindByLogin(user.Login);

            if (user.Login.ToUpper() == operadorExistente?.Login.ToUpper() && user.Senha.ToUpper() == operadorExistente?.Senha.ToUpper())
            {
                var identity = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Name, operadorExistente.Login+"|"+ operadorExistente.Perfil.Tipo),

                    }, "ApplicationCookie"
                );

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                                             
                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(returnUrl));
            }
            
            ModelState.AddModelError("","Usuário ou senha estão inválidos");
            return View();
        }
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
         

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("index", "home");
        }
        [NonAction]
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }


    }
}