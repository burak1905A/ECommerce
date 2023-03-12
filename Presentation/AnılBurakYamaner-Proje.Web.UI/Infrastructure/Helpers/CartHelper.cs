using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Dtos.CartItem;
using AnılBurakYamaner_Proje.Common.Dtos.Category;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnılBurakYamaner_Proje.Web.UI.Infrastructure.Helpers
{
    public class CartHelper : ICartHelper
    {

        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        private readonly ICategoryApi _categoryApi;
        public List<ProductViewModel> CartList;

        public CartHelper(ICartApi cartApi, ICartItemApi cartItemApi, ICategoryApi categoryApi)
        {
            CartList = new List<ProductViewModel>();
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
            _categoryApi = categoryApi;
        }

        #region Sepete Ekle
        public void AddCart(ProductViewModel item)
        {
            if (!CartList.Any(x => x.Id == item.Id))
                CartList.Add(item);
            else
                this.IncreaseCart(item.Id);
        }
        #endregion

        #region Sepet Arttır
        public void IncreaseCart(Guid id)
        {
            ProductViewModel productVM = CartList.Find(x => x.Id == id);
            productVM.Discount++;
        }
        #endregion

        #region Sepet Azalt
        public void DecreaseCart(Guid id)
        {
            ProductViewModel productVM = CartList.Find(x => x.Id == id);
            productVM.Discount--;
            if (productVM.Discount <= 0)
                this.RemoveCart(id);
        }
        #endregion

        #region Sepetten Sil
        public void RemoveCart(Guid id) => CartList.Remove(CartList.Find(x => x.Id == id));
        #endregion

        public CartResponseDto GetActiveCart(Guid userId)
        {
            var cart = new CartResponseDto();
            var activeCart = _cartApi.GetCartsByQuery(userId).Result;
            if (activeCart.IsSuccessStatusCode && activeCart.Content.IsSuccess)
            {
                var cartItems = new List<CartItemResponseDto>();
                if (activeCart.IsSuccessStatusCode && activeCart.Content.IsSuccess)
                {
                    var carts = activeCart.Content.ResultData;
                    cart = carts.FirstOrDefault();

                    var cartItemsResult = _cartItemApi.GetCartItemQuery(cart.Id).Result;
                    if (cartItemsResult.IsSuccessStatusCode && cartItemsResult.Content.IsSuccess)
                    {
                        cartItems = cartItemsResult.Content.ResultData;

                    }
                }
                cart.CartItems = cartItems;
            }
            return cart;
        }

        public List<CategoryResponseDto> GetCategories()
        {
            var response = new List<CategoryResponseDto>();
            var activeCart = _categoryApi.List().Result;
            if (activeCart.IsSuccessStatusCode && activeCart.Content.IsSuccess)
            {
               
                    response = activeCart.Content.ResultData;
                   
            }
            return response;
        }
    }
}