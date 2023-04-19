using AnılBurakYamaner_Proje.Common.Dtos.ProductDetail;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductDetailViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(AuthenticationSchemes = "AdminScheme")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailApi _productDetailApi;
        private readonly IAdminProductApi _productApi;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;


        public ProductDetailController(
            IProductDetailApi productDetailApi,
            IMapper mapper,
            IWebHostEnvironment env,
            IAdminProductApi productApi)

        {
            _productDetailApi = productDetailApi;
            _mapper = mapper;
            _env = env;
            _productApi = productApi;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductDetailViewModel> list = new List<ProductDetailViewModel>();
            var listResult = await _productDetailApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductDetailViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);
            ViewBag.Products = new SelectList(list, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductDetailViewModel item)
        {

            var insertResult = await _productDetailApi.Post(_mapper.Map<ProductDetailRequestDto>(item));
            if (insertResult.IsSuccessStatusCode &&
                insertResult.Content.IsSuccess &&
                insertResult?.Content?.ResultData != null)
                return RedirectToAction("Index");
            else
                TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!... Lütfen alanları kontrol edip tekrar deneyinzi...";

            TempData["Message"] = "İşlem başarısız oldu!... Lütfen alanları kontrol edip tekrar deneyinzi...";

            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);
            ViewBag.Products = new SelectList(list, "Id", "Name");


            return View(item);
        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid id)
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);
            ViewBag.Products = new SelectList(list, "Id", "Name");



            UpdateProductDetailViewModel model = new UpdateProductDetailViewModel();
            var updateResult = await _productDetailApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateProductDetailViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDetailViewModel item)
        {

            if (ModelState.IsValid)
            {
                var updateResult = await _productDetailApi.Put(item.Id, _mapper.Map<ProductDetailRequestDto>(item));
                if (updateResult.IsSuccessStatusCode &&
                    updateResult.Content.IsSuccess &&
                    updateResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme sırasında bir hata oluştu!... Lütfen alanları kontrol edip tekrar deneyinzi...";
            }
            TempData["Message"] = "İşlem başarısız oldu!... Lütfen alanları kontrol edip tekrar deneyinzi...";
            return View(item);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _productDetailApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _productDetailApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}
