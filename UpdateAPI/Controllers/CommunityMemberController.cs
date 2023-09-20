using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using update.Input;

namespace update.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommunityMemberController : ControllerBase
{
    private readonly ICommunityMemberDomain _communityMemberDomain;
    private readonly IMapper _mapper;

    public CommunityMemberController(ICommunityMemberDomain communityMemberDomain, IMapper mapper)
    {
        _communityMemberDomain = communityMemberDomain;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<List<CommunityMember>> Get()
    {
        return await _communityMemberDomain.GetAll();
    }

    [HttpGet("{id}", Name = "GetCommunityMember")]
    public async Task<CommunityMember> Get(int id)
    {
        return await _communityMemberDomain.GetById(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CommunityMemberData communityMemberData)
    {
        var communityMember = _mapper.Map<CommunityMemberData, CommunityMember>(communityMemberData);
        await _communityMemberDomain.Create(communityMember);
        return Ok(communityMember);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, [FromBody] CommunityMemberData communityMemberData)
    {
        var communityMember = _mapper.Map<CommunityMemberData, CommunityMember>(communityMemberData);
        await _communityMemberDomain.Update(id, communityMember);
        return Ok(communityMember);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _communityMemberDomain.Delete(id);
        return Ok();
    }
}