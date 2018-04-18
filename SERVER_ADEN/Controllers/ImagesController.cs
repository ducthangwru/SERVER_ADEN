using SERVER_ADEN.DataAccess.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System;

namespace SERVER_ADEN.Controllers
{
    [RoutePrefix("api/images")]
    public class ImagesController : ApiController
    {

        [Route("checklist/{id}/{idnv}")]
        [HttpPost]
        //Upload Image theo ID CheckList
        public HttpResponseMessage UploadAnhCheckList(int id, int idnv)
        {
            int idAlbum = 0;
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                        if (HttpContext.Current.Request.Files.Count > 0)
                        {
                            DateTime date = DateTime.Now;
                            string tenAlbum = "checklist: " + date.ToString("dd-MM-yyyy HH:mm:ss");
                            ImagesDB.insertAlbumTheoTenVaIDNV(tenAlbum, idnv);
                            idAlbum = ImagesDB.getIDAlbumTheoTenvaIDNV(tenAlbum, idnv);
                        }

                        for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                        {
                            var file = HttpContext.Current.Request.Files[i];

                            if (HttpContext.Current.Request.Files.GetKey(i).Equals("files") && file != null && file.ContentLength > 0)
                            {

                                int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                                var ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                                var extension = ext.ToLower();
                                if (!AllowedFileExtensions.Contains(extension))
                                {
                                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Yêu cầu tải ảnh dạng .jpg,.gif,.png.");
                                }
                                else if (file.ContentLength > MaxContentLength)
                                {

                                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Yêu cầu tải ảnh tối đa 1 Mb.");
                                }
                                else
                                {
                                    string path = HttpContext.Current.Server.MapPath("~/Images/checklist/" + file.FileName);
                                    file.SaveAs(path);
                                    ImagesDB.insertAnhBaoCaoBangIDDiaDiemIDAlbumVaPath(id, idAlbum, "/Images/checklist/" + file.FileName);
                                }
                            }
                        }

                        return Request.CreateResponse(HttpStatusCode.OK, idAlbum);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi upload ảnh!");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("suco/{iddiadiem}/{idnv}")]
        [HttpPost]
        public HttpResponseMessage UploadImageSuCo(int iddiadiem, int idnv)
        {
            int idAlbum = 0;
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    if (HttpContext.Current.Request.Files.Count > 0)
                    {
                        DateTime date = DateTime.Now;
                        string tenAlbum = "suco: " + date.ToString("dd-MM-yyyy HH:mm:ss");
                        ImagesDB.insertAlbumTheoTenVaIDNV(tenAlbum, idnv);
                        idAlbum = ImagesDB.getIDAlbumTheoTenvaIDNV(tenAlbum, idnv);
                    }

                    for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                    {
                        if (HttpContext.Current.Request.Files.GetKey(i).Equals("files"))
                        {
                            var file = HttpContext.Current.Request.Files[i];
                            if (file != null && file.ContentLength > 0)
                            {

                                int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                                var ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                                var extension = ext.ToLower();
                                if (!AllowedFileExtensions.Contains(extension))
                                {
                                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Yêu cầu tải ảnh dạng .jpg,.gif,.png.");
                                }
                                else if (file.ContentLength > MaxContentLength)
                                {
                                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Yêu cầu tải ảnh tối đa 1 Mb.");
                                }
                                else
                                {
                                    string path = HttpContext.Current.Server.MapPath("~/Images/baocao/" + file.FileName);
                                    file.SaveAs(path);
                                    ImagesDB.insertAnhBaoCaoBangIDDiaDiemIDAlbumVaPath(iddiadiem, idAlbum, "/Images/baocao/" + file.FileName);
                                }
                            }
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, idAlbum);
                }

                 return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi upload ảnh!");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        //Upload Image trong SuCo
        //public async Task<HttpResponseMessage> UpLoadAnhBaoCaoSuCo(int iddiadiem, int idnv)
        //{
        //    Dictionary<string, object> dict = new Dictionary<string, object>();
        //    try
        //    {
        //        int idAlbum = 0;
        //        string path = "";

        //        var httpRequest = HttpContext.Current.Request;
        //        if (httpRequest.Files.Count > 0)
        //        {
        //            DateTime date = DateTime.Now;
        //            string tenAlbum = "suco: " + date.ToString("dd-MM-yyyy HH:mm:ss");
        //            ImagesDB.insertAlbumTheoTenVaIDNV(tenAlbum, idnv);
        //            idAlbum = ImagesDB.getIDAlbumTheoTenvaIDNV(tenAlbum, idnv);
        //        }

        //        for (int i = 0; i < httpRequest.Files.Count; i++)
        //        {
        //            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

        //            if (httpRequest.Files.GetKey(i).Equals("files"))
        //            {
        //                var postedFile = httpRequest.Files[i];
        //                if (postedFile != null && postedFile.ContentLength > 0)
        //                {

        //                    int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

        //                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
        //                    var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
        //                    var extension = ext.ToLower();
        //                    if (!AllowedFileExtensions.Contains(extension))
        //                    {

        //                        var message = string.Format("Yêu cầu tải ảnh dạng .jpg,.gif,.png.");

        //                        dict.Add("Lỗi: ", message);
        //                        return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
        //                    }
        //                    else if (postedFile.ContentLength > MaxContentLength)
        //                    {

        //                        var message = string.Format("Yêu cầu tải ảnh tối đa 1 Mb.");

        //                        dict.Add("Lỗi: ", message);
        //                        return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
        //                    }
        //                    else
        //                    {
        //                        path = "/Images/baocao/" + postedFile.FileName;
        //                        var filePath = HttpContext.Current.Server.MapPath("~/Images/baocao/" + postedFile.FileName);

        //                        postedFile.SaveAs(filePath);
        //                        ImagesDB.insertAnhBaoCaoBangIDDiaDiemIDAlbumVaPath(iddiadiem, idAlbum, path);
        //                    }
        //                }
        //            }
        //        }
        //        return Request.CreateResponse(HttpStatusCode.OK, idAlbum);
        //    }
        //    catch (Exception ex)
        //    {
        //        var res = string.Format("Vui lòng kiểm tra lại!");
        //        dict.Add("Lỗi: ", res);
        //        return Request.CreateResponse(HttpStatusCode.NotFound, dict);
        //    }
        //}
    }
}
