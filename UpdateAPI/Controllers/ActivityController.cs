using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using update.Filter;
using update.Input;

namespace update.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize("admin")]
    public class ActivityController : ControllerBase
    {
        //Inyeccion
        private readonly IActivityDomain _activityDomain;
        private readonly IMapper _mapper;

        public ActivityController(IActivityDomain activityDomain, IMapper mapper)
        {
            _activityDomain = activityDomain;
            _mapper = mapper;
        }
        
        // GET: api/Activity
        [HttpGet]
        public async Task<List<Activity>> Get()
        {
            //filter data
            //
            return await _activityDomain.GetAll();
        }

        // GET: api/Activity/5
        [HttpGet("{id}", Name = "GetActivity")]
        public async Task<Activity> Get(int id)
        {
            return await _activityDomain.GetById(id);
        }

        // POST: api/Activity
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActivityData activityData)
        {
            var activity = _mapper.Map<ActivityData, Activity>(activityData);
            await _activityDomain.Create(activity);
            return Ok(activity);
        }

        // PUT: api/Activity/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ActivityData activityData)
        {
            var activity = _mapper.Map<ActivityData, Activity>(activityData);
            await _activityDomain.Update(id, activity);
            return Ok(activity);
        }

        // DELETE: api/Activity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _activityDomain.Delete(id);
            return Ok();
        }
    }
}
