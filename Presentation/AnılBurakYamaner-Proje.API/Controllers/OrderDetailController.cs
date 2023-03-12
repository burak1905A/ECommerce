using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.OrderDetail;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.OrderDetail;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("orderdetail")]

    public class OrderDetailController : BaseApiController<OrderDetailController>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<OrderDetailResponseDto>>>> GetOrderDetails()
        {

            var orderDetailResult = _mapper.Map<List<OrderDetailResponseDto>>(await _orderDetailRepository.TableNoTracking.ToListAsync());
            if (orderDetailResult.Count > 0)
                return new WebApiResponse<List<OrderDetailResponseDto>>(true, "Success", orderDetailResult);
            else
                return new WebApiResponse<List<OrderDetailResponseDto>>(false, "Error");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderDetailResponseDto>>> GetOrderDetail(Guid id)
        {

            var orderDetailResult = _mapper.Map<OrderDetailResponseDto>(await _orderDetailRepository.GetById(id));
            if (orderDetailResult != null)
                return new WebApiResponse<OrderDetailResponseDto>(true, "Success", orderDetailResult);
            else
                return new WebApiResponse<OrderDetailResponseDto>(false, "Error");
        }


        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderDetailResponseDto>>> PostOrderDetail(OrderDetailRequestDto request)
        {
            OrderDetail orderDetail = _mapper.Map<OrderDetail>(request);
            var insertResult = await _orderDetailRepository.Add(orderDetail);
            if (insertResult != null)
            {
                OrderDetailResponseDto rm = _mapper.Map<OrderDetailResponseDto>(insertResult);
                return new WebApiResponse<OrderDetailResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<OrderDetailResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderDetailResponseDto>>> PutOrderDetail(Guid id,
           OrderDetailRequestDto request)
        {

            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderDetail entity = await _orderDetailRepository.GetById(id);
                if (entity == null)
                    return NotFound();


                _mapper.Map(request, entity);

                var updateResult = await _orderDetailRepository.Update(entity);
                if (updateResult != null)
                {
                    OrderDetailResponseDto rm = _mapper.Map<OrderDetailResponseDto>(updateResult);
                    return new WebApiResponse<OrderDetailResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<OrderDetailResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderDetailResponseDto>>> DeleteOrderDetail(Guid id)
        {
            var orderDetail = await _orderDetailRepository.GetById(id);
            if (orderDetail != null)
            {
                if (await _orderDetailRepository.Remove(orderDetail))
                    return new WebApiResponse<OrderDetailResponseDto>(true, "Success", _mapper.Map<OrderDetailResponseDto>(orderDetail));
                else
                    return new WebApiResponse<OrderDetailResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<OrderDetailResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateOrderDetail(Guid id)
        {
            bool result = await _orderDetailRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderDetailResponseDto>>>> GetActiveOrderDetails()
        {
            var orderDetailResult = _mapper.Map<List<OrderDetailResponseDto>>(await _orderDetailRepository.GetActive().ToListAsync());
            if (orderDetailResult.Count > 0)
                return new WebApiResponse<List<OrderDetailResponseDto>>(true, "Success", orderDetailResult);
            else
                return new WebApiResponse<List<OrderDetailResponseDto>>(false, "Error");
        }
    }
}