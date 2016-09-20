using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGU_ENTI.Entidades
{
    public class clsSEGU_OPCI
    {
        public int ID_OPCI { get; set; }
        public int? ID_OPCI_SUPE { get; set; }
        public string CO_OPCI { get; set; }
        public string NO_OPCI { get; set; }
        public string NO_OPCI_LARG { get; set; }
        public string DI_OPCI { get; set; }
        public string DI_OPCI_RAZOR { get; set; }
        public string ES_OPCI { get; set; }
        public int NU_NIVE { get; set; }
        public List<clsAUDITORIA> AUDITORIA { get; set; }

    }
}
