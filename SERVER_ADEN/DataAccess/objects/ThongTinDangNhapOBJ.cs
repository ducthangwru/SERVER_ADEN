using SERVER_ADEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.objects
{
    public class ThongTinDangNhapOBJ
    {
        public NhanVienOBJ nhanvien { get; set; }
        public KeHoachOBJ kehoach { get; set; }
    }
}