using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Country;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.Country;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("country")]
    
    public class CountryController : BaseApiController<CountryController>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<CountryResponseDto>>>> GetCountries()
        {

            var countryResult = _mapper.Map<List<CountryResponseDto>>(await _countryRepository.TableNoTracking.ToListAsync());
            if (countryResult.Count > 0)
                return new WebApiResponse<List<CountryResponseDto>>(true, "Success", countryResult);
            else
                return new WebApiResponse<List<CountryResponseDto>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<CountryResponseDto>>> GetCountry(Guid id)
        {

            var countryResult = _mapper.Map<CountryResponseDto>(await _countryRepository.GetById(id));
            if (countryResult != null)
                return new WebApiResponse<CountryResponseDto>(true, "Success", countryResult);
            else
                return new WebApiResponse<CountryResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CountryResponseDto>>> PostCountry(CountryRequestDto request)
        {
            Country country = _mapper.Map<Country>(request);
            var insertResult = await _countryRepository.Add(country);
            if (insertResult != null)
            {
                CountryResponseDto rm = _mapper.Map<CountryResponseDto>(insertResult);
                return new WebApiResponse<CountryResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<CountryResponseDto>(false, "Error");
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CountryResponseDto>>> PutCountry(Guid id,
           CountryRequestDto request)
        {
            
            if (id != request.Id)
                return BadRequest();

            try
            {
                Country entity = await _countryRepository.GetById(id);
                if (entity == null)
                    return NotFound();

               
                _mapper.Map(request, entity);

                var updateResult = await _countryRepository.Update(entity);
                if (updateResult != null)
                {
                    CountryResponseDto rm = _mapper.Map<CountryResponseDto>(updateResult);
                    return new WebApiResponse<CountryResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<CountryResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CountryResponseDto>>> DeleteCountry(Guid id)
        {
            var country = await _countryRepository.GetById(id);
            if (country != null)
            {
                if (await _countryRepository.Remove(country))
                    return new WebApiResponse<CountryResponseDto>(true, "Success", _mapper.Map<CountryResponseDto>(country));
                else
                    return new WebApiResponse<CountryResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<CountryResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateCountry(Guid id)
        {
            bool result = await _countryRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }


        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CountryResponseDto>>>> GetActiveCountries()
        {
            var countryResult = _mapper.Map<List<CountryResponseDto>>(await _countryRepository.GetActive().ToListAsync());
            if (countryResult.Count > 0)
                return new WebApiResponse<List<CountryResponseDto>>(true, "Success", countryResult);
            else
                return new WebApiResponse<List<CountryResponseDto>>(false, "Error");
        }
    }
}
