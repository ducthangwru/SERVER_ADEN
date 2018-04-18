using SERVER_ADEN.DataAccess.data;
using SERVER_ADEN.DataAccess.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SERVER_ADEN.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        [Route("suco")]
        [HttpPost]
        public HttpResponseMessage themBaoCaoSuCo([FromBody] BaoCaoSuCoAppOBJ obj)
        {
            try
            {
                if (BaoCaoSuCoDB.themBaoCaoSuCo(obj))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Thêm báo cáo sự cố thành công!");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.PaymentRequired, "Gửi lên sai rồi!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("suco/{id}")]
        [HttpGet]
        public HttpResponseMessage getDanhSachBaoCaoSuCoTheoNhanVien(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, BaoCaoSuCoDB.getDanhSachBaoCaoSuCoTheoIDNhanVien(id));
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("checklist")]
        [HttpPost]
        public HttpResponseMessage theoCheckList([FromBody] BaoCaoCheckListAppOBJ obj)
        {
            try
            {
                if (BaoCaoCheckListDB.themBaoCaoCheckList(obj))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Thêm báo cáo checklist thành công!");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.PaymentRequired, "Gửi lên sai rồi!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("checklist/{id}")]
        [HttpGet]
        public HttpResponseMessage getDanhSachBaoCaoCheckListTheoNhanVien(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, BaoCaoCheckListDB.getDanhSachBaoCaoCheckListTheoIDNhanVien(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
