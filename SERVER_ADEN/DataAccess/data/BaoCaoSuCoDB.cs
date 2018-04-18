using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.data
{
    public class BaoCaoSuCoDB
    {
        BaoCaoSuCoDB() { }

        public static bool themBaoCaoSuCo(BaoCaoSuCoAppOBJ obj)
        {
            bool rs = false;
            try
            {
                return rs = Util.db.ExecuteNonQuery(Procedures.InsertBaoCaoSuCo(obj)) > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static List<BaoCaoSuCoOBJ> getDanhSachBaoCaoSuCoTheoIDNhanVien(int id)
        {
            List<BaoCaoSuCoOBJ> dsBaoCao = new List<BaoCaoSuCoOBJ>();
            try
            {
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetDanhSachBaoCaoSuCoTheoIDNhanVien(id)).Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    BaoCaoSuCoOBJ obj = new BaoCaoSuCoOBJ
                    {
                        id = (dr["id"] != null) ? int.Parse(dr["id"].ToString()) : 0,
                        tendiadiem = (dr["tendiadiem"] != null) ? dr["tendiadiem"].ToString() : "",
                        path = (dr["path"] != null) ? dr["path"].ToString() : "",
                        ghichu = (dr["ghichu"] != null) ? dr["ghichu"].ToString() : "",
                        ngaytao = (dr["ngaytao"] != null) ? DateTime.Parse(dr["ngaytao"].ToString()) : DateTime.Parse("1900-01-01 00:00:00.00")
                    };

                    dsBaoCao.Add(obj);
                }
            }
            catch(Exception ex)
            {
                return dsBaoCao;
            }

            return dsBaoCao;
        }
    }
}