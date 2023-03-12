using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Category;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.Category;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("category")]
   
    public class CategoryController : BaseApiController<CategoryController>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(
           ICategoryRepository categoryRepository,
           IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CategoryResponseDto>>>> GetCategories()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var categoryResult = _mapper.Map<List<CategoryResponseDto>>(await _categoryRepository.GetByDefault
            //(x => x.Id != System.Guid.Empty));
            var categoryResult = _mapper.Map<List<CategoryResponseDto>>(await _categoryRepository.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
                return new WebApiResponse<List<CategoryResponseDto>>(true, "Success", categoryResult);
            else
                return new WebApiResponse<List<CategoryResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CategoryResponseDto>>> GetCategory(Guid id)
        {

            var categoryResult = _mapper.Map<CategoryResponseDto>(await _categoryRepository.GetById(id));
            if (categoryResult != null)
                return new WebApiResponse<CategoryResponseDto>(true, "Success", categoryResult);
            else
                return new WebApiResponse<CategoryResponseDto>(false, "Error");
        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CategoryResponseDto>>> PostCategory(CategoryRequestDto request)
        {
            Category category = _mapper.Map<Category>(request);
            var insertResult = await _categoryRepository.Add(category);
            if (insertResult != null)
            {
                CategoryResponseDto rm = _mapper.Map<CategoryResponseDto>(insertResult);
                return new WebApiResponse<CategoryResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<CategoryResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponseDto>>> PutCategory(Guid id,
           CategoryRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                Category entity = await _categoryRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma
                //veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _categoryRepository.Update(entity);
                if (updateResult != null)
                {
                    CategoryResponseDto rm = _mapper.Map<CategoryResponseDto>(updateResult);
                    return new WebApiResponse<CategoryResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<CategoryResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponseDto>>> DeleteCategory(Guid id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category != null)
            {
                if (await _categoryRepository.Remove(category))
                    return new WebApiResponse<CategoryResponseDto>(true, "Success", _mapper.Map<CategoryResponseDto>(category));
                else
                    return new WebApiResponse<CategoryResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<CategoryResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateCategory(Guid id)
        {
            bool result = await _categoryRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }


        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CategoryResponseDto>>>> GetActiveCategories()
        {
            var categoryResult = _mapper.Map<List<CategoryResponseDto>>(await _categoryRepository.GetActive().ToListAsync());
            if (categoryResult.Count > 0)
                return new WebApiResponse<List<CategoryResponseDto>>(true, "Success", categoryResult);
            else
                return new WebApiResponse<List<CategoryResponseDto>>(false, "Error");
        }
    }
}
