using ApiTesterV01.Common;
using ApiTesterV01.Data;
using ApiTesterV01.ISevices;
using ApiTesterV01.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ApiTesterV01
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region  DBContext Registeration
            services.AddDbContext<APITesterDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("APITesterConnection")));
            #endregion

            #region  Automapper Registeration

            IMapper mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperConfiguration());
            }).CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region DI Registeration
            services.AddScoped(typeof(IUnitServices), typeof(UnitServices));
            services.AddScoped(typeof(ICategoryServices), typeof(CategoryServices));
            services.AddScoped(typeof(ICityServices), typeof(CityServices));
            services.AddScoped(typeof(IDiscountServices), typeof(DiscountServices));
            services.AddScoped(typeof(IFactoryServices), typeof(FactoryServices));
            services.AddScoped(typeof(IUserServices) , typeof(UserServices));
            services.AddScoped(typeof(ICompanyOwnerServices) , typeof(CompanyOwnerServices));
            #endregion

            services.AddControllers();

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                //c.OperationFilter<ReApplyOptionalRouteParameterOperationFilter>();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Tester Mohseni App API",
                    Description = "Mohseni App API - Version01",
                    TermsOfService = new Uri("http://Mohseni.me/"),
                    License = new OpenApiLicense
                    {
                        Name = "Mohseni",
                        Url = new Uri("http://Mohseni.me/"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiTesterV01 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
