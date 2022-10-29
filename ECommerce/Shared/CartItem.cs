using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; } = 1;
        public int CategoryId { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public int Views { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
