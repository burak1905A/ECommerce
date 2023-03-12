using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class Product : CoreEntity
    {
        public Product()
        {
            ProductPrices = new HashSet<ProductPrice>();

            ProductImages = new HashSet<ProductImage>();

            ProductDetails = new HashSet<ProductDetail>();

            ProductComments = new HashSet<ProductComment>();

            OrderItems = new HashSet<OrderItem>();

        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string FullName { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int? Price1 { get; set; }
        public int? Warranty { get; set; }
        public string Tax { get; set; }
        public int? StockAmount { get; set; }
        public int? Discount { get; set; }
        public string isGifted { get; set; }
        public string Gift { get; set; }

        public string ProductDetail { get; set; }
        public int? ProductPrice { get; set; }

        public User CreatedUserProduct { get; set; }
        public User ModifiedUserProduct { get; set; }


        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<ProductPrice> ProductPrices { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }

        public ICollection<ProductComment> ProductComments { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
