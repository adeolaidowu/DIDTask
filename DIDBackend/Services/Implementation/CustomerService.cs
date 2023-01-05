using DIDBackend.Models;
using DIDBackend.Services.Interface;
using DIDBackend.UOW;
using System.Text.Json;

namespace DIDBackend.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Customer> GetCustomerAccountInfo()
        {
            try
            {
                var customerDetails = await _unitOfWork.CustomerRepository.GetCustomerAccountInfo();
                return customerDetails;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
