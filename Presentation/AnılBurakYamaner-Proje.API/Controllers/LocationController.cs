using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Location;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.Location;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("location")]
    [ApiController]
    public class LocationController : BaseApiController<LocationController>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationController(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<LocationResponseDto>>>> GetLocations()
        {
            
            var locationResult = _mapper.Map<List<LocationResponseDto>>(await _locationRepository.TableNoTracking.ToListAsync());
            if (locationResult.Count > 0)
                return new WebApiResponse<List<LocationResponseDto>>(true, "Success", locationResult);
            else
                return new WebApiResponse<List<LocationResponseDto>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<LocationResponseDto>>> GetLocation(Guid id)
        {

            var locationResult = _mapper.Map<LocationResponseDto>(await _locationRepository.GetById(id));
            if (locationResult != null)
                return new WebApiResponse<LocationResponseDto>(true, "Success", locationResult);
            else
                return new WebApiResponse<LocationResponseDto>(false, "Error");
        }


        [HttpPost]
        public async Task<ActionResult<WebApiResponse<LocationResponseDto>>> PostLocation(LocationRequestDto request)
        {
            Location location = _mapper.Map<Location>(request);
            var insertResult = await _locationRepository.Add(location);
            if (insertResult != null)
            {
                LocationResponseDto rm = _mapper.Map<LocationResponseDto>(insertResult);
                return new WebApiResponse<LocationResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<LocationResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<LocationResponseDto>>> PutLocation(Guid id,
            LocationRequestDto request)
        {
           
            if (id != request.Id)
                return BadRequest();

            try
            {
                Location entity = await _locationRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                
                _mapper.Map(request, entity);

                var updateResult = await _locationRepository.Update(entity);
                if (updateResult != null)
                {
                    LocationResponseDto rm = _mapper.Map<LocationResponseDto>(updateResult);
                    return new WebApiResponse<LocationResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<LocationResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<LocationResponseDto>>> DeleteLocation(Guid id)
        {
            var location = await _locationRepository.GetById(id);
            if (location != null)
            {
                if (await _locationRepository.Remove(location))
                    return new WebApiResponse<LocationResponseDto>(true, "Success", _mapper.Map<LocationResponseDto>(location));
                else
                    return new WebApiResponse<LocationResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<LocationResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateLocation(Guid id)
        {
            bool result = await _locationRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<LocationResponseDto>>>> GetActiveLocations()
        {
            var locationResult = _mapper.Map<List<LocationResponseDto>>(await _locationRepository.GetActive().ToListAsync());
            if (locationResult.Count > 0)
                return new WebApiResponse<List<LocationResponseDto>>(true, "Success", locationResult);
            else
                return new WebApiResponse<List<LocationResponseDto>>(false, "Error");
        }

        [HttpGet("GetByCountryId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<LocationResponseDto>>>> GetByCountryId(Guid id)
        {
            var postLists = await _locationRepository.GetDefault(x => x.CountryId == id).ToListAsync();
            if (postLists.Count > 0)
                return new WebApiResponse<List<LocationResponseDto>>(true, "Success", _mapper.Map<List<LocationResponseDto>>(postLists));
            return new WebApiResponse<List<LocationResponseDto>>(false, "Error");
        }
    }
}
