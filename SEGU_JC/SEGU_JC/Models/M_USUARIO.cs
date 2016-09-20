using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAPA_NEGO;
using SEGU_ENTI;
using SEGU_ENTI.Entidades;
using SEGU_ENTI.Interfaz;
using System.Data;

namespace SEGU_JC.Models
{
    public class M_USUARIO : IEN_USUARIO
    {
        clsNEGOCIO oclsNEGOCIO = new clsNEGOCIO();
        clsEN_PERSONA oclsEN_PERSONA = new clsEN_PERSONA();

        public List<clsEN_USUARIO> fn_MOST_USUA(string sCO_USUA)
        {
            List<clsEN_USUARIO> lUsuario = new List<clsEN_USUARIO>();
            //List<clsEN_PERSONA> lPersona;
            DataTable dt = oclsNEGOCIO.fn_MOST_USUA(sCO_USUA);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lUsuario.Add(new clsEN_USUARIO()
                        {
                            CO_USUA = dt.Rows[i]["CO_USUA"].ToString(),
                            PERSONA = fn_EN_PERSONA(dt.Rows[i]["AP_MATE_USUA"].ToString(), dt.Rows[i]["AP_PATE_USUA"].ToString(), dt.Rows[i]["NO_USUA_COMP"].ToString()),
                            SEGU_ROLE = fn_SEGU_ROLE(int.Parse(dt.Rows[i]["ID_ROLE"].ToString()), dt.Rows[i]["CO_ROLE"].ToString(), dt.Rows[i]["NO_ROLE"].ToString(), dt.Rows[i]["DE_ROLE"].ToString())
                        });
                    }
                }
            }

            return lUsuario;
        }

        public List<clsEN_PERSONA> fn_EN_PERSONA(string sAP_MATE_USUA, string sAP_PATE_USUA, string sNO_USUA_COMP) {
            List<clsEN_PERSONA> lPersona = new List<clsEN_PERSONA>();
            lPersona.Add(new clsEN_PERSONA() { 
                AP_MATE_USUA = sAP_MATE_USUA,
                AP_PATE_USUA = sAP_PATE_USUA,
                NO_USUA = sNO_USUA_COMP,
                NO_USUA_COMP = sAP_PATE_USUA + " " +  sAP_MATE_USUA + " " + sNO_USUA_COMP
            });
            return lPersona;
        }

        public List<clsEN_SEGU_ROLE> fn_SEGU_ROLE(int nID_ROLE, string sCO_ROLE, string sNO_ROLE, string sDE_ROLE) {
            List<clsEN_SEGU_ROLE> lRole = new List<clsEN_SEGU_ROLE>();
            lRole.Add(new clsEN_SEGU_ROLE() { 
                ID_ROLE = nID_ROLE,
                CO_ROLE = sCO_ROLE,
                NO_ROLE = sNO_ROLE,
                DE_ROLE = sDE_ROLE
            });
            return lRole;
        }

        public List<clsEN_USUARIO> fn_Login(string sCO_USUA, string sDE_PASS)
        {
            throw new NotImplementedException();
        }
    }
}