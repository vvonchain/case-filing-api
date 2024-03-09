using EvictionCaseFilingAPI.Security;
using EvictionCaseFilingAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoapCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using EvictionCaseFilingAPI.Callbacks;
using System.Net.Http;

namespace EvictionCaseFilingAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSoapCore();
            services.AddScoped<IEFilingService, EFilingService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IX509CertificateProvider, X509CertificateProvider>();
            services.AddSingleton<SOAPSignatureHandler>();
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddHttpClient<ProcessingCompleteCallback>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication(); // Ensure authentication is used before authorization
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<IEFilingService>("/eFiling.asmx", new SoapEncoderOptions());
                endpoints.MapControllers();
            });
        }
    }
}