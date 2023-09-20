using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using update.Input;

namespace update.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommunityController : ControllerBase
{
    private readonly ICommunityDomain _communityDomain;
    private readonly IMapper _mapper;
    public CommunityController(ICommunityDomain communityDomain, IMapper mapper)
    {
        _communityDomain = communityDomain;
        _mapper = mapper;
    }
    
    //GET : api/Community
    [HttpGet]
    public async Task<List<Community>> Get()
    {
        return await _communityDomain.GetAll();
    }
    
    //GET : api/Community/1
    [HttpGet("{id}", Name = "GetCommunity")]
    public async Task<Community> Get(int id)
    {
        return await _communityDomain.GetById(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CommunityData communityData)
    {
        var community = _mapper.Map<CommunityData, Community>(communityData);
        await _communityDomain.Create(community);
        return Ok(community);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CommunityData communityData)
    {
        var community = _mapper.Map<CommunityData, Community>(communityData);
        await _communityDomain.Update(id, community);
        return Ok(community);
    }

    // DELETE: api/Community/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _communityDomain.Delete(id);
        return Ok();
    }
}