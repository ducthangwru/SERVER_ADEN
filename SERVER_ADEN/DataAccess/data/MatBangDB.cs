using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.data
{
    public class MatBangDB
    {
        public MatBangDB() { }

        public static MatBangOBJ getMatBangTheoID(int id)
        {
            MatBangOBJ obj = new MatBangOBJ();
            try
            {
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetMatBangTheoID(id)).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new MatBangOBJ
                    {
                        id = (dr["id"] != null) ? int.Parse(dr["id"].ToString()) : 0,
                        tenmatbang = (dr["tenmatbang"] != null) ? dr["tenmatbang"].ToString() : ""
                    };
                }
            }
            catch(Exception ex)
            {
                return obj;
            }

            return obj;
        }

        public static List<MatBangOBJ> getDanhSachMatBangTheoIDSiteVaIDNV(int id, int idnv)
        {
            List<MatBangOBJ> dsMatBang = null;
            try
            {
                dsMatBang = new List< MatBangOBJ>();
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetDanhSachMatBangTheoIDSiteVaIDNV(id, idnv)).Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    MatBangOBJ obj = new MatBangOBJ
                    {
                        id = (dr["id"] != null) ? int.Parse(dr["id"].ToString()) : 0,
                        tenmatbang = (dr["tenmatbang"] != null) ? dr["tenmatbang"].ToString() : ""
                    };

                    dsMatBang.Add(obj);
                }
            }
            catch(Exception ex)
            {
                return null;
            }

            return dsMatBang;
        }
    }
}