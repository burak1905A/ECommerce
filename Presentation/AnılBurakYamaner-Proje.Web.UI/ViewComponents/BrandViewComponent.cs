using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.BrandViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.ViewComponents
{
    public class BrandViewComponent : ViewComponent
    {
        private readonly IBrandApi _brandApi;
        private readonly IMapper _mapper;

        public BrandViewComponent(IBrandApi brandApi, IMapper mapper)
        {
            _brandApi = brandApi;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BrandViewModel> list = new List<BrandViewModel>();
            var listResult = await _brandApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<BrandViewModel>>(listResult.Content.ResultData);

            return View(list);
        }
    }
}

