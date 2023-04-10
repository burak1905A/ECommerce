using AnılBurakYamaner_Proje.Common.Dtos.Currency;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Models.CurrencyViewModels;
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
    public class CurrencyController : Controller
    {
        private readonly ICurrencyApi _currencyApi;
        private readonly IMapper _mapper;

        public CurrencyController(
            ICurrencyApi currencyApi,
            IMapper mapper)
        {
            _currencyApi = currencyApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CurrencyViewModel> list = new List<CurrencyViewModel>();
            var listResult = await _currencyApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CurrencyViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCurrencyViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _currencyApi.Post(_mapper.Map<CurrencyRequestDto>(item));
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
            UpdateCurrencyViewModel model = new UpdateCurrencyViewModel();
            var updateResult = await _currencyApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateCurrencyViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCurrencyViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _currencyApi.Put(item.Id, _mapper.Map<CurrencyRequestDto>(item));
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
            var deleteResult = await _currencyApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _currencyApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}

