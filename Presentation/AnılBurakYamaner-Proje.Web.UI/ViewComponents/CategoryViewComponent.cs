using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.CategoryViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryApi _categoryApi;
        private readonly IMapper _mapper;

        public CategoryViewComponent(ICategoryApi categoryApi, IMapper mapper)
        {
            _categoryApi = categoryApi;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            var listResult = await _categoryApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CategoryViewModel>>(listResult.Content.ResultData);

            return View(list);
        }
    }
}