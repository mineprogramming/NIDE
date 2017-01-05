using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ModPE_editor
{
    public static class Util
    {
        public static type ToObject<type>(this string JSON)
        {
            return new JavaScriptSerializer().Deserialize<type>(JSON);
        }
    }
}
