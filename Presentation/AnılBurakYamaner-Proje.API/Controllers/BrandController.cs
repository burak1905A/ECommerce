using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Brand;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.Brand;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("brand")]

    public class BrandController : BaseApiController<BrandController>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandController(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<BrandResponseDto>>>> GetBrands()
        {
            
            var brandResult = _mapper.Map<List<BrandResponseDto>>(await _brandRepository.TableNoTracking.ToListAsync());
            if (brandResult.Count > 0)
                return new WebApiResponse<List<BrandResponseDto>>(true, "Success", brandResult);
            else
                return new WebApiResponse<List<BrandResponseDto>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandResponseDto>>> GetBrand(Guid id)
        {

            var brandResult = _mapper.Map<BrandResponseDto>(await _brandRepository.GetById(id));
            if (brandResult != null)
                return new WebApiResponse<BrandResponseDto>(true, "Success", brandResult);
            else
                return new WebApiResponse<BrandResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<BrandResponseDto>>> PostBrand(BrandRequestDto request)
        {
            Brand brand = _mapper.Map<Brand>(request);
            var insertResult = await _brandRepository.Add(brand);
            if (insertResult != null)
            {
                BrandResponseDto rm = _mapper.Map<BrandResponseDto>(insertResult);
                return new WebApiResponse<BrandResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<BrandResponseDto>(false, "Error");
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandResponseDto>>> PutBrand(Guid id,
            BrandRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                Brand entity = await _brandRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _brandRepository.Update(entity);
                if (updateResult != null)
                {
                    BrandResponseDto rm = _mapper.Map<BrandResponseDto>(updateResult);
                    return new WebApiResponse<BrandResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<BrandResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandResponseDto>>> DeleteBrand(Guid id)
        {
            var brand = await _brandRepository.GetById(id);
            if (brand != null)
            {
                if (await _brandRepository.Remove(brand))
                    return new WebApiResponse<BrandResponseDto>(true, "Success", _mapper.Map<BrandResponseDto>(brand));
                else
                    return new WebApiResponse<BrandResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<BrandResponseDto>(false, "Error");
        }
        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateBrand(Guid id)
        {
            bool result = await _brandRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }
        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<BrandResponseDto>>>> GetActiveBrands()
        {
            var brandResult = _mapper.Map<List<BrandResponseDto>>(await _brandRepository.GetActive().ToListAsync());
            if (brandResult.Count > 0)
                return new WebApiResponse<List<BrandResponseDto>>(true, "Success", brandResult);
            else
                return new WebApiResponse<List<BrandResponseDto>>(false, "Error");
        }
    }
     
}
