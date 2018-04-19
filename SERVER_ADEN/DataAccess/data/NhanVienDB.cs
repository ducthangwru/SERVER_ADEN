using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.data
{
    public class NhanVienDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public NhanVienDB() { }

        /// <summary>
        /// Lấy ID Thẻ theo tài khoản mật khẩu
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string getIDTheNhanVienTheoTK_MK(LoginOBJ obj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@teandangnhap", obj.username),
                    new SqlParameter("@matkhau", obj.password)
                };

                DataTable dt = db.ExecuteDataSet("sp_AppKsmart_Aden_GetIDTheTheoTK_MK", param).Tables[0];
                return (dt.Rows[0]["ID_TheNhanVien"] != null)  ? dt.Rows[0]["ID_TheNhanVien"].ToString() : "";
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Lấy thông tin nhân viên, kế hoạch theo ID thẻ đọc được từ NFC
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static NhanVienOBJ getNhanVienTheoIDThe(string id)
        {
            NhanVienOBJ nhanvien = null;
            try
            {

                DataTable dt = db.ExecuteDataSet("sp_AppKsmart_Aden_GetNVTheoIDThe", new SqlParameter("@idthe", id)).Tables[0];
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