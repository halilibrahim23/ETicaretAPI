using ETicaretAPI.Application.Abstract;
using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories.CustomerRepository;
using ETicaretAPI.Persistence.Repositories.CustomerRepository;
using ETicaretAPI.Application.Repositories.OrderRepository;
using ETicaretAPI.Persistence.Repositories.OrderRepository;
using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Persistence.Repositories.ProductRepository;

namespace ETicaretAPI.Persistence
{
    public  static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services) 
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString),ServiceLifetime.Singleton); ;
            services.AddSingleton<ICustomerReadRepository,CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository,OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository,OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository,ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository,ProductWriteRepository>();
        }
    }
}
