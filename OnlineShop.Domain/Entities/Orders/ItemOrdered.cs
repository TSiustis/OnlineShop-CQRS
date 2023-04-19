using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Orders
{
    /// <summary>
    /// Represents the item that was ordered. If product details change, details of
    /// the product that was part of a completed order should not change.
    /// </summary>
    public class ItemOrdered
    {
        public ItemOrdered(int productId, string name, string pictureUri)
        {
            ProductId = productId;
            Name = name;
            PictureUri = pictureUri;
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string PictureUri { get; set; }
    }
}
