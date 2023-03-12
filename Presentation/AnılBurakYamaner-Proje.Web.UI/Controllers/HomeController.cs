using AnılBurakYamaner_Proje.Common.Dtos.Brand;
using AnılBurakYamaner_Proje.Common.Dtos.Category;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.BrandViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CategoryViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductDetailViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ICategoryApi _categoryApi;
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;
        private readonly IProductApi _productApi;
        //private readonly IProductDetailApi _productDetailApi;
        /* private readonly IBrandApi _brandApi*//*;*/
        public HomeController(
            ICategoryApi categoryApi,
            IUserApi userApi,
            IMapper mapper,
            IProductApi productApi
            //IProductDetailApi productDetailApi
            /*IBrandApi brandApi*/)
        {
            _categoryApi = categoryApi;
            _userApi = userApi;
            _mapper = mapper;
            _productApi = productApi;
            //_productDetailApi = productDetailApi;
            //_brandApi = brandApi;
        }
       
        public async Task<IActionResult> Index(Guid? categoryId)
        {
            
            List<ProductViewModel> list = new List<ProductViewModel>();
            if (categoryId == null || categoryId == Guid.Empty)
            {
                var listResult = await _productApi.GetActive();
                if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                {
                    List<ProductResponseDto> listData = listResult.Content.ResultData
                        .OrderByDescending(x => x.StockAmount)
                        .Take(100)
                        .ToList();
                    list = _mapper.Map<List<ProductViewModel>>(listData);

                }
                
            }
           else
            {
                var listResult = await _productApi.GetByCategoryId(categoryId.Value);
                if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                {
                    List<ProductResponseDto> listData = listResult.Content.ResultData
                        .OrderByDescending(x => x.StockAmount)
                        .Take(10)
                        .ToList();
                    list = _mapper.Map<List<ProductViewModel>>(listData);

                }
            }
            return View(list);
        }

        public async Task<IActionResult> Posts(Guid id)
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetByBrandId(id);
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        public async Task<IActionResult> Post(Guid id)
        {
            var getPostResult = await _productApi.ProductDetail(id);
            if (getPostResult.IsSuccessStatusCode && getPostResult.Content.IsSuccess && getPostResult.Content.ResultData != null)
            {
                ProductViewModel updateProduct = _mapper.Map<ProductViewModel>(getPostResult.Content.ResultData);
                var getUserResult = await _userApi.Get(updateProduct.UserId);
                if (getUserResult.IsSuccessStatusCode && getUserResult.Content.IsSuccess && getUserResult.Content.ResultData != null)
                {
                    UserViewModel userViewModel = _mapper.Map<UserViewModel>(getUserResult.Content.ResultData);
                    return View(Tuple.Create<ProductViewModel, UserViewModel>(updateProduct, userViewModel));
                }
            }
            return View();

        }

        //public async Task<IActionResult> ProductB(Guid id)
        //{
        //    var getProductResult = await _productApi.ProductDetail(id);
        //    if (getProductResult.IsSuccessStatusCode && getProductResult.Content.IsSuccess && getProductResult.Content.ResultData != null)
        //    {
        //        ProductViewModel updateProduct = _mapper.Map<ProductViewModel>(getProductResult.Content.ResultData);
        //        var getProductDetailResult = await _productDetailApi.Get(updateProduct.UserId);
        //        if (getProductDetailResult.IsSuccessStatusCode && getProductDetailResult.Content.IsSuccess && getProductDetailResult.Content.ResultData != null)
        //        {
        //            ProductDetailViewModel productDetailViewModel = _mapper.Map<ProductDetailViewModel>(getProductDetailResult.Content.ResultData);
        //            return View(Tuple.Create<ProductViewModel, ProductDetailViewModel>(updateProduct, productDetailViewModel));
        //        }
        //    }
        //    return View();

        //}

        //public async Task<IActionResult> Posts(Guid id)
        //{
        //    List<ProductViewModel> list = new List<ProductViewModel>();
        //    var listResult = await _productApi.GetByCategoryId(id);
        //    if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
        //        list = _mapper.Map<List<PostViewModel>>(listResult.Content.ResultData);
        //    return View(list);
        //}
        //public async Task<IActionResult> Index()
        //{
        //    List<CategoryViewModel> list = new List<CategoryViewModel>();
        //    var listResult = await _categoryApi.GetActive();
        //    if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
        //    {
        //        List<CategoryResponseDto> listData = listResult.Content.ResultData
        //            .OrderByDescending(x => x.Name)
        //            .Take(6)
        //            .ToList();
        //        list = _mapper.Map<List<CategoryViewModel>>(listData);
        //    }
        //    return View();
        //}


        //public async Task<IActionResult> Posts(Guid id)
        //{
        //   //CategoryViewModel model = new CategoryViewModel();
        //   // CategoryViewModel entity = await _categoryApi.GetById(id);
        //   // //var listResult = await _categoryApi.GetById(id);
        //    //if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
        //    //    list = _mapper.Map<List<CategoryViewModel>>(listResult.Content.ResultData);

        //    return View(list);
        //}


        //public async Task<IActionResult> Posts(Guid id)
        //{
        //    List<CategoryViewModel> list = new List<CategoryViewModel>();
        //    var listResult =  await _categoryApi.List();
        //    if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
        //        list = _mapper.Map<List<CategoryViewModel>>(listResult.Content.ResultData);
        //    return View(list);
        //}
        //public async Task<IActionResult> Index()
        //{
        //    List<BrandViewModel> list1 = new List<BrandViewModel>();
        //    var listResult1 = await _brandApi.GetActive();
        //    if (listResult1.IsSuccessStatusCode && listResult1.Content.IsSuccess && listResult1.Content.ResultData.Any())
        //    {
        //        List<BrandResponseDto> listData = listResult1.Content.ResultData
        //            .OrderByDescending(x => x.Name)
        //            .Take(3)
        //            .ToList();
        //        list1 = _mapper.Map<List<BrandViewModel>>(listData);
        //    }
        //    return View();
        //}

    }
}