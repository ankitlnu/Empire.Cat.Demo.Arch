using Autofac.Extras.Moq;
using Empire.Customer.Application.Interfaces;
using Empire.Customer.Application.ViewModels;
using Empire.Customer.Controllers;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using E = Empire.Customer.Domain.Models;
using Newtonsoft.Json;
namespace Empire.Customer.Tests.CustomerMicroservice.Controllers
{
    [Trait("Controllers", nameof(CustomerController))]
    public class CustomerControllerTests
    {
        [Fact]
        public async Task Get_Should_Return_List_Of_Customers()
        {
            using var mock = AutoMock.GetLoose();

            var controllers = mock.Create<CustomerController>();

            var actualCustomer = new List<E.Customer>
            {
                new E.Customer
                {
                    Description="Test1",
                    Name="Test1"
                }
            };

            var expectedCustomer = new List<CustomerDTO>();

            foreach (var item in actualCustomer)
            {
                var customerDTO = new CustomerDTO
                {
                    Description = item.Description,
                    Name = item.Name
                };

                expectedCustomer.Add(customerDTO);
            }

            mock.Mock<ICustomerService>()
                .Setup(d => d.GetAllCustomer())
                .ReturnsAsync(actualCustomer);

            var controller = mock.Create<CustomerController>();

            var result = await controller.Get();

            _ = Assert.IsAssignableFrom<IEnumerable<CustomerDTO>>(result);

            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(expectedCustomer));
        }

        [Fact]
        public async Task GetById_Should_Return_Customer()
        {
            using var mock = AutoMock.GetLoose();

            var controllers = mock.Create<CustomerController>();

            var actualCustomer = new E.Customer
            {
                Description = "Test1",
                Name = "Test1"
            };           
            
            var expectedCustomer = new CustomerDTO
            {
                Description = actualCustomer.Description,
                Name = actualCustomer.Name
            };

            mock.Mock<ICustomerService>()
                .Setup(d => d.GetCustomerById(It.IsAny<int>()))
                .ReturnsAsync(actualCustomer);

            var controller = mock.Create<CustomerController>();

            var result = await controller.GetById(It.IsAny<int>());

            _ = Assert.IsAssignableFrom<CustomerDTO>(result);

            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(expectedCustomer));
        }

    }
}
