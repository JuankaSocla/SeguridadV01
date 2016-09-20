using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEGU_JC.Utilitario
{
    public static class clsUTILITARIO
    {
        public static int? ParseNullableInt(this string value)
        {
            if (value == null || value.Trim() == string.Empty)
            {
                return null;
            }
            else
            {
                try
                {
                    return int.Parse(value);
                }
                catch
                {
                    return null;
                }
            }
        }

        public static double? ParseNullableDouble(this string value) 
        {
            if (value == null || value.Trim() == string.Empty)
            {
                return null;
            }
            else
            {
                try
                {
                    return int.Parse(value);
                }
                catch
                {
                    return null;
                }
            }
        }
       
    }

}