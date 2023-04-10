using AnılBurakYamaner_Proje.Common.Dtos.ProductPrice;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Models.ProductPriceViewModels;
using AnılBurakYamaner_Proje.Web.UI.Models.ProductViewModels;
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
    [Area("Admin"), Authorize]
    public class ProductPriceController : Controller
    {
        private readonly IProductPriceApi _productPriceApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;


        public ProductPriceController(
            IProductPriceApi productPriceApi,
            IMapper mapper,
            IWebHostEnvironment env,
            IProductApi productApi)

        {
            _productPriceApi = productPriceApi;
            _mapper = mapper;
            _env = env;
            _productApi = productApi;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductPriceViewModel> list = new List<ProductPriceViewModel>();
            var listResult = await _productPriceApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductPriceViewModel>>(listResult.Content.ResultData);
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
        public async Task<IActionResult> Insert(CreateProductPriceViewModel item)
        {

            var insertResult = await _productPriceApi.Post(_mapper.Map<ProductPriceRequestDto>(item));
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



            UpdateProductPriceViewModel model = new UpdateProductPriceViewModel();
            var updateResult = await _productPriceApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateProductPriceViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductPriceViewModel item)
        {

            if (ModelState.IsValid)
            {
                var updateResult = await _productPriceApi.Put(item.Id, _mapper.Map<ProductPriceRequestDto>(item));
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
            var deleteResult = await _productPriceApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _productPriceApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}

