using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce_shop.Models
{
    public class CartItem
    {
        public SanPham _sanpham { get; set; }
        public int _quantity { get; set; }
    }

    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(SanPham _pro, int _quan = 1)
        {
            var item = Items.FirstOrDefault(s => s._sanpham.ID == _pro.ID);
            if (item == null)
                items.Add(new CartItem
                {
                    _sanpham = _pro,
                    _quantity = _quan
                });
            else
                item._quantity += _quan;//Tong so luong trong gio hang duoc cong don
        }
        public int ToTal_Quantity()
        {
            return items.Sum(s => s._quantity);
        }
        public decimal Total_Money()
        {
            var total = items.Sum(s => s._quantity * s._sanpham.GiaBan);
            return (decimal)total;
        }
        public void Update_Quantity(int id, int _new_quan)
        {
            var item = items.Find(s=>s._sanpham.ID==id);
            if (item != null)
                item._quantity = _new_quan;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._sanpham.ID == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }

}