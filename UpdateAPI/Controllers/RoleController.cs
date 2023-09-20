using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using update.Input;

namespace update.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleDomain _roleDomain;
    private readonly IMapper _mapper;

    public RoleController(IRoleDomain roleDomain, IMapper mapper)
    {
        _roleDomain = roleDomain;
        _mapper = mapper;
    }
    
    //GET : api/Role
    [HttpGet]
    public async Task<List<Role>> Get()
    {
        return await _roleDomain.GetAll();
    }
    
    //GET : api/Role/1
    [HttpGet("{id}", Name = "GetRole")]
    public async Task<Role> Get(int id)
    {
        return await _roleDomain.GetById(id);
    }
    
    //POST
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RoleData roleData)
    {
        var role = _mapper.Map<RoleData, Role>(roleData);
        await _roleDomain.Create(role);
        return Ok(role);
    }
    
    //PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] RoleData roleData)
    {
        var role = _mapper.Map<RoleData, Role>(roleData);
        await _roleDomain.Update(id, role);
        return Ok(role);
    }

    // DELETE: api/Role/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _roleDomain.Delete(id);
        return Ok();
    }
}