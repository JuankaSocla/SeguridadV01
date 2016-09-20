using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEGU_ENTI.Entidades;

namespace SEGU_ENTI.Interfaz
{
    public interface IEN_SEGU_SIST
    {

        List<clsSEGU_SIST> fn_CARG_MENU(string CO_USUA, int ID_OPCI);

    }
}
