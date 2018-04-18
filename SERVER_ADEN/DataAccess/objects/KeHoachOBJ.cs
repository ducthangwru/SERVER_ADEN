using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.objects
{
    public class KeHoachOBJ
    {
        public int id { get; set; }
        public int id_nhanvien { get; set; }
        public int id_site { get; set; }

        public SiteOBJ site { get; set; }
    }
}