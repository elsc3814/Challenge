using Challenge.Models;
using Challenge.Services;
using ChallengeDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Challenge
{
    public class Startup
    {
        private readonly string _corsPolicyName = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Challenge", Version = "v1"}); });

            services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicyName,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
                    });
            });

            services.AddDbContext<ChallengeContext>(options =>
            {
                var context = Configuration.GetConnectionString("ChallengeContext");
                options.UseSqlServer(context, o => o.EnableRetryOnFailure());
            });

            services.Configure<JDoodleOptions>(Configuration.GetSection("JDoodle"));
            services.AddTransient<IJDoodleService, JDoodleService>();
            services.AddHttpClient<JDoodleService>();

            services.AddTransient<IChallengeStore, ChallengeStore>();

            services.AddTransient<IChallengesService, ChallengesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Challenge v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(_corsPolicyName);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}