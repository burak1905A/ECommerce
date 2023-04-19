using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IUserProductApi _productApi;
        private readonly IMapper _mapper;

        public ProductViewComponent(IUserProductApi productApi, IMapper mapper)
        {
            _productApi = productApi;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(
                    listResult.Content.ResultData.OrderByDescending(x => x.StockAmount).Take(10).ToList());

            return View(list);
        }
    }
}
