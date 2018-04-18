using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess.data
{
    public class ImagesDB
    {
        public ImagesDB() { }

        public static ImagesOBJ getAnhTheoIDMatBang(int id)
        {
            ImagesOBJ obj = new ImagesOBJ();
            try
            {
               DataTable dt = Util.db.ExecuteDataSet(Procedures.GetAnhTheoIDMatBang(id)).Tables[0];
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

        public static bool insertAnhCheckListBangIDvaPath(int id, int idalbum, string path)
        {
            try
            {
                return Util.db.ExecuteNonQuery(Procedures.InsertAnhCheckListBangIDPathVaIDAlbum(id, idalbum, path)) > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool insertAnhBaoCaoBangIDDiaDiemIDAlbumVaPath(int iddiadiem, int idalbum, string path)
        {
            try
            {
                return Util.db.ExecuteNonQuery(Procedures.InsertAnhBaoCaoBangIDDiaDiemIDAlbumVaPath(iddiadiem, idalbum, path)) > 0;
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
                return Util.db.ExecuteNonQuery(Procedures.InsertAlbumTheoTen(ten, id)) > 0;
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
                DataTable dt = Util.db.ExecuteDataSet(Procedures.GetIDAlbumTheoTenVaIDNV(path, idnv)).Tables[0];
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