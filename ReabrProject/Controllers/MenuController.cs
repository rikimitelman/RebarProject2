using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReabrProject.RebarProject.Repositories.Entities;
using ReabrProject.RebarProject.Repositories.Interfaces;

namespace ReabrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _ShakeRepository;

        public MenuController(IMenuRepository shakeRepository)
        {
            this._ShakeRepository = shakeRepository;
        }
        [HttpGet]
        public ActionResult<List<Shake>> GetAll()
        {
            Console.WriteLine("get");
            return _ShakeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Shake> GetById(Guid id)
        {
            var shake = _ShakeRepository.GetById(id);
            if (shake == null)
            {
                return NotFound();
            }
            return shake;
        }

        [HttpPost]
        public ActionResult<Shake> Create([FromBody] Shake shake)
        {
            _ShakeRepository.Create(shake);
            return CreatedAtAction(nameof(GetById), new { id = shake.ShakeId }, shake);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody]Shake shake)
        {
            var existingShake= _ShakeRepository.GetById(id);
            if(existingShake==null)
            {
                return NotFound();
            }
            _ShakeRepository.Update(id,shake);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        { 
            var shake= _ShakeRepository.GetById(id); 
            if(shake==null)
            {
                return NotFound();
            }
            _ShakeRepository.Remove(shake.ShakeId);
            return Ok();
        }
    }
}
