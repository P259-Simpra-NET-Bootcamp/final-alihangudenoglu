using Core.Utilities.Security.JWT;
using Core.Extensions;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extension;
using Core.Utilities.IoC;
using Core.DependencyResolvers;
using WebAPI.Middleware;
using Core.Logger;
using Serilog;

namespace WebAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public static JwtConfig JwtConfig { get; private set; }
    public void ConfigureServices(IServiceCollection services)
    {
        JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
        services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

        services.AddDependencyResolvers(new ICoreModule[]
        {
            new CoreModule()
        });
        services.AddControllers();
        services.AddCustomSwaggerExtension();
        services.AddDbContextExtension(Configuration);
        services.AddMapperExtension();
        services.AddJwtExtension();
        services.AddAuthentication();

    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

        }
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.DefaultModelsExpandDepth(-1);
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Digital Product");
            c.DocumentTitle = "Digital Product";
        });



        app.AddExceptionHandler();
        app.AddDIExtension();
        app.UseMiddleware<ErrorHandlerMiddleware>();
        Action<RequestProfilerModel> requestResponseHandler = requestProfilerModel =>
        {
            Log.Information("-------------Request-Begin------------");
            Log.Information(requestProfilerModel.Request);
            Log.Information(Environment.NewLine);
            Log.Information(requestProfilerModel.Response);
            Log.Information("-------------Request-End------------");
        };
        app.UseMiddleware<RequestLoggingMiddleware>(requestResponseHandler);

        app.UseHttpsRedirection();

        // add auth 
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();

        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
