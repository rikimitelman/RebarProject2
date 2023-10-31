using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReabrProject.RebarProject.Repositories.Entities;
using ReabrProject.RebarProject.Repositories.Interfaces;

namespace ReabrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        [HttpGet]
        public ActionResult<List<Shake>> GetAll()
        {
            Console.WriteLine("get");
            return _orderRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Shake> GetById(Guid id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public ActionResult<Shake> Create([FromBody] Shake shake)
        {
            _orderRepository.Create(shake);
            return CreatedAtAction(nameof(GetById), new { id = shake.ShakeId }, shake);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] Shake shake)
        {
            var existingOrder = _orderRepository.GetById(id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            _orderRepository.Update(id, shake);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var shake = _orderRepository.GetById(id);
            if (shake == null)
            {
                return NotFound();
            }
            _orderRepository.Remove(shake.ShakeId);
            return Ok();
        }
    }
}
