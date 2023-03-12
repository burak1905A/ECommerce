using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.ProductDetail;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.ProductDetail;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("productDetail")]
    [ApiController]
    public class ProductDetailController : BaseApiController<ProductDetailController>
    {
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IMapper _mapper;

        public ProductDetailController(IProductDetailRepository productDetailRepository, IMapper mapper)
        {
            _productDetailRepository = productDetailRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<ProductDetailResponseDto>>>> GetProductDetails()
        {
            
            var productDetailResult = _mapper.Map<List<ProductDetailResponseDto>>(await _productDetailRepository.TableNoTracking.ToListAsync());
            if (productDetailResult.Count > 0)
                return new WebApiResponse<List<ProductDetailResponseDto>>(true, "Success", productDetailResult);
            else
                return new WebApiResponse<List<ProductDetailResponseDto>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponseDto>>> GetProductDetail(Guid id)
        {

            var productDetailResult = _mapper.Map<ProductDetailResponseDto>(await _productDetailRepository.GetById(id));
            if (productDetailResult != null)
                return new WebApiResponse<ProductDetailResponseDto>(true, "Success", productDetailResult);
            else
                return new WebApiResponse<ProductDetailResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponseDto>>> PostProductDetail(ProductDetailRequestDto request)
        {
            ProductDetail productDetail = _mapper.Map<ProductDetail>(request);
            var insertResult = await _productDetailRepository.Add(productDetail);
            if (insertResult != null)
            {
                ProductDetailResponseDto rm = _mapper.Map<ProductDetailResponseDto>(insertResult);
                return new WebApiResponse<ProductDetailResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<ProductDetailResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponseDto>>> PutProductDetail(Guid id,
           ProductDetailRequestDto request)
        {
           
            if (id != request.Id)
                return BadRequest();

            try
            {
                ProductDetail entity = await _productDetailRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _productDetailRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductDetailResponseDto rm = _mapper.Map<ProductDetailResponseDto>(updateResult);
                    return new WebApiResponse<ProductDetailResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<ProductDetailResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponseDto>>> DeleteProductDetail(Guid id)
        {
            var productDetail = await _productDetailRepository.GetById(id);
            if (productDetail != null)
            {
                if (await _productDetailRepository.Remove(productDetail))
                    return new WebApiResponse<ProductDetailResponseDto>(true, "Success", _mapper.Map<ProductDetailResponseDto>(productDetail));
                else
                    return new WebApiResponse<ProductDetailResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<ProductDetailResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateProductDetail(Guid id)
        {
            bool result = await _productDetailRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductDetailResponseDto>>>> GetActiveCategories()
        {
            var productDetailResult = _mapper.Map<List<ProductDetailResponseDto>>(await _productDetailRepository.GetActive().ToListAsync());
            if (productDetailResult.Count > 0)
                return new WebApiResponse<List<ProductDetailResponseDto>>(true, "Success", productDetailResult);
            else
                return new WebApiResponse<List<ProductDetailResponseDto>>(false, "Error");
        }
        [HttpGet("GetByProductId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductDetailResponseDto>>>> GetByProductId(Guid id)
        {
            var productLists = await _productDetailRepository.GetDefault(x => x.ProductId == id).ToListAsync();
            if (productLists.Count > 0)
                return new WebApiResponse<List<ProductDetailResponseDto>>(true, "Success", _mapper.Map<List<ProductDetailResponseDto>>(productLists));
            return new WebApiResponse<List<ProductDetailResponseDto>>(false, "Error");
        }
    }
}
