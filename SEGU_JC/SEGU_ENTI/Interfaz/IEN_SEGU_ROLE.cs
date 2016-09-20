using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEGU_ENTI.Entidades;

namespace SEGU_ENTI.Interfaz
{
    public interface IEN_SEGU_ROLE
    {
        List<clsEN_SEGU_ROLE> fn_MOST_ROLE();

        List<clsEN_SEGU_ROLE_DETA> fn_GRIL_PERF_SIST(int nID_ROLE);

        List<clsEN_SEGU_ROLE> fn_ENCO_ROLE(string sCO_ROLE, string sNO_ROLE);
    }
}
