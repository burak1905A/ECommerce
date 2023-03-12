using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.ProductImage;
using AnılBurakYamaner_Proje.Common.Dtos.ProductPrice;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.ProductPrice;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("productPrice")]
    
    public class ProductPriceController : BaseApiController<ProductPriceController>
    {
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IMapper _mapper;

        public ProductPriceController(IProductPriceRepository productPriceRepository, IMapper mapper)
        {
            _productPriceRepository = productPriceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<ProductPriceResponseDto>>>> GetProductPrices()
        {
            
            var productPriceResult = _mapper.Map<List<ProductPriceResponseDto>>(await _productPriceRepository.TableNoTracking.ToListAsync());
            if (productPriceResult.Count > 0)
                return new WebApiResponse<List<ProductPriceResponseDto>>(true, "Success", productPriceResult);
            else
                return new WebApiResponse<List<ProductPriceResponseDto>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductPriceResponseDto>>> GetProductPrice(Guid id)
        {

            var productPriceResult = _mapper.Map<ProductPriceResponseDto>(await _productPriceRepository.GetById(id));
            if (productPriceResult != null)
                return new WebApiResponse<ProductPriceResponseDto>(true, "Success", productPriceResult);
            else
                return new WebApiResponse<ProductPriceResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductPriceResponseDto>>> PostProductPrice(ProductPriceRequestDto request)
        {
            ProductPrice productPrice = _mapper.Map<ProductPrice>(request);
            var insertResult = await _productPriceRepository.Add(productPrice);
            if (insertResult != null)
            {
                ProductPriceResponseDto rm = _mapper.Map<ProductPriceResponseDto>(insertResult);
                return new WebApiResponse<ProductPriceResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<ProductPriceResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductPriceResponseDto>>> PutProductPrice(Guid id,
            ProductPriceRequestDto request)
        {
            
            if (id != request.Id)
                return BadRequest();

            try
            {
                ProductPrice entity = await _productPriceRepository.GetById(id);
                if (entity == null)
                    return NotFound();

              
                _mapper.Map(request, entity);

                var updateResult = await _productPriceRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductPriceResponseDto rm = _mapper.Map<ProductPriceResponseDto>(updateResult);
                    return new WebApiResponse<ProductPriceResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<ProductPriceResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductPriceResponseDto>>> DeleteProductPrice(Guid id)
        {
            var productPrice = await _productPriceRepository.GetById(id);
            if (productPrice != null)
            {
                if (await _productPriceRepository.Remove(productPrice))
                    return new WebApiResponse<ProductPriceResponseDto>(true, "Success", _mapper.Map<ProductPriceResponseDto>(productPrice));
                else
                    return new WebApiResponse<ProductPriceResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<ProductPriceResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateProductPrice(Guid id)
        {
            bool result = await _productPriceRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductPriceResponseDto>>>> GetActiveProductPrices()
        {
            var productPriceResult = _mapper.Map<List<ProductPriceResponseDto>>(await _productPriceRepository.GetActive().ToListAsync());
            if (productPriceResult.Count > 0)
                return new WebApiResponse<List<ProductPriceResponseDto>>(true, "Success", productPriceResult);
            else
                return new WebApiResponse<List<ProductPriceResponseDto>>(false, "Error");
        }

        [HttpGet("GetByProductId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductPriceResponseDto>>>> GetByProductId(Guid id)
        {
            var productLists = await _productPriceRepository.GetDefault(x => x.ProductId == id).ToListAsync();
            if (productLists.Count > 0)
                return new WebApiResponse<List<ProductPriceResponseDto>>(true, "Success", _mapper.Map<List<ProductPriceResponseDto>>(productLists));
            return new WebApiResponse<List<ProductPriceResponseDto>>(false, "Error");
        }
    }
}
