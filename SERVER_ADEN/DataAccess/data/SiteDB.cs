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
    public class SiteDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public SiteDB() { }

        /// <summary>
        /// Lấy thông tin site theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SiteOBJ getSiteTheoID(int id)
        {
            SiteOBJ obj = null;
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppKsmart_Aden_GetSiteTheoID", new SqlParameter("@id", id)).Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    obj = new SiteOBJ
                    {
                        id = (dr["id"] != null) ? int.Parse(dr["id"].ToString()) : 0,
                        tensite = (dr["tensite"] != null) ? dr["tensite"].ToString() : "",
                        diachi = (dr["diachi"] != null) ? dr["diachi"].ToString() : "",
                        sodienthoai = (dr["sodienthoai"] != null) ? dr["sodienthoai"].ToString() : ""
                    };
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return obj;
        }
    }
}