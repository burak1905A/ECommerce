using AnılBurakYamaner_Proje.API.Controllers.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Member;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Service.Repository.Member;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("member")]
    
    public class MemberController : BaseApiController<MemberController>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberController(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<MemberResponseDto>>>> GetMembers()
        {
           
            var memberResult = _mapper.Map<List<MemberResponseDto>>(await _memberRepository.TableNoTracking.ToListAsync());
            if (memberResult.Count > 0)
                return new WebApiResponse<List<MemberResponseDto>>(true, "Success", memberResult);
            else
                return new WebApiResponse<List<MemberResponseDto>>(false, "Error");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberResponseDto>>> GetMember(Guid id)
        {

            var memberResult = _mapper.Map<MemberResponseDto>(await _memberRepository.GetById(id));
            if (memberResult != null)
                return new WebApiResponse<MemberResponseDto>(true, "Success", memberResult);
            else
                return new WebApiResponse<MemberResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<MemberResponseDto>>> PostMember(MemberRequestDto request)
        {
            Member member = _mapper.Map<Member>(request);
            var insertResult = await _memberRepository.Add(member);
            if (insertResult != null)
            {
                MemberResponseDto rm = _mapper.Map<MemberResponseDto>(insertResult);
                return new WebApiResponse<MemberResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<MemberResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberResponseDto>>> PutMember(Guid id,
           MemberRequestDto request)
        {
           
            if (id != request.Id)
                return BadRequest();

            try
            {
                Member entity = await _memberRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                
                _mapper.Map(request, entity);

                var updateResult = await _memberRepository.Update(entity);
                if (updateResult != null)
                {
                    MemberResponseDto rm = _mapper.Map<MemberResponseDto>(updateResult);
                    return new WebApiResponse<MemberResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<MemberResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberResponseDto>>> DeleteMember(Guid id)
        {
            var member = await _memberRepository.GetById(id);
            if (member != null)
            {
                if (await _memberRepository.Remove(member))
                    return new WebApiResponse<MemberResponseDto>(true, "Success", _mapper.Map<MemberResponseDto>(member));
                else
                    return new WebApiResponse<MemberResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<MemberResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateMember(Guid id)
        {
            bool result = await _memberRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MemberResponseDto>>>> GetActiveMembers()
        {
            var memberResult = _mapper.Map<List<MemberResponseDto>>(await _memberRepository.GetActive().ToListAsync());
            if (memberResult.Count > 0)
                return new WebApiResponse<List<MemberResponseDto>>(true, "Success", memberResult);
            else
                return new WebApiResponse<List<MemberResponseDto>>(false, "Error");
        }
    }
    
}
