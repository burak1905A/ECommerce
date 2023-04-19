using AnılBurakYamaner_Proje.Common.Dtos.Category;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CategoryViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(AuthenticationSchemes = "AdminScheme")]
    public class CategoryController : Controller
    {
        private readonly ICategoryApi _categoryApi;
        private readonly IMapper _mapper;

        public CategoryController(
            ICategoryApi categoryApi,
            IMapper mapper)
        {
            _categoryApi = categoryApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            var listResult = await _categoryApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CategoryViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _categoryApi.Post(_mapper.Map<CategoryRequestDto>(item));
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
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            UpdateCategoryViewModel model = new UpdateCategoryViewModel();
            var updateResult = await _categoryApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateCategoryViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _categoryApi.Put(item.Id, _mapper.Map<CategoryRequestDto>(item));
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
            var deleteResult = await _categoryApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _categoryApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}
