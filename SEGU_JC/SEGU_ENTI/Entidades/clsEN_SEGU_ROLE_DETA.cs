using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGU_ENTI.Entidades
{
    public class clsEN_SEGU_ROLE_DETA
    {
        public int ID_ROLE_DETA { get; set; }

        public int ID_ROLE { get; set; }

        public int ID_SIST { get; set; }

        public string ES_ROLE_DETA { get; set; }

        public bool DE_SELE_01 { get; set; }

        public List<clsAUDITORIA> AUDITORIA { get; set; }

        public List<clsSEGU_SIST> SEGU_SIST { get; set; }

    }
}
