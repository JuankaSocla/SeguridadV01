using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAPA_NEGO;
using SEGU_ENTI;
using SEGU_ENTI.Entidades;
using SEGU_ENTI.Interfaz;
using System.Data;
using SEGU_JC.Utilitario;

namespace SEGU_JC.Models
{
    public class M_SEGU_ROLE : IEN_SEGU_ROLE
    {
        clsNEGOCIO oclsNEGOCIO = new clsNEGOCIO();
        

        public List<clsEN_SEGU_ROLE> fn_MOST_ROLE()
        {
            List<clsEN_SEGU_ROLE> lSEGU_ROLE = new List<clsEN_SEGU_ROLE>();
            DataTable dt = oclsNEGOCIO.fn_MOST_ROLE();

            if (dt!= null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lSEGU_ROLE.Add(new clsEN_SEGU_ROLE()
                        {
                            CO_ROLE = dt.Rows[i]["CO_ROLE"].ToString(),
                            DE_ROLE = dt.Rows[i]["DE_ROLE"].ToString(),
                            ES_ROLE = dt.Rows[i]["ES_ROLE"].ToString(),
                            ID_ROLE = int.Parse(dt.Rows[i]["ID_ROLE"].ToString()),
                            NO_ROLE = dt.Rows[i]["NO_ROLE"].ToString(),
                        });    
                    }
                }
            }

            return lSEGU_ROLE;
        }

        public List<clsEN_SEGU_ROLE_DETA> fn_GRIL_PERF_SIST(int nID_ROLE)
        {
            List<clsEN_SEGU_ROLE_DETA> lSEGU_ROLE_DETA = new List<clsEN_SEGU_ROLE_DETA>();
            DataTable dt = oclsNEGOCIO.fn_GRIL_PERF_SIST(nID_ROLE);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lSEGU_ROLE_DETA.Add(new clsEN_SEGU_ROLE_DETA() { 
                            ID_SIST = int.Parse(dt.Rows[i]["ID_SIST"].ToString()),
                            ID_ROLE_DETA = int.Parse(dt.Rows[i]["ID_ROLE_DETA"].ToString()),
                            ID_ROLE = int.Parse(dt.Rows[i]["ID_ROLE"].ToString()),
                            DE_SELE_01 = bool.Parse(dt.Rows[i]["DE_SELE_01"].ToString()),
                            SEGU_SIST = fn_SEGU_SIST(clsUTILITARIO.ParseNullableInt(dt.Rows[i]["ID_SIST_SUPE"] == null ? "" : dt.Rows[i]["ID_SIST_SUPE"].ToString()), dt.Rows[i]["CO_SIST"].ToString(), dt.Rows[i]["DE_SIST"].ToString())
                        });
                    }
                }
            }

            return lSEGU_ROLE_DETA;
        }

        public List<clsSEGU_SIST> fn_SEGU_SIST(int? nID_SIST_SUPE, string sCO_SIST, string sDE_SIST) 
        {
            List<clsSEGU_SIST> lSEGU_SIST = new List<clsSEGU_SIST>();
            lSEGU_SIST.Add(new clsSEGU_SIST() { 
                ID_SIST_SUPE = nID_SIST_SUPE,
                CO_SIST = sCO_SIST,
                DE_SIST = sDE_SIST
            });
            
            return lSEGU_SIST;
        }



        public List<clsEN_SEGU_ROLE> fn_ENCO_ROLE(string sCO_ROLE, string sNO_ROLE)
        {
            List<clsEN_SEGU_ROLE> lSEGU_ROLE = new List<clsEN_SEGU_ROLE>();

            DataTable dt = oclsNEGOCIO.fn_ENCO_ROLE(sCO_ROLE, sNO_ROLE);

            if (dt != null)
	        {
	            if (dt.Rows.Count > 0)
	            {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lSEGU_ROLE.Add(new clsEN_SEGU_ROLE()
                        {
                            ID_ROLE = int.Parse(dt.Rows[i]["ID_ROLE"].ToString()),
                            CO_ROLE = dt.Rows[i]["CO_ROLE"].ToString(),
                            NO_ROLE = dt.Rows[i]["NO_ROLE"].ToString(),
                            DE_ROLE = dt.Rows[i]["DE_ROLE"].ToString()
                        });        	     
                    }
	                
	            }	 
	        }

            
            return lSEGU_ROLE;
        }
    }
}