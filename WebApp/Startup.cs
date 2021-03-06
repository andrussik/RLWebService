using System;
using System.Net.Http.Headers;
using BLL.Factory;
using BLL.Services.App;
using BLL.Services.Contracts;
using DAL;
using DAL.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Sierra.Repositories.App;
using DAL.Sierra.Repositories.Contracts;
using DAL.Urram.Factory;
using Handlers.TokenHandlers;
using IdentityServerClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using IServiceCollection = BLL.Factory.IServiceCollection;
using ServiceCollection = BLL.Factory.ServiceCollection;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddTransient<SierraTokenHandler>();
            services.AddTransient<RiksTokenHandler>();
            services.AddTransient<UrramTokenHandler>();

            services.AddScoped<ISierraRepositoryCollection, SierraRepositoryCollection>();
            services.AddScoped<IRiksRepositoryCollection, RiksRepositoryCollection>();
            services.AddScoped<IUrramRepositoryCollection, UrramRepositoryCollection>();
            services.AddScoped<IServiceCollection, ServiceCollection>();
            services.AddScoped<IIdentityServerClient, IdentityServerClient.IdentityServerClient>();
            
            services.AddHttpClient("sierra",c =>
            {
                c.BaseAddress = new Uri("https://ester.ester.ee/iii/sierra-api/v6/");
            }).AddHttpMessageHandler<SierraTokenHandler>();
            
            services.AddHttpClient("riks",c =>
            {
                c.BaseAddress = new Uri("");
            }).AddHttpMessageHandler<RiksTokenHandler>();
            
            services.AddHttpClient("urram",c =>
            {
                c.BaseAddress = new Uri("");
            }).AddHttpMessageHandler<UrramTokenHandler>();

            services.AddHttpClient("sierraToken", c =>
            {
                var token = Configuration["ApiKeys:SierraApiKey"];
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", token);
                c.BaseAddress = new Uri("https://ester.ester.ee/iii/sierra-api/v6/token/");
            });
            
            services.AddHttpClient("riksToken", c =>
            {
                var token = Configuration["ApiKeys:RiksApiKey"];
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", token);
                // c.BaseAddress = new Uri("");
            });
            
            services.AddHttpClient("urramToken", c =>
            {
                var token = Configuration["ApiKeys:UrramApiKey"];
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", token);
                // c.BaseAddress = new Uri("");
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApp", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp v1"));
            }
            
            app.UseHttpsRedirection();
            
            app.UseCors("CorsAllowAll");
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}