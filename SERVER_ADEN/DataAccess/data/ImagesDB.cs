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
    public class ImagesDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public ImagesDB() { }

        public static ImagesOBJ getAnhTheoIDMatBang(int id)
        {
            ImagesOBJ obj = new ImagesOBJ();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppKsmart_Aden_GetAnhTheoIDMatBang", new SqlParameter("@id", id)).Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    obj = new ImagesOBJ
                    {
                        imageid = (dr["imageid"] != null) ? int.Parse(dr["imageid"].ToString()) : 0,
                        path = (dr["path"] != null) ? Util.baseURL +  dr["path"].ToString() : "",
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

        //public static bool insertAnhCheckListBangIDvaPath(int id, int idalbum, string path)
        //{
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[]
        //        {
        //            new SqlParameter("@id", id),
        //            new SqlParameter("@idalbum", idalbum),
        //            new SqlParameter("@path", path)
        //        };

        //        return db.ExecuteNonQuery("sp_AppKsmart_Aden_InsertAnhCheckListBangIDPathVaIDAlbum", param) > 0;
        //    }
        //    catch(Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public static bool insertAnhBaoCaoBangIDDiaDiemIDAlbumVaPath(int iddiadiem, int idalbum, string path)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@iddiadiem", iddiadiem),
                    new SqlParameter("@idalbum", idalbum),
                    new SqlParameter("@path", path)
                };

                return db.ExecuteNonQuery("sp_AppKsmart_Aden_InsertAnhBaoCaoBangIDDiaDiemIDAlbumVaPath", param) > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool insertAlbumTheoTenVaIDNV(string ten, int id)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@idnhanvien", id),
                    new SqlParameter("@tenalbum", ten)
                };

                return db.ExecuteNonQuery("sp_AppKsmart_Aden_InsertAlbumTheoTen", param) > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static int getIDAlbumTheoTenvaIDNV(string path, int idnv)
        {
            int id = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@tenalbum", path),
                    new SqlParameter("@idnhanvien", idnv)
                };

                DataTable dt = db.ExecuteDataSet("sp_AppKsmart_Aden_GetIDAlbumTheoTenVaIDNV", param).Tables[0];
                id = int.Parse(dt.Rows[0]["id"].ToString());
            }
            catch(Exception ex)
            {
                return id;
            }

            return id;
        }
    }
}