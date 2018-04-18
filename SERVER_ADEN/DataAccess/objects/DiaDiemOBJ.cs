using SERVER_ADEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.objects
{
    public class DiaDiemOBJ
    {
        public int id { get; set; }
        public string id_thediadiem { get; set; }
        public int id_kehoach { get; set; }
        public int id_site { get; set; }
        public int id_matbang { get; set; }
        public int loaidiadiem { get; set; }
        public string tendiadiem { get; set; }
        public string thoigianlamviec { get; set; }
        public float thoigiantoida { get; set; }
        public string ghichu { get; set; }

        public List<CheckListOBJ> dschecklist { get; set; }
        public List<HuongDanOBJ> dshuongdan { get; set; }
    }
}