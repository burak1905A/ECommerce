using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Web.UI.Infrastructure.Helpers
{
    public class CartCookieModel 
    {
        public List<ProductViewModel> ProductList { get; set; }=new List<ProductViewModel>();
    }
}
