using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using ecommerce_shop.Models;
namespace ecommerce_shop.Controllers
{
  
    public class ShoppingCartController : Controller
    {
        DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
        // GET: ShoppingCart
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowCart", "ShoppingCart");
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            var _pro = db.SanPhams.SingleOrDefault(s => s.ID == id);
            if(_pro!= null)
            {
                GetCart().Add(_pro);
            }
            return RedirectToAction("ShowCart","ShoppingCart");
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_SanPham"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity(id_pro, quantity);
            return RedirectToAction("ShowCart", "ShoppingCart");

        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int total_quantity_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_quantity_item = cart.ToTal_Quantity();
            ViewBag.QuantityCart = total_quantity_item;
            return PartialView("BagCart");
        }
        public ActionResult EmptyCart()
        {
            return View();
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                HoaDon order = new HoaDon();//Bảng hoá đơn sản phẩm
                order.NgayBan = DateTime.Now;
                order.DiaChi = form["DiaChi"];
                db.HoaDons.Add(order);
                foreach (var item in cart.Items)
                {
                    ChiTietHoaDon detail = new ChiTietHoaDon();//Lưu dòng sản phẩm vào bảng chi tết hoá đơn
                    detail.idHoaDon = order.ID;
                    detail.idSanPham = item._sanpham.ID;
                    detail.DonGia = item._sanpham.GiaBan;
                    detail.SoLuong = item._quantity;
                    db.ChiTietHoaDons.Add(detail);
                    //xử lý cập nhật lại só lượng tồn trong bảng product
                    /*foreach (var p in database.Products.Where(s => s.ProductID == detail.IDProduct))
                    {
                        var updatequanpro = p.Quantity - item.quantity; //số lượng tồn mới = số lượng tồn - số lượng mua
                        p.Quantity = updatequanpro;// thực hiện cập nhật lại số lượng tồn cho cột Quantity của bảng Product
                    }*/
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckOutSuccess", "ShoppingCart");
            }
            catch
            {
                return Content("Lỗi!!! Vui lòng kiểm tra thông tin khác hàng");
            }

        }
        public ActionResult CheckOutSuccess()
        {
            return View();
        }
        public ActionResult ReCheckOut()
        {
            return View();
        }
    }
}