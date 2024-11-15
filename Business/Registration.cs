using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class Registration
    {
        public static void AddBusiness(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
