using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.objects
{
    public class BaoCaoCheckListOBJ
    {
        public long id { get; set; }
        public int id_checklist { get; set; }
        public string path { get; set; }
        public string ghichu { get; set; }
        public DateTime ngaytao { get; set; }
    }
}