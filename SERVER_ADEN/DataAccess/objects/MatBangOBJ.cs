using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.objects
{
    public class MatBangOBJ
    {
        public int id { get; set; }
        public string tenmatbang { get; set; }

        public ImagesOBJ anhmatbang { get;  set; }
        public List<DiaDiemOBJ> dsdiadiem { get; set; }
    }
}