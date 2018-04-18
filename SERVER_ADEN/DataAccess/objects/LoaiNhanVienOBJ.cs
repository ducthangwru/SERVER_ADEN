using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.objects
{
    public class LoaiNhanVienOBJ
    {
        public LoaiNhanVienOBJ() { }
        public int id { get; set; }
        public string TenLoaiNhanVien { get; set; }
        public DateTime NgayTao { get; set; }
    }
}