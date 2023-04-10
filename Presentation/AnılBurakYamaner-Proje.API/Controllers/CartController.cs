using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.Cart;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("cart")]

    public class CartController : BaseApiController<CartController>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartController(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartResponseDto>>>> GetCarts()
        {

            var cartResult = _mapper.Map<List<CartResponseDto>>(await _cartRepository.TableNoTracking.ToListAsync());
            if (cartResult.Count > 0)
                return new WebApiResponse<List<CartResponseDto>>(true, "Success", cartResult);
            else
                return new WebApiResponse<List<CartResponseDto>>(false, "Error");
        }


        [HttpGet("query/{userId}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartResponseDto>>>> GetCartsByQuery(Guid userId)
        {

            var cartResult = _mapper.Map<List<CartResponseDto>>(await _cartRepository.GetDefault(x => x.UserId == userId && x.Locked != true, x => x.CartItems).ToListAsync());
            if (cartResult.Count > 0)
                return new WebApiResponse<List<CartResponseDto>>(true, "Success", cartResult);
            else
                return new WebApiResponse<List<CartResponseDto>>(false, "Error");
        }

        [HttpGet("query/session/{sessionId}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartResponseDto>>>> GetCartsBySession(Guid sessionId)
        {

            var cartResult = _mapper.Map<List<CartResponseDto>>(await _cartRepository.GetDefault(x => x.SessionId == sessionId && x.Locked != true, x=> x.CartItems).ToListAsync());
            if (cartResult.Count > 0)
                return new WebApiResponse<List<CartResponseDto>>(true, "Success", cartResult);
            else
                return new WebApiResponse<List<CartResponseDto>>(false, "Error");
        }


        [HttpGet("{Id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponseDto>>> GetCart(Guid Id)
        {

            var cartResult = _mapper.Map<CartResponseDto>(await _cartRepository.GetById(Id));
            if (cartResult != null)
                return new WebApiResponse<CartResponseDto>(true, "Success", cartResult);
            else
                return new WebApiResponse<CartResponseDto>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponseDto>>> PostCart(CartRequestDto request)
        {
            Cart cart = _mapper.Map<Cart>(request);
            var insertResult = await _cartRepository.Add(cart);
            if (insertResult != null)
            {
                CartResponseDto rm = _mapper.Map<CartResponseDto>(insertResult);
                return new WebApiResponse<CartResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<CartResponseDto>(false, "Error");
        }

        [HttpPut("{Id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponseDto>>> PutCart(Guid Id,
           CartRequestDto request)
        {
            if (Id != request.Id)
                return BadRequest();

            try
            {
                Cart entity = await _cartRepository.GetById(Id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _cartRepository.Update(entity);
                if (updateResult != null)
                {
                    CartResponseDto rm = _mapper.Map<CartResponseDto>(updateResult);
                    return new WebApiResponse<CartResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<CartResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{Id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponseDto>>> DeleteCart(Guid Id)
        {
            var cart = await _cartRepository.GetById(Id);
            if (cart != null)
            {
                if (await _cartRepository.Remove(cart))
                    return new WebApiResponse<CartResponseDto>(true, "Success", _mapper.Map<CartResponseDto>(cart));
                else
                    return new WebApiResponse<CartResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<CartResponseDto>(false, "Error");
        }

        [HttpGet("activate/{Id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateCart(Guid Id)
        {
            bool result = await _cartRepository.Activate(Id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartResponseDto>>>> GetActiveCarts()
        {
            var cartResult = _mapper.Map<List<CartResponseDto>>(await _cartRepository.GetActive().ToListAsync());
            if (cartResult.Count > 0)
                return new WebApiResponse<List<CartResponseDto>>(true, "Success", cartResult);
            else
                return new WebApiResponse<List<CartResponseDto>>(false, "Error");
        }
    }
}
