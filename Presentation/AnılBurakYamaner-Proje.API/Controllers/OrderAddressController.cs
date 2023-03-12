using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.OrderAddress;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.OrderAddress;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("orderaddress")]
    
    public class OrderAddressController : BaseApiController<OrderAddressController>
    {
        private readonly IOrderAddressRepository _orderAddressRepository;
        private readonly IMapper _mapper;

        public OrderAddressController(IOrderAddressRepository orderAddressRepository, IMapper mapper)
        {
            _orderAddressRepository = orderAddressRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<OrderAddressResponseDto>>>> GetOrderAddresses()
        {
           
            var orderAddressResult = _mapper.Map<List<OrderAddressResponseDto>>(await _orderAddressRepository.TableNoTracking.ToListAsync());
            if (orderAddressResult.Count > 0)
                return new WebApiResponse<List<OrderAddressResponseDto>>(true, "Success", orderAddressResult);
            else
                return new WebApiResponse<List<OrderAddressResponseDto>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponseDto>>> GetOrderAddress(Guid id)
        {

            var orderAddressResult = _mapper.Map<OrderAddressResponseDto>(await _orderAddressRepository.GetById(id));
            if (orderAddressResult != null)
                return new WebApiResponse<OrderAddressResponseDto>(true, "Success", orderAddressResult);
            else
                return new WebApiResponse<OrderAddressResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponseDto>>> PostOrderAddress(OrderAddressRequestDto request)
        {
            OrderAddress orderAddress = _mapper.Map<OrderAddress>(request);
            var insertResult = await _orderAddressRepository.Add(orderAddress);
            if (insertResult != null)
            {
                OrderAddressResponseDto rm = _mapper.Map<OrderAddressResponseDto>(insertResult);
                return new WebApiResponse<OrderAddressResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<OrderAddressResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponseDto>>> PutOrderAddress(Guid id,
            OrderAddressRequestDto request)
        {
            
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderAddress entity = await _orderAddressRepository.GetById(id);
                if (entity == null)
                    return NotFound();

               
                _mapper.Map(request, entity);

                var updateResult = await _orderAddressRepository.Update(entity);
                if (updateResult != null)
                {
                    OrderAddressResponseDto rm = _mapper.Map<OrderAddressResponseDto>(updateResult);
                    return new WebApiResponse<OrderAddressResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<OrderAddressResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponseDto>>> DeleteOrderAddress(Guid id)
        {
            var orderAddress = await _orderAddressRepository.GetById(id);
            if (orderAddress != null)
            {
                if (await _orderAddressRepository.Remove(orderAddress))
                    return new WebApiResponse<OrderAddressResponseDto>(true, "Success", _mapper.Map<OrderAddressResponseDto>(orderAddress));
                else
                    return new WebApiResponse<OrderAddressResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<OrderAddressResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateOrderAddress(Guid id)
        {
            bool result = await _orderAddressRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderAddressResponseDto>>>> GetActiveOrderAddresses()
        {
            var orderAddressResult = _mapper.Map<List<OrderAddressResponseDto>>(await _orderAddressRepository.GetActive().ToListAsync());
            if (orderAddressResult.Count > 0)
                return new WebApiResponse<List<OrderAddressResponseDto>>(true, "Success", orderAddressResult);
            else
                return new WebApiResponse<List<OrderAddressResponseDto>>(false, "Error");
        }
    }
}
