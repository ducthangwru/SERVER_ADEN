using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.objects
{
    public class SiteOBJ
    {
        public int id { get; set; }
        public string tensite { get; set; }
        public string diachi { get; set; }
        public string sodienthoai { get; set; }
        public List<MatBangOBJ> dsmatbang { get; set; }
    }
}