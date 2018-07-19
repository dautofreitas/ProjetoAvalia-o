using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GeaWebMVC.Utils
{
    public class PerfilFilter: ActionFilterAttribute {
    
        public string TipoPerfil;
      
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ActionParameters.ContainsKey(TipoPerfil))
            {
                if(filterContext.HttpContext.GetOwinContext().Authentication.User.Identity.Name.Split('|')?[1] != TipoPerfil)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "RegistroDeFluxo",
                        action = "MenuRegistroDeFluxo"
                    }));
                }
                
            }
        }
    }
}