using Microsoft.AspNetCore.Mvc;
using Moq;
using Payment.API.Controllers;
using Payment.API.DTOs;
using Payment.API.Mappers;
using Payment.Core.Entities;
using Payment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Payment.API.Test
{
    public class PaymentControllerTest
    {
        private readonly Mock<IPaymentRepository> _mockRepo;
        private readonly PaymentController _paymentController;
        private List<Payment.Core.Entities.Payment> payments;

        public PaymentControllerTest()
        {
            _mockRepo = new Mock<IPaymentRepository>();
            _paymentController = new PaymentController(_mockRepo.Object);

            seedPaymentData();
        }

        private void seedPaymentData()
        {
            payments = new List<Core.Entities.Payment>()
            {
                new Core.Entities.Payment
                {
                    Id =1,
                    CreationDate = DateTime.Now,
                    Amount=10,
                    CurrencyCode= "USD",
                    Status=1,
                    Order = new Order {
                        Id= 1,
                        ConsumerFullName= "Ercan",
                        ConsumerAddress= "Turkey"
                    }

                },

                new Core.Entities.Payment
                {
                    Id =2,
                    CreationDate = DateTime.Now,
                    Amount=15,
                    CurrencyCode= "EUR",
                    Status=2,
                    Order = new Order {
                        Id= 2,
                        ConsumerFullName= "Ercan",
                        ConsumerAddress= "Turkey"
                    }

                },

                new Core.Entities.Payment
                {
                    Id =3,
                    CreationDate = DateTime.Now,
                    Amount=85,
                    CurrencyCode= "USD",
                    Status=3,
                    Order = new Order {
                        Id= 3,
                        ConsumerFullName= "Ercan",
                        ConsumerAddress= "Turkey"
                    }

                },

            };
        }

        [Fact]
        public async void GetAllPayments_ActionExecutes_ReturnAllPayments()
        {
            _mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(payments);

            var result = await _paymentController.GetPayment();

            var returnPayments = Assert.IsAssignableFrom<List<Payment.Core.Entities.Payment>> (result);
        }

        [Theory]
        [InlineData(0)]
        public async void GetPayment_IdInvalid_NotFound(int Id)
        {
            Payment.Core.Entities.Payment nullPayment = null;
            _mockRepo.Setup(x => x.GetByIdAsync(Id)).ReturnsAsync(nullPayment);

            var result = await _paymentController.GetPayment(Id);

            Assert.IsType<NotFoundResult>(result);

        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetPayment_IdValid_ReturnOkResult(int Id)
        {

            var payment = payments.First(x => x.Id == Id);

            _mockRepo.Setup(x => x.GetByIdAsync(Id)).ReturnsAsync(payment);

            var result = await _paymentController.GetPayment(Id);

            var OkResult = Assert.IsType<OkObjectResult>(result);

            var returnPayment = Assert.IsType<Payment.Core.Entities.Payment>(OkResult.Value);

            Assert.Equal(Id, returnPayment.Id);
            Assert.Equal(payment.Amount, returnPayment.Amount);

        }


        
    }
}
