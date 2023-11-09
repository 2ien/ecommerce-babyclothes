using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce_shop.Models
{
    public class mapNhaCungCap
    {
        public List<NhaCungCap> DanhSach()
        {
            //1.Lấy dữ liệu
            //Khai báo db
            var db = new DBQLEcommerceShopEntities();
            //Lấy dữ liệu thông qua thuộc tính bảng 
            var data = db.NhaCungCaps.ToList();
            return data;
        }
        
    }
}