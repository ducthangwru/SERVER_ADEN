using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.objects
{
    public class NhanVienOBJ
    {
        public int ID_NhanVien { get; set; }
        public string ID_TheNhanVien { get; set; }
        public string tenloainhanvien { get; set; }
        public string path { get; set; }
        public string TenNhanVien { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
    }
}