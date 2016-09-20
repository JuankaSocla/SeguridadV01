using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEGU_JC.Models;
using SEGU_ENTI.Entidades;

namespace SEGU_JC.Controllers
{
    public class BaseController : Controller
    {
        M_SEGU_SIST oM_SEGU_SIST = new M_SEGU_SIST();

        public JsonResult fn_MENU(string CO_USUA, int ID_OPCI)
        {
            
            List<clsSEGU_SIST> lstSEGU_SIST = new List<clsSEGU_SIST>();
            lstSEGU_SIST = oM_SEGU_SIST.fn_CARG_MENU(CO_USUA, ID_OPCI);
            //if (lstEN_USUARIO.Count > 0)
            //{
            //    Session["CO_USUA"] = lstEN_USUARIO[0].CO_USUA;
            //    Session["NO_USUA"] = lstEN_USUARIO[0].PERSONA[0].NO_USUA.ToUpper();
            //}
            
            return Json(lstSEGU_SIST, JsonRequestBehavior.AllowGet);
        }


    }
}
