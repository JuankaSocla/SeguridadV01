using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEGU_JC.Models;
using SEGU_ENTI.Entidades;

namespace SEGU_JC.Controllers
{
    public class SeguridadRolController : Controller
    {
        M_SEGU_ROLE oM_SEGU_ROLE = new M_SEGU_ROLE();

        public ActionResult Ingresar()
        {
            return View("SeguridadRol");
        }

        public JsonResult fn_Listar() 
        {
            List<clsEN_SEGU_ROLE> lSEGU_ROLE = new List<clsEN_SEGU_ROLE>();
            lSEGU_ROLE = oM_SEGU_ROLE.fn_MOST_ROLE();
            return Json(lSEGU_ROLE, JsonRequestBehavior.AllowGet);
        
        }

        public JsonResult fn_Listar_Rol(int ID_ROLE)
        {
            List<clsEN_SEGU_ROLE_DETA> lSEGU_ROLE_DETA = new List<clsEN_SEGU_ROLE_DETA>();
            lSEGU_ROLE_DETA = oM_SEGU_ROLE.fn_GRIL_PERF_SIST(ID_ROLE);
            return Json(lSEGU_ROLE_DETA, JsonRequestBehavior.AllowGet);
        }

        public JsonResult fn_ENCO_ROLE(string CO_ROLE, string NO_ROLE)
        {
            List<clsEN_SEGU_ROLE> lSEGU_ROLE = new List<clsEN_SEGU_ROLE>();
            lSEGU_ROLE = oM_SEGU_ROLE.fn_ENCO_ROLE(CO_ROLE, NO_ROLE);
            return Json(lSEGU_ROLE, JsonRequestBehavior.AllowGet);
        }

    }
}
