using Heroes.Data;
using Heroes.DataGeneration;
using Heroes.Models;
using Heroes.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes
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
            services.AddDbContext<HeroesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HeroesDB")));
            //services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<IHeroRepository, HeroRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            //services.AddAutoMapper(typeof(Startup));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<HeroesContext>().AddDefaultTokenProviders();
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            /*
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Heroes", Version = "v1" });
            });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                Generator dataGenerator = new Generator(app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<HeroesContext>(), 
                                                        app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<User>>());
                dataGenerator.generate();
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Heroes v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
