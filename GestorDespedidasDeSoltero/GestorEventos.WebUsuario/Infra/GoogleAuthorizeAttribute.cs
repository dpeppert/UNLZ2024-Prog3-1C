
   /* using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Web.Mvc;

namespace GestorEventos.WebUsuario.Infra
{public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Verifica si el usuario no está autenticado
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // Redirige a la acción y controlador deseados
                filterContext.Result = new RedirectToRouteResult("login/index");
                     );
            }
            else
            {
                base. HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}
*/