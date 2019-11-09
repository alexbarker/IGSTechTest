using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IGSTechTest.Options;
using Swashbuckle.AspNetCore.Swagger;
using IGSTechTest.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using SwaggerOptions = IGSTechTest.Options.SwaggerOptions;
using Newtonsoft.Json;
using IGSTechTest.Installers;
using IGSTechTest.Services;

namespace IGSTechTest.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()

                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
