using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SERVER_ADEN.DataAccess.objects;
using System.Data.SqlClient;
using SERVER_ADEN.Utils;

namespace SERVER_ADEN.DataAccess.data
{
    public class LoaiNhanVienDB
    {
        public LoaiNhanVienDB() { }

        /// <summary>
        /// Thêm loại nhân viên
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public static bool themLoaiNhanVien(LoaiNhanVienOBJ obj)
        //{
        //    try
        //    {

        //        int result =  Util.db.ExecuteNonQuery(Procedures.ThemLoaiNhanVien(obj.TenLoaiNhanVien));
        //        return result > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        string err = ex.Message;
        //        return false;
        //    }
        //}

        //public static bool getLoaiNhanVienTheoID(int id)
        //{
        //    try
        //    {
        //        return Util.db.ExecuteNonQuery(Procedures.GetLoaiNhanVienTheoID(id)) > 0;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}