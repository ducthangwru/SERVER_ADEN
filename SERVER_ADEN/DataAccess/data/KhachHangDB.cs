using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.data
{
    public class KhachHangDB
    {
        public KhachHangDB() { }

        public static KhachHangOBJ getKhachHangTheoID(int id)
        {
            KhachHangOBJ obj = null;
            try
            {
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetKhachHangTheoID(id)).Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    obj = new KhachHangOBJ
                    {
                        ID_KhachHang = (dr["ID_KhachHang"] != null) ? int.Parse(dr["ID_KhachHang"].ToString()) : 0,
                        TenKhachHang = (dr["TenKhachHang"] != null) ? dr["TenKhachHang"].ToString() : "",
                        DiaChi = (dr["DiaChi"] != null) ? dr["DiaChi"].ToString() : "",
                        DienThoai = (dr["DienThoai"] != null) ? dr["DienThoai"].ToString() : "",
                        Email = (dr["Email"] != null) ? dr["Email"].ToString() : "",
                        Fax = (dr["Fax"] != null) ? dr["Fax"].ToString() : "",
                        Website = (dr["Website"] != null) ? dr["Website"].ToString() : "",
                        GhiChu = (dr["GhiChu"] != null) ? dr["GhiChu"].ToString() : "",
                        TrangThai = (dr["TrangThai"] != null) ? int.Parse(dr["TrangThai"].ToString()) : 0
                    };
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return obj;
        }
    }
}