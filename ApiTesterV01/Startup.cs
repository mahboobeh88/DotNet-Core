using ApiTesterV01.Common;
using ApiTesterV01.Data;
using ApiTesterV01.ISevices;
using ApiTesterV01.MyFilters;
using ApiTesterV01.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

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
            services.AddScoped(typeof(IUserServices), typeof(UserServices));
            services.AddScoped(typeof(ICompanyOwnerServices), typeof(CompanyOwnerServices));
            services.AddScoped(typeof(ICompanyServices), typeof(CompanyServices));
            services.AddScoped(typeof(ICustomerServices), typeof(CustomerServices));
            services.AddScoped(typeof(IOrderServices) , typeof(OrderServices));
            services.AddScoped(typeof(IOrderDetailServices) , typeof(OrderDetailServices));
            services.AddScoped(typeof(IPaymentServices) , typeof(PaymentServices));
            services.AddScoped(typeof(IPageServices), typeof(PageServices));
            services.AddScoped(typeof(ISectionPageServices) , typeof(SectionPageServices));
            services.AddScoped(typeof(IStoreHouseServices) , typeof(StoreHouseServices));
            services.AddScoped(typeof(IUserTokenServices), typeof(UserTokenServices));
            services.AddScoped(typeof(IAuthServices), typeof(AuthServices));
            services.AddScoped(typeof(IPermissionGroupServices), typeof(PermissionGroupServices));
            services.AddScoped(typeof(IPermissionServices), typeof(PermissionServices));
            services.AddScoped(typeof(IRoleServices), typeof(RoleServices));
            services.AddScoped(typeof(IRolePermissionServices), typeof(RolePermissionServices));
            #endregion

            #region Utilities
            services.AddSingleton(typeof(EncryptionUtility));
            services.AddSingleton(typeof(AuthUtility));
            #endregion


            #region Token
           // var secretKey = "THIS OK ABCD OL TEST AND AERIFY ABC OOKENS, REPLACE IT WITH YOUN OWN SECRET, IT CAN BE ANY STRING"; 
            //var secretKey = "THIS OK ABCD OL TEST AND AERIFY ABC AAKENS, REPLACE IT WITH YOUN PLK SECRET, IT CAN BE ANY STRING";
           var secretKey = "THIS OK USED AB OMID DNA AERIFY JWT OOKENS, REPLACE IT WITH YOUN OWN SECRET, IT CAN BE ANY STRING"; //Configuration.GetValue<string>("TokenKey");
            var tokenTimeOut = 5; // Configuration.GetValue<int>("TokenTimeOut");

            var key = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    //برای کنترل زمان توکن
                    ClockSkew = TimeSpan.FromMinutes(tokenTimeOut),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
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

                #region Add Authorization To Swagger

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", Array.Empty<string>()},
                };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "Bearer",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
                #endregion


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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
}
    }
}
