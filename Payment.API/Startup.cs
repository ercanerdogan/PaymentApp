using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Payment.Infrastructure.Data;
using Payment.Core.Repositories.Base;
using Payment.Infrastructure.Repositories.Base;
using Payment.Core.Repositories;
using Payment.Infrastructure.Repositories;

namespace Payment.API
{
    public class Startup
    {
        private const string AllowCors = "AllowCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddCors(
               options => options.AddPolicy(AllowCors,
                   builder =>
                   {
                       builder.AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowAnyOrigin();
                   })
           );

            //ef core in-memory database
            services.AddDbContext<PaymentContext>(options =>
            {
                options.UseInMemoryDatabase("PaymentDB");
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Payment.API", 
                    Version = "v1" 
                });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            //services.AddTransient<IOrderRepository, OrderRepository>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment.API v1"));
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
