using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEGU_ENTI.Entidades;

namespace SEGU_ENTI.Interfaz
{
    public interface IEN_USUARIO
    {
        List<clsEN_USUARIO> fn_Login(string sCO_USUA, string sDE_PASS);

        List<clsEN_USUARIO> fn_MOST_USUA(string sCO_USUA);

    }
}
