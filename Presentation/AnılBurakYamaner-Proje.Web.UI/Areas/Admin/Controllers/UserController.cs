using AnılBurakYamaner_Proje.Common.Dtos.User;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AnılBurakYamaner_Proje.Web.UI.Infrastructure.Helpers;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Controllers
{
   
    [Area("Admin"), Authorize]
    public class UserController : Controller
    {
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public UserController(
            IUserApi userApi,
            IMapper mapper,
            IWebHostEnvironment env)
        {
            _userApi = userApi;
            _mapper = mapper;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<UserViewModel> list = new List<UserViewModel>();
            var listResult = await _userApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<UserViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateUserViewModel item, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                bool imageResult;
                string imagePath = Upload.ImageUpload(files, _env, out imageResult);
                if (imageResult)
                    item.ImageUrl = imagePath;
                else
                {
                    TempData["Message"] = imagePath;
                    return View(item);
                }

                var insertResult = await _userApi.Post(_mapper.Map<UserRequestDto>(item));
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
            UpdateUserViewModel model = new UpdateUserViewModel();
            var updateResult = await _userApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateUserViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel item)
        {
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                var updateResult = await _userApi.Put(item.Id, _mapper.Map<UserRequestDto>(item));
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
            var deleteResult = await _userApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _userApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}

