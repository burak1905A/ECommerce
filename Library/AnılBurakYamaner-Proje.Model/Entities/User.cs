using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class User : CoreEntity
    {
        public User()
        {
            CreatedUsers = new HashSet<User>();
            ModifiedUsers = new HashSet<User>();

            CreatedUserCategories = new HashSet<Category>();
            ModifiedUserCategories = new HashSet<Category>();

            Products = new HashSet<Product>();
            CreatedUserProducts = new HashSet<Product>();
            ModifiedUserProducts = new HashSet<Product>();

            CreatedUserBrands = new HashSet<Brand>();
            ModifiedUserBrands = new HashSet<Brand>();

            CreatedUserProductPrices = new HashSet<ProductPrice>();
            ModifiedUserProductPrices = new HashSet<ProductPrice>();

            CreatedUserProductImages = new HashSet<ProductImage>(); 
            ModifiedUserProductImages = new HashSet<ProductImage>();

            CreatedUserProductDetails = new HashSet<ProductDetail>();
            ModifiedUserProductDetails = new HashSet<ProductDetail>();

            CreatedUserProductComments  = new HashSet<ProductComment>();
            ModifiedUserProductComments = new HashSet<ProductComment>();

            CreatedUserMembers = new HashSet<Member>();
            ModifiedUserMembers = new HashSet<Member>();

            CreatedUserCountries = new HashSet<Country>();
            ModifiedUserCountries = new HashSet<Country>();

            CreatedUserLocations = new HashSet<Location>();
            ModifiedUserLocations = new HashSet<Location>();

            CreatedUserTowns = new HashSet<Town>();
            ModifiedUserTowns = new HashSet<Town>();

            Orders = new HashSet<Order>();
            CreatedUserOrders = new HashSet<Order>();
            ModifiedUserOrders = new HashSet<Order>();

            CreatedUserMaillists = new HashSet<Maillist>();
            ModifiedUserMaillists = new HashSet<Maillist>();

            CreatedUserShippingAddresses = new HashSet<ShippingAddress>();
            ModifiedUserShippingAddresses = new HashSet<ShippingAddress>();

            CreatedUserOrderDetails = new HashSet<OrderDetail>();
            ModifiedUserOrderDetails = new HashSet<OrderDetail>();

            CreatedUserOrderAddresses = new HashSet<OrderAddress>();
            ModifiedUserOrderAddresses = new HashSet<OrderAddress>();

            CreatedUserOrderItems = new HashSet<OrderItem>();
            ModifiedUserOrderItems = new HashSet<OrderItem>();

            Carts = new HashSet<Cart>();
            CreatedUserCarts = new HashSet<Cart>();
            ModifiedUserCarts = new HashSet<Cart>();

            CreatedUserCartItems = new HashSet<CartItem>();
            ModifiedUserCartItems = new HashSet<CartItem>();

            CreatedUserCurrencys = new HashSet<Currency>();
            ModifiedUserCurrencys = new HashSet<Currency>();

            CreatedUserCurrentAccounts = new HashSet<CurrentAccount>();
            ModifiedUserCurrentAccounts = new HashSet<CurrentAccount>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastIPAddress { get; set; }
        public DateTime? LastLogin { get; set; }

        public bool? IsAdmin { get; set; }
        public User CreatedUser { get; set; }
        public User ModifiedUser { get; set; }
        public ICollection<User> CreatedUsers { get; set; }
        public ICollection<User> ModifiedUsers { get; set; }

        public ICollection<Category> CreatedUserCategories { get; set; }
        public ICollection<Category> ModifiedUserCategories { get; set; }


        public ICollection<Product> Products { get; set; }
        public ICollection<Product> CreatedUserProducts { get; set; }
        public ICollection<Product> ModifiedUserProducts { get; set; }

        public ICollection<Brand> CreatedUserBrands { get; set; }
        public ICollection<Brand> ModifiedUserBrands { get; set; }

        public ICollection<ProductPrice> CreatedUserProductPrices { get; set; }
        public ICollection<ProductPrice> ModifiedUserProductPrices { get; set; }

        public ICollection<ProductImage> CreatedUserProductImages { get; set; }
        public ICollection<ProductImage> ModifiedUserProductImages { get; set; }

        public ICollection<ProductDetail> CreatedUserProductDetails { get; set; }
        public ICollection<ProductDetail> ModifiedUserProductDetails { get; set; }

        public ICollection<ProductComment> CreatedUserProductComments { get; set; }
        public ICollection<ProductComment> ModifiedUserProductComments{ get; set; }

        public ICollection<Member> CreatedUserMembers { get; set; }
        public ICollection<Member> ModifiedUserMembers { get; set; }

        public ICollection<Country> CreatedUserCountries { get; set; }
        public ICollection<Country> ModifiedUserCountries { get; set; }

        public ICollection<Location> CreatedUserLocations { get; set; }
        public ICollection<Location> ModifiedUserLocations { get; set; }

        public ICollection<Town> CreatedUserTowns { get; set; }
        public ICollection<Town> ModifiedUserTowns { get; set; }


        public ICollection<Order> Orders { get; set; }
        public ICollection<Order> CreatedUserOrders { get; set; }
        public ICollection<Order> ModifiedUserOrders { get; set; }

        public ICollection<Maillist> CreatedUserMaillists { get; set; }
        public ICollection<Maillist> ModifiedUserMaillists { get; set; }

        public ICollection<ShippingAddress> CreatedUserShippingAddresses { get; set; }
        public ICollection<ShippingAddress> ModifiedUserShippingAddresses { get; set; }

        public ICollection<OrderDetail> CreatedUserOrderDetails { get; set; }
        public ICollection<OrderDetail> ModifiedUserOrderDetails { get; set; }

        public ICollection<OrderItem> CreatedUserOrderItems { get; set; }
        public ICollection<OrderItem> ModifiedUserOrderItems { get; set; }

        public ICollection<OrderAddress> CreatedUserOrderAddresses { get; set; }
        public ICollection<OrderAddress> ModifiedUserOrderAddresses { get; set; }

        public ICollection<Cart> Carts { get; set; }
        public ICollection<Cart> CreatedUserCarts { get; set; }
        public ICollection<Cart> ModifiedUserCarts { get; set; }

        public ICollection<CartItem> CreatedUserCartItems { get; set; }
        public ICollection<CartItem> ModifiedUserCartItems { get; set; }

        public ICollection<Currency> CreatedUserCurrencys { get; set; }
        public ICollection<Currency> ModifiedUserCurrencys { get; set; }

        public ICollection<CurrentAccount> CreatedUserCurrentAccounts { get; set; }
        public ICollection<CurrentAccount> ModifiedUserCurrentAccounts { get; set; }

    }
}
