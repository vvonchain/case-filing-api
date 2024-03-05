using Swashbuckle.AspNetCore.Swagger;

public class Startup
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eviction Case Filing API V1");
        });

        app.UseOpenApi();
        app.UseSwaggerUi3();
    }
}