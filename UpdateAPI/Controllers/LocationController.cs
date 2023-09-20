using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using update.Input;

namespace update.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationDomain _locationDomain;
    private readonly IMapper _mapper;

    public LocationController(ILocationDomain locationDomain, IMapper mapper)
    {
        _locationDomain = locationDomain;
        _mapper = mapper;
    }

    //GET : api/Location
    [HttpGet]
    public async Task<List<Location>> Get()
    {
        return await _locationDomain.GetAll();
    }
    
    //GET : api/Location/1
    [HttpGet("{id}", Name = "GetLocation")]
    public async Task<Location> Get(int id)
    {
        return await _locationDomain.GetById(id);
    }
    
    //POST
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LocationData locationData)
    {
        var location = _mapper.Map<LocationData, Location>(locationData);
        await _locationDomain.Create(location);
        return Ok(location);
    }
    
    //PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] LocationData locationData)
    {
        var location = _mapper.Map<LocationData, Location>(locationData);
        await _locationDomain.Update(id, location);
        return Ok(location);
    }
    
    //DELETE : api/Location/1
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _locationDomain.Delete(id);
        return Ok();
    }
}