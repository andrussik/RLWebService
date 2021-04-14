using System;
using System.Net.Http.Headers;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using DAL.AzureCognitiveSearch.Factory;
using DAL.Elasticsearch.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Solr.Factory;
using DAL.Urram.Factory;
using DTO.SearchEngine;
using Handlers.TokenHandlers;
using IdentityServerClient;
using LuceneSearchEngine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nest;
using SolrNet;
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

            var lucene = new LuceneSearchEngineCore();
            services.AddSingleton(lucene);

            services.AddSingleton<IElasticClient, ElasticClient>();
            services.AddSolrNet<Publication>("http://localhost:8983/solr/publication_core");

            var searchIndexClient = new SearchIndexClient(
                new Uri("https://rl-search-service.search.windows.net"),
                new AzureKeyCredential(Configuration["ApiKeys:RlAzureCognitiveSearchServiceApiKey"])
            );
            services.AddSingleton(searchIndexClient);

            var searchClient = new SearchClient(
                new Uri("https://rl-search-service.search.windows.net"),
                "publications",
                new AzureKeyCredential(Configuration["ApiKeys:RlAzureCognitiveSearchServiceApiKey"])
            );
            services.AddSingleton(searchClient);
            
            services.AddTransient<SierraTokenHandler>();
            services.AddTransient<RiksTokenHandler>();
            services.AddTransient<UrramTokenHandler>();

            services.AddScoped<ISierraRepositoryCollection, SierraRepositoryCollection>();
            services.AddScoped<IRiksRepositoryCollection, RiksRepositoryCollection>();
            services.AddScoped<IUrramRepositoryCollection, UrramRepositoryCollection>();
            
            services.AddScoped<IElasticsearchRepositoryCollection, ElasticsearchRepositoryCollection>();
            services.AddScoped<ISolrRepositoryCollection, SolrRepositoryCollection>();
            services.AddScoped<IAzureSearchRepositoryCollection, AzureSearchRepositoryCollection>();

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
            
            services.AddHttpClient("solr", c =>
            {
                c.BaseAddress = new Uri("http://localhost:8983/solr/");
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