using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReabrProject.RebarProject.Repositories.Entities;
using ReabrProject.RebarProject.Repositories.Interfaces;
using ReabrProject.RebarProject.Repositories.Repositories;

namespace ReabrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            this._paymentRepository = paymentRepository;
        }
        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            Console.WriteLine("get");
            return _paymentRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetById(string id)
        {
            var order = _paymentRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public ActionResult<Order> Create([FromBody] Order order)
        {
            _paymentRepository.Create(order);
            return CreatedAtAction(nameof(GetById), new { id = order.OrderId }, order);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] Order order)
        {
            var existingorder = _paymentRepository.GetById(id);
            if (existingorder == null)
            {
                return NotFound();
            }
            _paymentRepository.Update(id, order);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Remove(string id)
        {
            var order = _paymentRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            _paymentRepository.Remove(order.OrderId);
            return Ok();
        }
    }
}

