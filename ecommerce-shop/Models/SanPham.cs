//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ecommerce_shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            HinhAnh = "~/Content/Imgs/products/add.png";
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
    
        public int ID { get; set; }
        public string TenSanPham { get; set; }
        public int idKieu { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public int GiaBan { get; set; }
        public string HinhAnh { get; set; }
        public string GhiChu { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual Kieu Kieu { get; set; }
    }
}
