using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CONE_BASE_DATO;

namespace CAPA_DATOS
{
    public class clsDATOS
    {
        clsCO_BASE_DATO oclsCO_BASE_DATO = new clsCO_BASE_DATO();
        string sDE_CADE_CONE_IMSI = ConfigurationManager.ConnectionStrings["BD_BUSC_IMSI"].ToString();

        public DataTable fn_LOGU_USUA(string sCO_USUA, string sDE_PASS) 
        {
            try
            {
                return oclsCO_BASE_DATO.fn_CONE(sDE_CADE_CONE_IMSI, "SP_SEGU_USUA_CONE", "@SCO_USUA;@SPA_USUA", sCO_USUA, sDE_PASS);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable fn_MOST_PANT_MENU(string sCO_USUA, int nID_OPCI)
        {
            try
            {
                return oclsCO_BASE_DATO.fn_CONE(sDE_CADE_CONE_IMSI, "SP_SEGU_MOST_MENU", "@ISCO_USUA;@INID_OPCI", sCO_USUA, nID_OPCI);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable fn_MOST_USUA(string sCO_USUA)
        {
            try
            {
                return oclsCO_BASE_DATO.fn_CONE(sDE_CADE_CONE_IMSI, "SP_SEGU_MOST_USUA", "@ISCO_USUA", sCO_USUA);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable fn_MOST_ROLE()
        {
            try
            {
                return oclsCO_BASE_DATO.fn_CONE(sDE_CADE_CONE_IMSI, "SP_SEGU_MOST_ROLE", "");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// PROCEDIMIENTO QUE TE MUESTRA TODOS LOS ROLES ASOCIADOS A LOS SISTEMAS
        /// </summary>
        /// <param name="nID_ROLE"></param>
        /// <returns></returns>
        public DataTable fn_GRIL_PERF_SIST(int nID_ROLE)
        {
            try
            {
                return oclsCO_BASE_DATO.fn_CONE(sDE_CADE_CONE_IMSI,"SP_SEGU_MOST_PERF_SIST","@INID_ROLE", nID_ROLE);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ENCONTRAR ROL POR NOMBRE O DANDOLE CLICK A LA GRILLA
        /// </summary>
        /// <param name="sCO_ROLE"></param>
        /// <param name="sNO_ROLE"></param>
        /// <returns></returns>
        public DataTable fn_ENCO_ROLE(string sCO_ROLE, string sNO_ROLE) 
        {
            try
            {
                return oclsCO_BASE_DATO.fn_CONE(sDE_CADE_CONE_IMSI, "SP_SEGU_BUSC_ROLE", "@ISCO_ROLE;@ISNO_ROLE", sCO_ROLE, sNO_ROLE);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
