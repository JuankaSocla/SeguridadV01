using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEGU_JC.Models;
using SEGU_ENTI.Entidades;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using FNT_BusinessEntities.Interface;

namespace SEGU_JC.Controllers
{
    public class HomeController : Controller
    {
        clsEN_USUARIO oclsEN_USUARIO = new clsEN_USUARIO();
        M_PERSONA oM_PERSONA = new M_PERSONA();

        //
        // GET: /Home/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        //public async Task<ActionResult> Login()
        //{
        //    var httpClient = new HttpClient();
        //    //var json = await httpClient.GetStringAsync("https://webservicedesa.upc.edu.pe/v2///AutenticaUsuario?CodUsuario=hrisco&Contrasena=Cibertec17");
        //    var json = await httpClient.GetStringAsync("http://chprov227-026/ServiciosGAF/v2///DocenteCarreras?//CodLineaNegocio=U&CodModalidadEstudio=FC&CodDocente=4658&CodPeriodo=201500&CodProducto=033100/18"/);
        //
        //    var continentList = JsonConvert.DeserializeObject<List<DTODocenteCarreras>>(json);
        //
        //
        //    return View();
        //}

        [HttpGet]
        public ActionResult Base()
        {
            //Session["CO_USUA"] = "JCASTROSO";
            //Session["NO_USUA"] = "JUAN CARLOS CASTRO SOCLA";
            ViewBag.CO_USUA = Session["CO_USUA"];// == "" ? "" : Session["CO_USUA"].ToString();
            ViewBag.NO_USUA = Session["NO_USUA"];// == "" ? "" : Session["NO_USUA"].ToString();
            return View("Base");
        }

        
        [HttpPost]
        public JsonResult fn_Ingresa(string CO_USUA, string DE_PASS)
        {
            List<clsEN_USUARIO> lstEN_USUARIO = new List<clsEN_USUARIO>();
            lstEN_USUARIO = oM_PERSONA.fn_Login(CO_USUA, DE_PASS);
            if (lstEN_USUARIO.Count > 0)
            {
                Session["CO_USUA"] = lstEN_USUARIO[0].CO_USUA;
                Session["NO_USUA"] = lstEN_USUARIO[0].PERSONA[0].NO_USUA.ToUpper();    
            }
          
            return Json(lstEN_USUARIO,JsonRequestBehavior.AllowGet);
        }

        


    }
}
