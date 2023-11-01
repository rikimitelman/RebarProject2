using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReabrProject.RebarProject.Repositories.Entities;
using ReabrProject.RebarProject.Repositories.Interfaces;
using ReabrProject.RebarProject.Repositories.Repositories;

namespace ReabrProject.Controllers
{
    public class PaymentDBController : ControllerBase
    {
        private readonly IPaymentDBRepository _paymentDBRepository;

        public PaymentDBController(IPaymentDBRepository paymentDBRepository)
        {
            this._paymentDBRepository = paymentDBRepository;
        }
        [HttpGet]
        public ActionResult<List<Payment>> GetAll()
        {
            Console.WriteLine("enter password");
            string password = Console.ReadLine();
            if (!password.Equals("1234"))
                return BadRequest("wrong password");
            return _paymentDBRepository.GetAll();
        }
        [HttpPost]
        public ActionResult<Payment> Create([FromBody] Payment payment)
        {
            Console.WriteLine("enter passpord");
            string password = Console.ReadLine();
            if (!password.Equals("1234"))
                return BadRequest("wrong password");
            _paymentDBRepository.Create(payment);
            return CreatedAtAction(nameof(GetAll), new { id = payment.PaymentId }, payment);
        }

    }
}
