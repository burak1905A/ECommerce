using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Town;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.Town;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("town")]

    public class TownController : BaseApiController<TownController>
    {
        private readonly ITownRepository _townRepository;
        private readonly IMapper _mapper;

        public TownController(ITownRepository townRepository, IMapper mapper)
        {
            _townRepository = townRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<TownResponseDto>>>> GetTowns()
        {
           
            var townResult = _mapper.Map<List<TownResponseDto>>(await _townRepository.TableNoTracking.ToListAsync());
            if (townResult.Count > 0)
                return new WebApiResponse<List<TownResponseDto>>(true, "Success", townResult);
            else
                return new WebApiResponse<List<TownResponseDto>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<TownResponseDto>>> GetTown(Guid id)
        {

            var townResult = _mapper.Map<TownResponseDto>(await _townRepository.GetById(id));
            if (townResult != null)
                return new WebApiResponse<TownResponseDto>(true, "Success", townResult);
            else
                return new WebApiResponse<TownResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<TownResponseDto>>> PostTown(TownRequestDto request)
        {
            Town town = _mapper.Map<Town>(request);
            var insertResult = await _townRepository.Add(town);
            if (insertResult != null)
            {
                TownResponseDto rm = _mapper.Map<TownResponseDto>(insertResult);
                return new WebApiResponse<TownResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<TownResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<TownResponseDto>>> PutTown(Guid id,
           TownRequestDto request)
        {
            
            if (id != request.Id)
                return BadRequest();

            try
            {
                Town entity = await _townRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                 
                _mapper.Map(request, entity);

                var updateResult = await _townRepository.Update(entity);
                if (updateResult != null)
                {
                    TownResponseDto rm = _mapper.Map<TownResponseDto>(updateResult);
                    return new WebApiResponse<TownResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<TownResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<TownResponseDto>>> DeleteTown(Guid id)
        {
            var town = await _townRepository.GetById(id);
            if (town != null)
            {
                if (await _townRepository.Remove(town))
                    return new WebApiResponse<TownResponseDto>(true, "Success", _mapper.Map<TownResponseDto>(town));
                else
                    return new WebApiResponse<TownResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<TownResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateTown(Guid id)
        {
            bool result = await _townRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<TownResponseDto>>>> GetActiveTowns()
        {
            var townResult = _mapper.Map<List<TownResponseDto>>(await _townRepository.GetActive().ToListAsync());
            if (townResult.Count > 0)
                return new WebApiResponse<List<TownResponseDto>>(true, "Success", townResult);
            else
                return new WebApiResponse<List<TownResponseDto>>(false, "Error");
        }
    }
}
