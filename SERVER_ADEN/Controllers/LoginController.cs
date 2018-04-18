using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SERVER_ADEN.DataAccess.objects;
using SERVER_ADEN.DataAccess.data;

namespace SERVER_ADEN.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage LoginIDTheNhanVien(string id)
        {
            try
            {
                return Login(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage LoginUsernameAndPassword([FromBody] LoginOBJ obj)
        {
            try
            {
                string id = NhanVienDB.getIDTheNhanVienTheoTK_MK(obj);
                return Login(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Login(string id)
        {
            ThongTinDangNhapOBJ OBJ = new ThongTinDangNhapOBJ();

            OBJ.nhanvien = NhanVienDB.getNhanVienTheoIDThe(id);

            KeHoachOBJ kehoachOBJ = KeHoachDB.getKeHoachTheoIDNhanVien(OBJ.nhanvien.ID_NhanVien);
            kehoachOBJ.site = SiteDB.getSiteTheoID(kehoachOBJ.id_site);
            kehoachOBJ.site.dsmatbang = dsMatBang(kehoachOBJ.id_site, OBJ.nhanvien.ID_NhanVien);

            OBJ.kehoach = kehoachOBJ;

            return Request.CreateResponse(HttpStatusCode.OK, OBJ);
        }
        public List<MatBangOBJ> dsMatBang(int id, int idnv)
        {
            DateTime dateNow = DateTime.Now;
            int dayNow = (int)dateNow.DayOfWeek + 1;
            List<MatBangOBJ> dsMatBangOBJ = MatBangDB.getDanhSachMatBangTheoIDSiteVaIDNV(id, idnv);
            for(int i = 0; i < dsMatBangOBJ.Count; i++)
            {
                dsMatBangOBJ[i].dsdiadiem = DiaDiemDB.getDanhSachDiaDiemTheoIDMatBang(dsMatBangOBJ[i].id);
                dsMatBangOBJ[i].anhmatbang = ImagesDB.getAnhTheoIDMatBang(dsMatBangOBJ[i].id);
                if(dsMatBangOBJ[i].dsdiadiem.Count > 0)
                {
                    dsMatBangOBJ[i].dsdiadiem[i].dschecklist = CheckListDB.getDanhSachCheckListTheoIDDiaDiemVaThoiGian(dsMatBangOBJ[i].dsdiadiem[i].id, dayNow);
                    dsMatBangOBJ[i].dsdiadiem[i].dshuongdan = HuongDanDB.getDanhSachHuongDanTheoIDDiaDiem(dsMatBangOBJ[i].dsdiadiem[i].id);
                }
            }

            return dsMatBangOBJ;
        }
    }
}
