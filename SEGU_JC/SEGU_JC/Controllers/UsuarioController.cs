using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEGU_JC.Models;
using SEGU_ENTI.Entidades;

namespace SEGU_JC.Controllers
{
    public class UsuarioController : Controller
    {
        M_USUARIO oM_USUARIO = new M_USUARIO();

        public ActionResult Ingresar()
        {
            return View("Usuario");
        }

        public JsonResult fn_Listar(string CO_USUA)
        {
           //var sDE_CARA = "";
           List<clsEN_USUARIO> lUsuario = new List<clsEN_USUARIO>();
           lUsuario = oM_USUARIO.fn_MOST_USUA(CO_USUA);
           return Json(lUsuario, JsonRequestBehavior.AllowGet);
        }

        
    }
}
