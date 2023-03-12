using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.ShippingAddress;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.ShippingAddress;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("shippingAddress")]
    
    public class ShippingAddressController : BaseApiController<ShippingAddressController>
    {
        private readonly IShippingAddressRepository _shippingAddressRepository;
        private readonly IMapper _mapper;

        public ShippingAddressController(IShippingAddressRepository shippingAddressRepository, IMapper mapper)
        {
            _shippingAddressRepository = shippingAddressRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<ShippingAddressResponseDto>>>> GetShippingAddresses()
        {
          
            var shippingAddressResult = _mapper.Map<List<ShippingAddressResponseDto>>(await _shippingAddressRepository.TableNoTracking.ToListAsync());
            if (shippingAddressResult.Count > 0)
                return new WebApiResponse<List<ShippingAddressResponseDto>>(true, "Success", shippingAddressResult);
            else
                return new WebApiResponse<List<ShippingAddressResponseDto>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingAddressResponseDto>>> GetShippingAddress(Guid id)
        {

            var shippingAddressResult = _mapper.Map<ShippingAddressResponseDto>(await _shippingAddressRepository.GetById(id));
            if (shippingAddressResult != null)
                return new WebApiResponse<ShippingAddressResponseDto>(true, "Success", shippingAddressResult);
            else
                return new WebApiResponse<ShippingAddressResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ShippingAddressResponseDto>>> PostShippingAddress(ShippingAddressRequestDto request)
        {
            ShippingAddress shippingAddress = _mapper.Map<ShippingAddress>(request);
            var insertResult = await _shippingAddressRepository.Add(shippingAddress);
            if (insertResult != null)
            {
                ShippingAddressResponseDto rm = _mapper.Map<ShippingAddressResponseDto>(insertResult);
                return new WebApiResponse<ShippingAddressResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<ShippingAddressResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingAddressResponseDto>>> PutShippingAddress(Guid id,
            ShippingAddressRequestDto request)
        {
           
            if (id != request.Id)
                return BadRequest();

            try
            {
                ShippingAddress entity = await _shippingAddressRepository.GetById(id);
                if (entity == null)
                    return NotFound();

               
                _mapper.Map(request, entity);

                var updateResult = await _shippingAddressRepository.Update(entity);
                if (updateResult != null)
                {
                    ShippingAddressResponseDto rm = _mapper.Map<ShippingAddressResponseDto>(updateResult);
                    return new WebApiResponse<ShippingAddressResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<ShippingAddressResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingAddressResponseDto>>> DeleteShippingAddress(Guid id)
        {
            var shippingAddress = await _shippingAddressRepository.GetById(id);
            if (shippingAddress != null)
            {
                if (await _shippingAddressRepository.Remove(shippingAddress))
                    return new WebApiResponse<ShippingAddressResponseDto>(true, "Success", _mapper.Map<ShippingAddressResponseDto>(shippingAddress));
                else
                    return new WebApiResponse<ShippingAddressResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<ShippingAddressResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateShippingAddress(Guid id)
        {
            bool result = await _shippingAddressRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ShippingAddressResponseDto>>>> GetActiveShippingAddress()
        {
            var shippingAddressResult = _mapper.Map<List<ShippingAddressResponseDto>>(await _shippingAddressRepository.GetActive().ToListAsync());
            if (shippingAddressResult.Count > 0)
                return new WebApiResponse<List<ShippingAddressResponseDto>>(true, "Success", shippingAddressResult);
            else
                return new WebApiResponse<List<ShippingAddressResponseDto>>(false, "Error");
        }
    }
}
