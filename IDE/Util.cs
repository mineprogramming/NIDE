using System.Web.Script.Serialization;

namespace NIDE
{
    public static class Util
    {
        public static type ToObject<type>(this string JSON)
        {
            return new JavaScriptSerializer().Deserialize<type>(JSON);
        }
    }
}
