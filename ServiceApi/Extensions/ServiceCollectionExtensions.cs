using DeviceApi.Repositories;
using DeviceApi.Services;

namespace DeviceApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IDeviceService, DeviceService>();
            

            services.AddScoped(provider => new Lazy<ICityRepository>(() => provider.GetRequiredService<ICityRepository>()));
            services.AddScoped(provider => new Lazy<IDeviceRepository>(() => provider.GetRequiredService<IDeviceRepository>()));
            

            services.AddScoped(provider => new Lazy<ICityService>(() => provider.GetRequiredService<ICityService>()));
            services.AddScoped(provider => new Lazy<IDeviceService>(() => provider.GetRequiredService<IDeviceService>()));
            

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        //public static void AddCorsPolicy(this IServiceCollection services)
        //{
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy(name: ApiConstants.policyName, builder =>
        //        {
        //            builder.WithOrigins("https://localhost:7098")
        //            .AllowAnyHeader()
        //            .AllowAnyMethod();
        //        });
        //    });
        //}

        public static void AddCorsPolicy(this IServiceCollection services) =>
            services.AddCors(opt =>
            {
                opt.AddPolicy(ApiConstants.policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
    }
}
