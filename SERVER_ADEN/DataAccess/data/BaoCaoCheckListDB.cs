using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.data
{
    public class BaoCaoCheckListDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();

        BaoCaoCheckListDB() { }
        public static bool themBaoCaoCheckList(BaoCaoCheckListAppOBJ obj)
        {
            try
            {
                return Util.db.ExecuteNonQuery(Procedures.InsertBaoCaoCheckList(obj)) > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static List<BaoCaoCheckListOBJ> getDanhSachBaoCaoCheckListTheoIDNhanVien(int id)
        {
            List<BaoCaoCheckListOBJ> dsCheckList = new List<BaoCaoCheckListOBJ>();
            try
            {
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetDanhSachBaoCaoCheckListTheoIDNhanVien(id)).Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    BaoCaoCheckListOBJ obj = new BaoCaoCheckListOBJ
                    {
                        id = (dr["id"] != null) ? long.Parse(dr["id"].ToString()) : 0,
                        id_checklist = (dr["id_checklist"] != null) ? int.Parse(dr["id_checklist"].ToString()) : 0,
                        path = (dr["path"] != null) ? dr["path"].ToString() : "",
                        ghichu = (dr["ghichu"] != null) ? dr["ghichu"].ToString() : "",
                        ngaytao = (dr["ngaytao"] != null) ? DateTime.Parse(dr["ngaytao"].ToString()) : DateTime.Parse("1900-01-01 00:00:00.00")
                    };

                    dsCheckList.Add(obj);
                }
            }
            catch(Exception ex)
            {
                return dsCheckList;
            }
            return dsCheckList;
        }
    }
}