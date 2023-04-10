using AnılBurakYamaner_Proje.Common.Dtos.ProductImage;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Models.ProductImageViewModels;
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
    public class ProductImageController : Controller
    {
        private readonly IProductImageApi _productImageApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;


        public ProductImageController(
            IProductImageApi productImageApi,
            IMapper mapper,
            IWebHostEnvironment env,
            IProductApi productApi)

        {
            _productImageApi = productImageApi;
            _mapper = mapper;
            _env = env;
            _productApi = productApi;
         
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductImageViewModel> list = new List<ProductImageViewModel>();
            var listResult = await _productImageApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductImageViewModel>>(listResult.Content.ResultData);
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
        public async Task<IActionResult> Insert(CreateProductImageViewModel item)
        {

            var insertResult = await _productImageApi.Post(_mapper.Map<ProductImageRequestDto>(item));
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

           

            UpdateProductImageViewModel model = new UpdateProductImageViewModel();
            var updateResult = await _productImageApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateProductImageViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductImageViewModel item)
        {

            if (ModelState.IsValid)
            {
                var updateResult = await _productImageApi.Put(item.Id, _mapper.Map<ProductImageRequestDto>(item));
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
            var deleteResult = await _productImageApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _productImageApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}

