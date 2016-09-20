using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEGU_ENTI;
using SEGU_ENTI.Interfaz;
using CAPA_NEGO;
using System.Data;
using System.Data.SqlClient;
using SEGU_ENTI.Entidades;
using System.Web.Mvc;

namespace SEGU_JC.Models
{
    public class M_PERSONA : IEN_USUARIO
    {
        clsNEGOCIO oclsNEGOCIO = new clsNEGOCIO();
                
        [Authorize]
        public List<clsEN_USUARIO> fn_Login(string sCO_USUA, string sDE_PASS)
        {
            //throw new NotImplementedException();
            List<clsEN_USUARIO> lEN_USUARIO = new List<clsEN_USUARIO>();
            DataTable dt = oclsNEGOCIO.fn_LOGU_USUA(sCO_USUA.ToUpper(), sDE_PASS.ToUpper());

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lEN_USUARIO.Add(
                        new clsEN_USUARIO()
                        {
                            CO_USUA = dr["CO_USUA"].ToString(),
                            ID_USUA = int.Parse(dr["ID_USUA"].ToString() == "" ? "0" : dr["ID_USUA"].ToString()),
                            PERSONA = fn_PERSONA(dr["NO_USUA"].ToString()),
                        }
                        );
                }
            }
           
            return lEN_USUARIO;

        }

        public List<clsEN_PERSONA> fn_PERSONA(string sNO_USUA) {
            List<clsEN_PERSONA> lEN_PERSONA = new List<clsEN_PERSONA>();
            lEN_PERSONA.Add(new clsEN_PERSONA() {
                NO_USUA = sNO_USUA,
            });
            return lEN_PERSONA;
        }


        public List<clsEN_USUARIO> fn_MOST_USUA(string sCO_USUA)
        {
            throw new NotImplementedException();
        }
    }
}