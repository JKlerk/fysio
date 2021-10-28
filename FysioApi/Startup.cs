using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using FysioAPI.GraphQL;
using FysioAPI.GraphQL.Types;
using GraphQL.Utilities;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Infrastructure.WebService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;


namespace FysioAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method getsd called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApiContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("ApiContext"), x => x.MigrationsAssembly("Infrastructure.WebService")));

            services.AddScoped<IDiagnoseRepository, DiagnoseRepository>();
            services.AddScoped<ITreatmentTypeRepository, TreatmentTypeRepository>();
            services.AddScoped<Query>();  
            services.AddScoped<Mutation>();

            services.AddGraphQLServer().AddQueryType<Query>().AddType<DiagnoseType>()
                .AddType<GraphQL.Types.TreatmentType>().AddMutationType<Mutation>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FysioAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api",
                    Path = "/playground"
                });
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FysioAPI v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllers();
            });
        }
    }
}
