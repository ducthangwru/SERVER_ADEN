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
    public class KeHoachDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public KeHoachDB() { }

        /// <summary>
        /// Lấy danh sách kế hoạch theo ID Nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static KeHoachOBJ getKeHoachTheoIDNhanVien(int id)
        {
            KeHoachOBJ kehoach = new KeHoachOBJ();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppKsmart_Aden_GetKeHoachTheoIDNhanVien", new SqlParameter("@id", id)).Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    kehoach = new KeHoachOBJ
                    {
                        id = (dr["id"] != null) ? int.Parse(dr["id"].ToString()) : 0,
                        id_site = (dr["id_site"] != null) ? int.Parse(dr["id_site"].ToString()) : 0,
                        id_nhanvien = (dr["id_nhanvien"] != null) ? int.Parse(dr["id_nhanvien"].ToString()) : 0
                    };
                }
            }
            catch (Exception ex)
            {
                return kehoach;
            }

            return kehoach;
        }
    }
}