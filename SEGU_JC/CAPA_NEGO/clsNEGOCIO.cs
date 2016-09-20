using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CAPA_DATOS;

namespace CAPA_NEGO
{
    public class clsNEGOCIO
    {
        clsDATOS oclsDATOS = new clsDATOS();

        public DataTable fn_LOGU_USUA(string sCO_USUA, string sDE_PASS)
        {
            return oclsDATOS.fn_LOGU_USUA(sCO_USUA, sDE_PASS);
        }

        public DataTable fn_MOST_PANT_MENU(string sCO_USUA, int nID_OPCI)
        {
            return oclsDATOS.fn_MOST_PANT_MENU(sCO_USUA, nID_OPCI);
        }

        public DataTable fn_MOST_USUA(string sCO_USUA)
        {
            return oclsDATOS.fn_MOST_USUA(sCO_USUA);
        }

        public DataTable fn_MOST_ROLE()
        {
            return oclsDATOS.fn_MOST_ROLE();
        }

        public DataTable fn_GRIL_PERF_SIST(int nID_ROLE)
        {
            return oclsDATOS.fn_GRIL_PERF_SIST(nID_ROLE);
        }

        public DataTable fn_ENCO_ROLE(string sCO_ROLE, string sNO_ROLE)
        {
            return oclsDATOS.fn_ENCO_ROLE(sCO_ROLE, sNO_ROLE);
        }
    }
}
