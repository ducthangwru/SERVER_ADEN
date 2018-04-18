using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.Utils
{
    public class Util
    {
        public static string baseURL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "");
        public static SqlDataHelpers db = new SqlDataHelpers();
    }
}