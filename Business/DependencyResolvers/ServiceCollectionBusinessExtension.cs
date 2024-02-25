using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.DependencyResolvers
{
    public static class ServiceCollectionBusinessExtension
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IBrandService, BrandManager>()
                    .AddSingleton<IBrandDal, InMemoryBrandDal>()
                    .AddSingleton<BrandBusinessRules>()

                    .AddScoped<IModelService, ModelManager>()
                    .AddScoped<IModelDal, EfModelDal>()
                    .AddScoped<ModelBusinessRules>()

                    .AddSingleton<IFuelService, FuelManager>()
                    .AddSingleton<IFuelDal, InMemoryFuelDal>()
                    .AddSingleton<FuelBusinessRules>()

                    .AddSingleton<ITransmissionService, TransmissionManager>()
                    .AddSingleton<ITransmissionDal, InMemoryTransmissionDal>()
                    .AddSingleton<TransmissionBusinessRules>()

                    .AddSingleton<ICarService, CarManager>()
                    .AddSingleton<ICarDal, InMemoryCarDal>()
                    .AddSingleton<CarBusinessRules>()

                    .AddScoped<IIndividualCustomerService, IndividualCustomerManager>()
                    .AddScoped<IIndividualCustomerDal, EfIndividualCustomerDal>()
                    .AddScoped<IndividualCustomerBusinessRules>()

                    .AddScoped<IUserService, UserManager>()
                    .AddScoped<IUserDal, EfUserDal>()
                    .AddScoped<UserBusinessRules>()

                    .AddScoped<ICustomerService, CustomerManager>()
                    .AddScoped<ICustomerDal, EfCustomerDal>()
                    .AddScoped<CustomerBusinessRules>()
                    .AddScoped<ITokenHelper,JwtTokenHelper>()
                    .AddAutoMapper(Assembly.GetExecutingAssembly())
                    .AddDbContext<RentACarContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACarMSSQL22")));
                    
            

            return services;
        } 
    }
}
