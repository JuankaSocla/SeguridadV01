using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGU_ENTI.Entidades
{
    public class clsSEGU_SIST
    {
        public int ID_SIST { get; set; }
        public int? ID_SIST_SUPE { get; set; }
        public string CO_SIST { get; set; }
        public string DE_SIST { get; set; }
        public string ES_SIST { get; set; }
        public string IMG_SIST { get; set; }
        public List<clsSEGU_OPCI> SEGU_OPCI { get; set; }
        public List<clsAUDITORIA> AUDITORIA { get; set; }
    }
}
