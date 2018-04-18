using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.data
{
    public class HuongDanDB
    {
        public HuongDanDB() { }
        public static List<HuongDanOBJ> getDanhSachHuongDanTheoIDDiaDiem(int id)
        {
            List<HuongDanOBJ> dsHuongDan = new List<HuongDanOBJ>();
            try
            {
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetDanhSachHuongDanTheoIDDiaDiem(id)).Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    HuongDanOBJ obj = new HuongDanOBJ
                    {
                        id = (dr["id"] != null) ? int.Parse(dr["id"].ToString()) : 0,
                        id_diadiem = (dr["id_diadiem"] != null) ? int.Parse(dr["id_diadiem"].ToString()) : 0,
                        path = (dr["path"] != null) ? Util.baseURL + dr["path"].ToString() : "",
                        noidung = (dr["noidung"] != null) ? dr["noidung"].ToString() : "",
                        yeucau = (dr["yeucau"] != null) ? dr["yeucau"].ToString() : ""
                    };

                    dsHuongDan.Add(obj);
                }
                
            }
            catch (Exception ex)
            {
                return dsHuongDan;
            }

            return dsHuongDan;
        }
    }
}