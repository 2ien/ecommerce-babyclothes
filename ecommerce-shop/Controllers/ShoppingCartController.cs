using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using ecommerce_shop.Models;
namespace ecommerce_shop.Controllers
{
  
    public class ShoppingCartController : Controller
    {
        DBQLEcommerceShopEntities1 db = new DBQLEcommerceShopEntities1();
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
            Cart _cart = Session["Cart"] as Cart;
            if (_cart == null || Session["Cart"] == null)
            {
                _cart = new Cart();
                Session["Cart"] = _cart;
            }
            return _cart;
        }
        public ActionResult AddtoCart(int id)
        {
            var pro = db.SanPhams.SingleOrDefault(s => s.ID == id);
            if(pro!= null)
            {
                GetCart().Add(pro);
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
    
    }
}