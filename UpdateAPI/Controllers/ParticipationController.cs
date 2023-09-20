using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using update.Input;

namespace update.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipationController : ControllerBase
{
    private readonly IParticipationDomain _participationDomain;
    private readonly IMapper _mapper;

    public ParticipationController(IParticipationDomain participationDomain, IMapper mapper)
    {
        _participationDomain = participationDomain;
        _mapper = mapper;
    }

    //GET : api/Participation
    [HttpGet]
    public async Task<List<Participation>> Get()
    {
        return await _participationDomain.GetAll();
    }

    //GET : api/Participation/1
    [HttpGet("{id}", Name = "GetParticipation")]
    public async Task<Participation> Get(int id)
    {
        return await _participationDomain.GetById(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ParticipationData participationData)
    {
        var participation = _mapper.Map<ParticipationData, Participation>(participationData);
        await _participationDomain.Create(participation);
        return Ok(participation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ParticipationData participationData)
    {
        var participation = _mapper.Map<ParticipationData, Participation>(participationData);
        await _participationDomain.Update(id, participation);
        return Ok(participation);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _participationDomain.Delete(id);
        return Ok();
    }
}