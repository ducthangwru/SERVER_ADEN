using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.objects
{
    public class ChiTietKeHoachOBJ
    {
        public int id { get; set; }
        public int id_diadiem {get; set; }
        public int id_kehoach { get; set; }
        public int id_nhanvien { get; set; }
        public int id_checklist { get; set; }
    }
}