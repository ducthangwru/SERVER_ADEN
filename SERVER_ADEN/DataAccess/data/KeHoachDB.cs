using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.data
{
    public class KeHoachDB
    {
        public KeHoachDB() { }

        public static KeHoachOBJ getKeHoachTheoIDNhanVien(int id)
        {
            KeHoachOBJ kehoach = new KeHoachOBJ();
            try
            {
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetKeHoachTheoIDNhanVien(id)).Tables[0];
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