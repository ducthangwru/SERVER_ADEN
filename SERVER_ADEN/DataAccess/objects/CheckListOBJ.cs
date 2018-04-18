using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.Models
{
    public class CheckListOBJ
    {
        public int id { get; set; }
        public int id_diadiem { get; set; }
        public string giobatdau { get; set; }
        public float thoigianlamviec { get; set; }
        public string tenchecklist { get; set; }
        public string phuongphap { get; set; }
        public string yeucau { get; set; }
        public bool trangthaichupanh { get; set; }
        public int trangthai { get; set; }
    }
}