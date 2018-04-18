using SERVER_ADEN.DataAccess.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER_ADEN.DataAccess
{
    public class Procedures
    {
        public Procedures() { }
        public static string ThemLoaiNhanVien(string s)
        {
            return "Insert into loainhanvien(tenloainhanvien) values(N'" + s + "')";
        }

        public static string GetLoaiNhanVienTheoID(int id)
        {
            return "select tenloainhanvien from LoaiNhanVien where id = " + id;
        }

        public static string GetIDTheTheoTK_MK(LoginOBJ obj)
        {
            return string.Format("select ID_TheNhanVien from NhanVien where TenDangNhap like '{0}' and MatKhau like '{1}'", obj.username, obj.password);
        }
        public static string GetNhanVienTheoIDThe(string id)
        {
            return "select ID_NhanVien, ID_TheNhanVien, tenloainhanvien,"
                + "TenNhanVien, Images.path, TenDangNhap, MatKhau from NhanVien, LoaiNhanVien, Images where ID_TheNhanVien like '" 
                + id + "' and LoaiNhanVien.id = LoaiNhanVien and Images.imageid = NhanVien.id_image";
        }

        public static string GetMatBangTheoID(int id)
        {
            return "select id, id_nhanvien, id_site, tenmatbang from MatBang where id = " + id;
        }

        public static string GetAnhTheoIDMatBang(int id)
        {
            return "select imageid, path, ghichu from Images where id_checklist is null and path like '%/Images/matbang/%' and id_matbang = " + id;
        }

        public static string GetDanhSachDiaDiemTheoIDMatBang(int id)
        {
            return "select id, id_thediadiem, id_kehoach, id_site, id_matbang, loaidiadiem, tendiadiem, thoigianlamviec, thoigiantoida, ghichu from DiaDiem where id_matbang = " + id;
        }

        public static string GetDiaDiemTheoIDMatBang(int id)
        {
            return "select id, id_thediadiem, id_kehoach, id_site, id_matbang, loaidiadiem, tendiadiem, thoigianlamviec, thoigiantoida, ghichu from DiaDiem where id_matbang = " + id;
        }

        public static string GetDanhSachMatBangTheoIDSiteVaIDNV(int id, int idnv)
        {
            return string.Format("select id, tenmatbang from MatBang where id_site = {0} and id_nhanvien like '%,{1},%'", id, idnv);
        }

        public static string GetSiteTheoID(int id)
        {
            return "select id, tensite, diachi, sodienthoai from Site where id = " + id;
        }
        
        public static string GetKhachHangTheoID(int id)
        {
            return "select ID_KhachHang, TenKhachHang, DiaChi, DienThoai, Email, Fax, Website, GhiChu, TrangThai from KhachHang where ID_KhachHang = " + id;
        }

        public static string GetDanhSachCheckListTheoIDDiaDiemVaThoiGian(int id, int day)
        {
            return string.Format("select * from CheckList where id_diadiem = {0} and lichchecklist like '%{1}%'", id, day);
        }

        public static string GetKeHoachTheoIDNhanVien(int id)
        {
            return "select * from KeHoach where id_nhanvien = " + id;
        }

        public static string GetDanhSachHuongDanTheoIDDiaDiem(int id)
        {
            return "select HuongDan.id, HuongDan.id_diadiem, Images.path, noidung, yeucau from HuongDan, Images where Images.path like '%/Images/huongdan/%' and id_image = Images.imageid and Images.id_checklist is null and HuongDan.id_diadiem = " + id;
        }

        public static string InsertBaoCaoSuCo(BaoCaoSuCoAppOBJ obj)
        {
            return string.Format("insert into BaoCaoSuCo(id_nhanvien, id_album, id_diadiem, ghichu) values({0}, {1}, {2}, N'{3}')", obj.id_nhanvien, obj.id_album, obj.id_diadiem, obj.ghichu);
        }

        public static string InsertBaoCaoCheckList(BaoCaoCheckListAppOBJ obj)
        {
            return string.Format("insert into BaoCaoCheckList(id_nhanvien, id_album, id_checklist, ghichu) values({0}, {1}, {2}, N'{3}')", obj.id_nhanvien, obj.id_album, obj.id_checklist, obj.ghichu);
        }

        public static string GetDanhSachBaoCaoSuCoTheoIDNhanVien(int id)
        {
            return string.Format("select BaoCaoSuCo.id, Images.path, DiaDiem.tendiadiem, BaoCaoSuCo.ghichu, BaoCaoSuCo.ngaytao from BaoCaoSuCo, Images, DiaDiem where BaoCaoSuCo.id_nhanvien = {0} and Images.imageid = BaoCaoSuCo.id_image and DiaDiem.id = BaoCaoSuCo.id_diadiem and DiaDiem.id_matbang is null and Images.id_checklist is null", id);
        }

        public static string GetDanhSachBaoCaoCheckListTheoIDNhanVien(int id)
        {
            return string.Format("select BaoCaoCheckList.id, BaoCaoCheckList.id_checklist, Images.path, BaoCaoCheckList.ghichu, BaoCaoCheckList.ngaytao from BaoCaoCheckList, Images where BaoCaoCheckList.id_nhanvien = {0} and Images.imageid = BaoCaoCheckList.id_image", id);
        }

        public static string InsertAnhCheckListBangIDPathVaIDAlbum(int id, int idalbum, string path)
        {
            return string.Format("insert into Images(id_checklist, id_album, path) values({0}, {1}, '{2}')", id, idalbum, path);
        }

        public static string GetIDAlbumTheoTenVaIDNV(string tenalbum, int idnv)
        {
            return string.Format("select id from AlbumImages where tenalbum like '{0}' and id_nhanvien = {1}", tenalbum, idnv);
        }

        public static string InsertAnhBaoCaoBangIDDiaDiemIDAlbumVaPath(int iddiadiem, int idalbum,string path)
        {
            return string.Format("insert into Images(id_diadiem, id_album, path) values({0}, {1}, '{2}')", iddiadiem, idalbum, path);
        }

        public static string InsertAlbumTheoTen(string ten, int id)
        {
            return string.Format("insert into AlbumImages(id_nhanvien, tenalbum) values({0}, N'{1}')", id, ten);
        }
    }
}