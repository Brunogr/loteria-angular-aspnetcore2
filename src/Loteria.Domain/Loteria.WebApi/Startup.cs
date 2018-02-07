using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Loteria.Infra.CrossCutting;
using AutoMapper;
using Microsoft.AspNetCore.ResponseCompression;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Http;

namespace Loteria.WebApi
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
            //AutoMapper
            services.AddAutoMapper(typeof(Startup));
            
            //CrossCutting
            services.RegisterServices();
            
            services.AddCors();

            services.AddMvc();

            //GZIP
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression();

            //Cache
            services.AddMemoryCache();

            //Swagger
            services.AddSwaggerGen(
               options =>
               {
                   options.SwaggerDoc("v1", new Info
                   {
                       Version = "v1",
                       Title = "Loteria",
                       Description = "Loteria Swagger Interface",
                       Contact = new Contact { Name = "Bruno Gouvêa Roldão", Email = "Brunogrbhg@gmail.com", Url = "http://www.codefc.com" },
                   });
                   
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
             builder.AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowAnyOrigin()
             );

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "loteria/api/v1/{controller}/{action}/{id?}"
                    );
                routes.MapRoute(
                    name: "Api",
                    template: "loteria/api/v1/{controller}/{id?}"
                    );
            });

            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "text/plain";

                await context.HttpContext.Response.WriteAsync("Status code page, status code: " + context.HttpContext.Response.StatusCode);
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint($"/swagger/v1/swagger.json", "Loteria API V1"));
        }
    }
}
