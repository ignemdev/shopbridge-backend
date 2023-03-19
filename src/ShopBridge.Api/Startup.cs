using ShopBridge.Core;
using ShopBridge.Data;

namespace ShopBridge.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Donde se configuran los servicios
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            #region configurations
            services.AddDbContextConfiguration(Configuration);

            services.AddCors();

            services
                .AddControllers()
                .AddJsonConfigurations();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            #endregion

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddEntitiesServices();
            services.AddAutoMapper(typeof(Startup));
        }
        /// <summary>
        /// Donde se configuran los middlewares y el request pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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