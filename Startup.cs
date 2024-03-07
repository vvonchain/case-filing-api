using EvictionCaseFilingAPI.Security;
using EvictionCaseFilingAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoapCore;

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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<IEFilingService>("/eFiling.asmx", new SoapEncoderOptions());
                endpoints.MapControllers();
            });
        }
    }
}