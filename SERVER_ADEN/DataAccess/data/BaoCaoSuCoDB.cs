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
    public class BaoCaoSuCoDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        BaoCaoSuCoDB() { }

        public static bool themBaoCaoSuCo(BaoCaoSuCoAppOBJ obj)
        {
            bool rs = false;
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@idnhanvien", obj.id_nhanvien),
                    new SqlParameter("@idalbum", obj.id_album),
                    new SqlParameter("@iddiadiem", obj.id_diadiem),
                    new SqlParameter("@ghichu", obj.ghichu)
                };

                return rs = db.ExecuteNonQuery("sp_AppKsmart_Aden_InsertBaoCaoSuCo", param) > 0;
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