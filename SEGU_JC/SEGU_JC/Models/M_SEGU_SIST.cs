using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEGU_ENTI;
using SEGU_ENTI.Interfaz;
using SEGU_ENTI.Entidades;
using System.Data;
using CAPA_NEGO;
using SEGU_JC.Utilitario;


namespace SEGU_JC.Models
{
    public class M_SEGU_SIST : IEN_SEGU_SIST
    {
        clsNEGOCIO oclsNEGOCIO = new clsNEGOCIO();
        //clsUTILITARIO oclsUTILITARIO = new clsUTILITARIO();
        public List<clsSEGU_SIST> fn_CARG_MENU(string CO_USUA, int ID_OPCI)
        {
            
            List<clsSEGU_SIST> lSEGU_SIST = new List<clsSEGU_SIST>();
            DataTable dt = oclsNEGOCIO.fn_MOST_PANT_MENU(CO_USUA, ID_OPCI);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lSEGU_SIST.Add(new clsSEGU_SIST() {
                        ID_SIST = int.Parse(dt.Rows[i]["ID_SIST"].ToString()),
                        CO_SIST = dt.Rows[i]["CO_SIST"].ToString(),
                        DE_SIST = dt.Rows[i]["DE_SIST"].ToString(),
                        IMG_SIST = dt.Rows[i]["IMG_SIST"].ToString(),
                        SEGU_OPCI = fn_OPCI(int.Parse(dt.Rows[i]["ID_OPCI"].ToString()), clsUTILITARIO.ParseNullableInt(dt.Rows[i]["ID_OPCI_SUPE"].ToString()), dt.Rows[i]["CO_OPCI"].ToString(), dt.Rows[i]["NO_OPCI"].ToString(), dt.Rows[i]["NO_OPCI_LARG"].ToString(), dt.Rows[i]["DI_OPCI"].ToString(), dt.Rows[i]["DI_OPCI_RAZOR"].ToString())
                    });
                }
            }

            return lSEGU_SIST;
        }

        public List<clsSEGU_OPCI> fn_OPCI(int ID_OPCI, int? ID_OPCI_SUPE, string CO_OPCI, string NO_OPCI, string NO_OPCI_LARG, string DI_OPCI, string DI_OPCI_RAZOR)
        {
            List<clsSEGU_OPCI> lSEGU_OPCI = new List<clsSEGU_OPCI>();
            lSEGU_OPCI.Add(new clsSEGU_OPCI() {
                ID_OPCI = ID_OPCI,
                ID_OPCI_SUPE = ID_OPCI_SUPE,
                CO_OPCI = CO_OPCI,
                NO_OPCI = NO_OPCI,
                NO_OPCI_LARG = NO_OPCI_LARG,
                DI_OPCI = DI_OPCI,
                DI_OPCI_RAZOR = DI_OPCI_RAZOR
            });
            return lSEGU_OPCI;
        }

    }
}