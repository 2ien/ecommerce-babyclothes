using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_shop.Models
{
    public partial class User
    {
        [NotMapped]
        public string LoginErrorMessage { get; set; }
    }
}
