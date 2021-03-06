using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperStudentDiscountApi.Domain;
using SuperStudentDiscountApi.Models;
using SuperStudentDiscountApi.Mapper;
using SuperStudentDiscountApi.Config;
using SuperStudentDiscountApi.Services;

namespace SuperStudentDiscountApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SuperStudentDiscountConfig());
            });

            var profiles = new List<Profile>{new SuperStudentDiscountConfig()};

            services.Configure<Settings>(options =>
            {
                options.ConnectionString 
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database 
                    = Configuration.GetSection("MongoConnection:Database").Value;
            });

            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    var origins = Configuration.GetSection("CORS:origins").GetChildren();
                    foreach(var origin in origins)
                    {
                        builder.WithOrigins(origin.Value).AllowAnyHeader();
                    }

                });
            });

            services.AddTransient<SuperStudentDiscountMap,SuperStudentDiscountMap>();
            services.AddTransient<SuperStudentDiscountCriteria,SuperStudentDiscountCriteria>();
            services.AddTransient<SuperStudentDiscountResultProcessor,SuperStudentDiscountResultProcessor>();
            services.AddAutoMapper(c=>c.AddProfiles(profiles),typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
