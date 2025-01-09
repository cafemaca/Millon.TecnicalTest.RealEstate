// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Api
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 02-02-2024 
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 06-25-2024
//  ****************************************************************
//  <copyright file="Program.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Millon.TecnicalTest.RealEstate.Api.Extensions;
using Millon.TecnicalTest.RealEstate.Application.Common.Options;
using Millon.TecnicalTest.RealEstate.Data.Common.Options;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Configuracion de Opciones
builder.Services
    .AddOptions<ApplicationOptions>()
    .Bind(builder.Configuration.GetSection(ApplicationOptions.Key))
    .Validate(option => option.DefaultPageSize > 0, "Page Size must be greater than 0.")
    .ValidateOnStart();
builder.Services.AddOptions<CacheOptions>()
    .Bind(builder.Configuration.GetSection(CacheOptions.Key));
#endregion

#region Services Register
builder.Services.AddControllers();
builder.Services.RegisterMiddleware();
builder.Services.RegisterApiVersion();
builder.Services.RegisterCORS(builder.Configuration);
builder.Services.RegisterSwagger();
builder.Services.RegisterDB(builder.Configuration);
builder.Services.RegisterDependency(builder.Configuration);
builder.Services.RegisterLogging(builder.Configuration);
builder.Services.RegisterHealthCheck(builder.Configuration);
#endregion

WebApplication app = builder.Build();

app.UseCors("AllowSpecificOrigin");

//HealthCheck Middleware4
app.MapHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(delegate (Options options)
{
    options.UIPath = "/health-ui";
    options.AddCustomStylesheet("./Middleware/HealthCheck/custom.css");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json")
        .UseSwaggerUI(c =>
        {
            c.DocumentTitle = "Millon.TecnicalTest.RealEstate API";
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Millon.TecnicalTest.RealEstate API v1.0");

            //Add the new version
            c.SwaggerEndpoint("/swagger/v2/swagger.json", "Millon.TecnicalTest.RealEstate API v2.0");

            c.DisplayRequestDuration();
        });
    //app.UseDeveloperExceptionPage();
    app.UseExceptionHandler((_ => { })); // Should be always in first place 

}
else
{
    app.UseExceptionHandler((_ => { })); // Should be always in first place 
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseRouting().UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSerilogRequestLogging();

app.Run();
