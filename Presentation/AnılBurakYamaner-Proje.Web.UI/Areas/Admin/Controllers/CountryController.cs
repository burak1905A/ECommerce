using AnılBurakYamaner_Proje.Common.Dtos.Country;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Models.CountryViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class CountryController : Controller
    {
        private readonly ICountryApi _countryApi;
        private readonly IMapper _mapper;

        public CountryController(
            ICountryApi countryApi,
            IMapper mapper)
        {
            _countryApi = countryApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CountryViewModel> list = new List<CountryViewModel>();
            var listResult = await _countryApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CountryViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCountryViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _countryApi.Post(_mapper.Map<CountryRequestDto>(item));
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
            UpdateCountryViewModel model = new UpdateCountryViewModel();
            var updateResult = await _countryApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateCountryViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCountryViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _countryApi.Put(item.Id, _mapper.Map<CountryRequestDto>(item));
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
            var deleteResult = await _countryApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _countryApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}

