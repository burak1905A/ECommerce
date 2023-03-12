using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.Product;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AnılBurakYamaner_Proje.Service.Repository.OrderItem;
using Microsoft.EntityFrameworkCore;
using AnılBurakYamaner_Proje.Common.Dtos.OrderItem;
using AnılBurakYamaner_Proje.Common.Dtos.Location;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("orderItem")]

    public class OrderItemController : BaseApiController<OrderItemController>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderItemResponseDto>>>> GetOrderItems()
        {

            var orderItemResult = _mapper.Map<List<OrderItemResponseDto>>(await _orderItemRepository.TableNoTracking.ToListAsync());
            if (orderItemResult.Count > 0)
                return new WebApiResponse<List<OrderItemResponseDto>>(true, "Success", orderItemResult);
            else
                return new WebApiResponse<List<OrderItemResponseDto>>(false, "Error");
        }


        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderItemResponseDto>>> GetOrderItem(Guid id)
        {

            var orderItemResult = _mapper.Map<OrderItemResponseDto>(await _orderItemRepository.GetById(id));
            if (orderItemResult != null)
                return new WebApiResponse<OrderItemResponseDto>(true, "Success", orderItemResult);
            else
                return new WebApiResponse<OrderItemResponseDto>(false, "Error");
        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderItemResponseDto>>> PostOrderItem(OrderItemRequestDto request)
        {
            OrderItem orderItem = _mapper.Map<OrderItem>(request);
            var insertResult = await _orderItemRepository.Add(orderItem);
            if (insertResult != null)
            {
                OrderItemResponseDto rm = _mapper.Map<OrderItemResponseDto>(insertResult);
                return new WebApiResponse<OrderItemResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<OrderItemResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemResponseDto>>> PutOrderItem(Guid id,
            OrderItemRequestDto request)
        {

            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderItem entity = await _orderItemRepository.GetById(id);
                if (entity == null)
                    return NotFound();


                _mapper.Map(request, entity);

                var updateResult = await _orderItemRepository.Update(entity);
                if (updateResult != null)
                {
                    OrderItemResponseDto rm = _mapper.Map<OrderItemResponseDto>(updateResult);
                    return new WebApiResponse<OrderItemResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<OrderItemResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemResponseDto>>> DeleteOrderItem(Guid id)
        {
            var orderItem = await _orderItemRepository.GetById(id);
            if (orderItem != null)
            {
                if (await _orderItemRepository.Remove(orderItem))
                    return new WebApiResponse<OrderItemResponseDto>(true, "Success", _mapper.Map<OrderItemResponseDto>(orderItem));
                else
                    return new WebApiResponse<OrderItemResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<OrderItemResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateOrderItem(Guid id)
        {
            bool result = await _orderItemRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderItemResponseDto>>>> GetActiveOrderItems()
        {
            var orderItemResult = _mapper.Map<List<OrderItemResponseDto>>(await _orderItemRepository.GetActive().ToListAsync());
            if (orderItemResult.Count > 0)
                return new WebApiResponse<List<OrderItemResponseDto>>(true, "Success", orderItemResult);
            else
                return new WebApiResponse<List<OrderItemResponseDto>>(false, "Error");
        }

        [HttpGet("GetByOrderId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderItemResponseDto>>>> GetByOrderId(Guid id)
        {
            var postLists = await _orderItemRepository.GetDefault(x => x.OrderId == id).ToListAsync();
            if (postLists.Count > 0)
                return new WebApiResponse<List<OrderItemResponseDto>>(true, "Success", _mapper.Map<List<OrderItemResponseDto>>(postLists));
            return new WebApiResponse<List<OrderItemResponseDto>>(false, "Error");
        }

        [HttpGet("GetByProductId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderItemResponseDto>>>> GetByProductId(Guid id)
        {
            var postLists = await _orderItemRepository.GetDefault(x => x.ProductId == id).ToListAsync();
            if (postLists.Count > 0)
                return new WebApiResponse<List<OrderItemResponseDto>>(true, "Success", _mapper.Map<List<OrderItemResponseDto>>(postLists));
            return new WebApiResponse<List<OrderItemResponseDto>>(false, "Error");
        }
    }
}
