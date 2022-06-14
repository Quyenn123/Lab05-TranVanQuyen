using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab05_TranVanQuyen.Models;

namespace Lab05_TranVanQuyen.Controllers
{
    public class RegisterAccountController : Controller
    {
        // GET: RegisterAccount
        MyData data = new MyData();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection, KhachHang kh)
        {
            var E_hoten = collection["hoten"];
            var E_tendangnhap = collection["tendangnhap"];
            var E_matkhau = collection["matkhau"];
            var E_matkhauxacnhan = collection["matkhau"];
            var E_email = collection["email"];
            var E_diachi = collection["diachi"];
            var E_sdt = collection["dienthoai"];
            var E_ngaysinh = String.Format(collection["ngaysinh"]);
            if (string.IsNullOrEmpty(E_matkhauxacnhan))
            {
                ViewData["NhapMKXN"] = "Nhập mật khẩu xác nhận!";
            }
            else
            {
                if (!E_matkhau.Equals(E_matkhauxacnhan))
                {
                    ViewData["MatKhauKhongTrungKhop"] = "Mật khẩu không trùng khớp!";
                }

                else
                {
                kh.hoten = E_hoten.ToString();
                kh.tendangnhap = E_tendangnhap.ToString();
                kh.matkhau = E_matkhau.ToString();
                kh.email = E_email.ToString();
                kh.diachi = E_diachi.ToString();
                kh.dienthoai = E_sdt;
                kh.ngaysinh = DateTime.Parse(E_ngaysinh);
                data.KhachHang.Add(kh);
                data.SaveChanges();
                return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}