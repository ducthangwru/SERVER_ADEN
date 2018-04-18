using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Models;
using System.Data;
using SERVER_ADEN.Utils;

namespace SERVER_ADEN.DataAccess.data
{
    public class CheckListDB
    {
        public CheckListDB() { }

        public static List<CheckListOBJ> getDanhSachCheckListTheoIDDiaDiemVaThoiGian(int id, int day)
        {
            List<CheckListOBJ> ds = null;
            try
            {
                ds = new List<CheckListOBJ>();

                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetDanhSachCheckListTheoIDDiaDiemVaThoiGian(id, day)).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    CheckListOBJ obj = new CheckListOBJ
                    {
                        id = (dr["id"] != null) ? int.Parse(dr["id"].ToString()) : 0,
                        id_diadiem = (dr["id_diadiem"] != null) ? int.Parse(dr["id_diadiem"].ToString()) : 0,
                        giobatdau = (dr["giobatdau"] != null) ? dr["giobatdau"].ToString() : "",
                        thoigianlamviec = (dr["thoigianlamviec"] != null) ? float.Parse(dr["thoigianlamviec"].ToString()) : 0,
                        trangthaichupanh = (dr["trangthaichupanh"] != null) ? bool.Parse(dr["trangthaichupanh"].ToString()) : false,
                        tenchecklist = (dr["tenchecklist"] != null) ? dr["tenchecklist"].ToString() : "",
                        phuongphap = (dr["phuongphap"] != null) ? dr["phuongphap"].ToString() : "",
                        yeucau = (dr["yeucau"] != null) ? dr["yeucau"].ToString() : "",
                        trangthai = (dr["trangthai"] != null) ? int.Parse(dr["trangthai"].ToString()) : 0
                    };

                    ds.Add(obj);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }
    }
}