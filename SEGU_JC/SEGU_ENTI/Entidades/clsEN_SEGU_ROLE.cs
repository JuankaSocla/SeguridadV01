using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGU_ENTI.Entidades
{
    public class clsEN_SEGU_ROLE
    {
        public int ID_ROLE { get; set; }
        public string CO_ROLE { get; set; }
        public string NO_ROLE { get; set; }
        public string DE_ROLE { get; set; }
        public string ES_ROLE { get; set; }
        public List<clsAUDITORIA> lclsAUDITORIA { get; set; }
    }
}
