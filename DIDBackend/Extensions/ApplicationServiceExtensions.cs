using DIDBackend.Repositories.Implementation;
using DIDBackend.Repositories.Interface;
using DIDBackend.Services.Implementation;
using DIDBackend.Services.Interface;
using DIDBackend.UOW;

namespace DIDBackend.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
