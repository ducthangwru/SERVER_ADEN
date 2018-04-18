using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.objects
{
    public class ImagesOBJ
    {
        public long imageid { get; set; }
        public int id_matbang { get; set; }
        public int id_checklist { get; set; }
        public string path { get; set; }
        public string ghichu { get; set; }
    }
}