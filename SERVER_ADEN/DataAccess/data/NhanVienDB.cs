using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.data
{
    public class NhanVienDB
    {
        public NhanVienDB() { }

        public static string getIDTheNhanVienTheoTK_MK(LoginOBJ obj)
        {
            try
            {
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetIDTheTheoTK_MK(obj)).Tables[0];
                return (dt.Rows[0]["ID_TheNhanVien"] != null)  ? dt.Rows[0]["ID_TheNhanVien"].ToString() : "";
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        public static NhanVienOBJ getNhanVienTheoIDThe(string id)
        {
            NhanVienOBJ nhanvien = null;
            try
            {

                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetNhanVienTheoIDThe(id)).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    nhanvien = new NhanVienOBJ
                    {
                        ID_NhanVien = int.Parse(dr["ID_NhanVien"].ToString()),
                        ID_TheNhanVien = dr["ID_TheNhanVien"].ToString(),
                        tenloainhanvien = (dr["tenloainhanvien"] != null) ? dr["tenloainhanvien"].ToString() : "",
                        path = (dr["path"] != null) ? Util.baseURL + dr["path"].ToString() : "",
                        TenNhanVien = (dr["TenNhanVien"] != null) ? dr["TenNhanVien"].ToString() : "",
                        TenDangNhap =(dr["TenDangNhap"] != null) ? dr["TenDangNhap"].ToString() : "",
                        MatKhau = (dr["MatKhau"] != null) ? dr["MatKhau"].ToString() : ""
                    };
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return nhanvien;
        }
    }
}