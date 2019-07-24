using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ExploreCalifornia
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseExceptionHandler("/error.html");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                {
                    throw new Exception("ERROR!");
                }
                await next();

            });

            //app.Use(async (context,next) => // This is the only middleware regisererd
            //{
            //    if (context.Request.Path.Value.StartsWith("/hello"))
            //    {
            //        await context.Response.WriteAsync("Hello Asp.net Core!");
            //    }
            //    await next();
            //});

            //app.Run(async (context) => // This is the only middleware regisererd
            //{
            //    await context.Response.WriteAsync("Hey, How are ya!");
            //});

            app.UseFileServer();
        }
    }
}
