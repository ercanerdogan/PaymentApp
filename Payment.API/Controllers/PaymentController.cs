using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.API.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payment.Core.Repositories;
using Payment.API.Responses;
using Payment.API.Mappers;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentRepository _repository;

        public PaymentController(IPaymentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Payment.Core.Entities.Payment>> GetPayment()
        {
            return (List<Payment.Core.Entities.Payment>) await _repository.GetAllAsync();
            
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPayment(int Id)
        {
            var result = await _repository.GetByIdAsync(Id);
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentResponse>> CreatePayment([FromBody] CreatePaymentDto paymentDto)
        {
            var paymentEntity = PaymentMapper.Mapper.Map<Payment.Core.Entities.Payment>(paymentDto);
            if (paymentEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var newPayment = await _repository.AddAsync(paymentEntity);
            var paymentResponse = PaymentMapper.Mapper.Map<PaymentResponse>(newPayment);

            return CreatedAtAction("GetPayment", paymentResponse);
        }

    }
}
