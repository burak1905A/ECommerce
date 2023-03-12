using AnılBurakYamaner_Proje.Common.Dtos.Category;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CategoryViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.BrandViewModels;
using AnılBurakYamaner_Proje.Common.Dtos.Brand;
using System.Linq;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandApi _brandApi;
        private readonly IMapper _mapper;

        public BrandController(
            IBrandApi brandApi,
            IMapper mapper)
        {
            _brandApi = brandApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<BrandViewModel> list = new List<BrandViewModel>();
            var listResult = await _brandApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<BrandViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateBrandViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _brandApi.Post(_mapper.Map<BrandRequestDto>(item));
                if (insertResult.IsSuccessStatusCode &&
                    insertResult.Content.IsSuccess &&
                    insertResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!... Lütfen alanları kontrol edip tekrar deneyinzi...";
            }
            TempData["Message"] = "İşlem başarısız oldu!... Lütfen alanları kontrol edip tekrar deneyinzi...";
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            UpdateBrandViewModel model = new UpdateBrandViewModel();
            var updateResult = await _brandApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateBrandViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _brandApi.Put(item.Id, _mapper.Map<BrandRequestDto>(item));
                if (updateResult.IsSuccessStatusCode &&
                    updateResult.Content.IsSuccess &&
                    updateResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme sırasında bir hata oluştu!... " +
                        "Lütfen alanları kontrol edip tekrar deneyinzi...";
            }
            TempData["Message"] = "İşlem başarısız oldu!... Lütfen alanları kontrol edip tekrar deneyinzi...";
            return View(item);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _brandApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _brandApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}
