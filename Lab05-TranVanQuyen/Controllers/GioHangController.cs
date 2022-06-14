using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab05_TranVanQuyen.Models;

namespace Lab05_TranVanQuyen.Controllers
{
    public class GiohangController : Controller
    {
        MyData data = new MyData();
        public List<Giohang> LayGiohang()
        {
            List<Giohang> listGiohang = Session["Giohang"] as List<Giohang>;
            if (listGiohang == null)
            {
                listGiohang = new List<Giohang>();
                Session["Giohang"] = listGiohang;
            }
            return listGiohang;
        }

        //--------Thêm giỏ hàng--------
        public ActionResult ThemGiohang(int id, string strURL)
        {
            List<Giohang> listGiohang = LayGiohang();
            Giohang sanpham = listGiohang.Find(n => n.id == id);
            if (sanpham == null)
            {
                sanpham = new Giohang(id);
                listGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }

        //----------Tổng ĐƠN HÀNG----------
        private int TongSoluong()
        {
            int tong = 0;
            List<Giohang> listGiohang = Session["Giohang"] as List<Giohang>;
            if (listGiohang != null)
            {
                tong = listGiohang.Sum(n => n.iSoluong);
            }
            return tong;
        }

        private int TongSoLuongSanPham()
        {
            int tong = 0;
            List<Giohang> listGiohang = Session["Giohang"] as List<Giohang>;
            if (listGiohang != null)
            {
                tong = listGiohang.Count;
            }
            return tong;
        }

        private double TongTien()
        {
            double tongtien = 0;
            List<Giohang> listGioHnag = Session["Giohang"] as List<Giohang>;
            if (listGioHnag != null)
            {
                tongtien = listGioHnag.Sum(n => n.dThanhtien);
            }
            return tongtien;
        }

        public ActionResult Giohang()
        {
            List<Giohang> listGiohang = LayGiohang();
            ViewBag.Tongsoluong = TongSoluong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(listGiohang);
        }

        public ActionResult GiohangPartial()
        {
            ViewBag.Tongsoluong = TongSoluong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }

        public ActionResult XoaGiohang(int id)
        {
            List<Giohang> listGiohang = LayGiohang();
            Giohang sanpham = listGiohang.SingleOrDefault(n => n.id == id);
            if (sanpham != null)
            {
                listGiohang.RemoveAll(n => n.id == id);
                return RedirectToAction("Giohang");
            }
            return RedirectToAction("Giohang");
        }

        public ActionResult CapnhatGiohang(int id, FormCollection collection)
        {
            List<Giohang> lstGiohang = LayGiohang();
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.id == id);
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(collection["txtSolg"].ToString());
            }
            return RedirectToAction("Giohang");
        }

        public ActionResult XoaTatCaGiohang()
        {
            List<Giohang> listGiohang = LayGiohang();
            listGiohang.Clear();
            return RedirectToAction("Giohang");
        }


        //public ActionResult DatHang()
        //{
        //    try
        //    {
        //        DonHang donHang = new DonHang();
        //        List<Giohang> listGiohang = LayGiohang();
        //        donHang = TongSoluong();
        //        donHang.SoLoai = TongSoLuongSanPham();
        //        donHang.TongTien = (decimal?)TongTien();
        //        data.Donhangs.InsertOnSubmit(donHang);
        //        data.SubmitChanges();
        //        for (int i = 0; i < listGiohang.Count; i++)
        //        {
        //            CTDH cTDH = new CTDH();
        //            cTDH.MaDon = donHang.MaDon;
        //            cTDH.masach = listGiohang[i].masach;
        //            cTDH.soluong = listGiohang[i].iSoluong;
        //            cTDH.dongia = (decimal?)listGiohang[i].giaban;
        //            data.CTDHs.InsertOnSubmit(cTDH);
        //        }
        //        //MessageBox.Show("Bạn đã đặt hàng thành công");
        //        data.SubmitChanges();
        //        XoaTatCaGiohang();
        //        TempData["mes"] = "<script> alert('Đặt hàng thành công!! Đơn hàng có mã là: " + donHang.MaDon.ToString() + "');</script>";
        //        return RedirectToAction("Index", "Home");
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        // GET: Giohang

    }
}