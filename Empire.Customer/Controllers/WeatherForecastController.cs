using Empire.Customer.Application.Interfaces;
using Empire.Customer.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empire.Customer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICustomerService customerService;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDTO>> Get()
        {
            //Todo : implement auto mapper
            var customerList = new List<CustomerDTO>();

            var allCustomers= await customerService.GetAllCustomer();

            foreach (var item in allCustomers)
            {
                var customerDTO = new CustomerDTO
                {
                    Description = item.Description,
                    Name = item.Name
                };

                customerList.Add(customerDTO);
            }

            return customerList;
        }


        [HttpGet("{Id}")]
        public async Task<CustomerDTO> GetById(int Id)
        {
            var customer = await customerService.GetCustomerById(Id);

            var customerDTO = new CustomerDTO
            {
                Description = customer.Description,
                Name = customer.Name
            };

            return customerDTO;
        }


        [HttpPost]
        public async Task<IEnumerable<string>> Post()
        {
            var result = await customerService.AddCustomer(new CustomerDTO
            {
                Description = "Dev 1",
                Name = "Dev 2"
            });

            return new string[] { "ta", "tada", "tada" };
        }
    }
}
