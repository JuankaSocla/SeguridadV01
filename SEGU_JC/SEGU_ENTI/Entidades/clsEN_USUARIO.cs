using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGU_ENTI.Entidades
{
    public class clsEN_USUARIO
    {
        public int ID_USUA { get; set; }
        public string CO_USUA { get; set; }
        public string PS_USUA { get; set; }
        public List<clsEN_PERSONA> PERSONA { get; set; }
        public List<clsEN_SEGU_ROLE> SEGU_ROLE { get; set; }

    }
}
