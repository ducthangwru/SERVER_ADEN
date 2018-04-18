using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.data
{
    public class DiaDiemDB
    {
        public DiaDiemDB() { }

        public static List<DiaDiemOBJ> getDanhSachDiaDiemTheoIDMatBang(int id)
        {
            List<DiaDiemOBJ> dsDiaDiem = null;
            try
            {
                dsDiaDiem = new List<DiaDiemOBJ>();
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetDanhSachDiaDiemTheoIDMatBang(id)).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    DiaDiemOBJ obj = new DiaDiemOBJ
                    {
                        id = (dr["id"] != null) ? int.Parse(dr["id"].ToString()) : 0,
                        id_kehoach = (dr["id_kehoach"] != null) ? int.Parse(dr["id_kehoach"].ToString()) : 0,
                        id_site = (dr["id_site"] != null) ? int.Parse(dr["id_site"].ToString()) : 0,
                        id_matbang = (dr["id_matbang"] != null) ? int.Parse(dr["id_matbang"].ToString()) : 0,
                        loaidiadiem = (dr["loaidiadiem"] != null) ? int.Parse(dr["loaidiadiem"].ToString()) : 0,
                        thoigianlamviec = (dr["thoigianlamviec"] != null) ? dr["thoigianlamviec"].ToString() : "",
                        thoigiantoida = (dr["thoigiantoida"] != null) ? float.Parse(dr["thoigiantoida"].ToString()) : 0,
                        id_thediadiem = (dr["id_thediadiem"] != null) ? dr["id_thediadiem"].ToString() : "",
                        tendiadiem =(dr["tendiadiem"] != null) ? dr["tendiadiem"].ToString() : "",
                        ghichu = (dr["ghichu"] != null) ? dr["ghichu"].ToString() : ""
                    };

                    dsDiaDiem.Add(obj);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return dsDiaDiem;
        }

        public static DiaDiemOBJ getDiaDiemTheoIDMatBang(int id)
        {
            DiaDiemOBJ obj = new DiaDiemOBJ();
            try
            {
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetDiaDiemTheoIDMatBang(id)).Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    obj = new DiaDiemOBJ
                    {
                        id = (dr["id"] != null) ? int.Parse(dr["id"].ToString()) : 0,
                        id_kehoach = (dr["id_kehoach"] != null) ? int.Parse(dr["id_kehoach"].ToString()) : 0,
                        id_site = (dr["id_site"] != null) ? int.Parse(dr["id_site"].ToString()) : 0,
                        id_matbang = (dr["id_matbang"] != null) ? int.Parse(dr["id_matbang"].ToString()) : 0,
                        loaidiadiem = (dr["loaidiadiem"] != null) ? int.Parse(dr["loaidiadiem"].ToString()) : 0,
                        thoigianlamviec = (dr["thoigianlamviec"] != null) ? dr["thoigianlamviec"].ToString() : "",
                        thoigiantoida = (dr["thoigiantoida"] != null) ? float.Parse(dr["thoigiantoida"].ToString()) : 0,
                        id_thediadiem = (dr["id_thediadiem"] != null) ? dr["id_thediadiem"].ToString() : "",
                        tendiadiem = (dr["tendiadiem"] != null) ? dr["tendiadiem"].ToString() : "",
                        ghichu = (dr["ghichu"] != null) ? dr["ghichu"].ToString() : ""
                    };
                }
            }
            catch (Exception ex)
            {
                return obj;
            }

            return obj;
        }
    }
}