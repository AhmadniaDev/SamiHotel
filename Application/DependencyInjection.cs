using Application.Behaviors;
using Application.Mapper;
using Application.Services.BackGroundService;
using Application.Services.BackGroundServices.Queue;
using Application.Services.BackGroundServices;
using Application.Services.CurrentUser;
using FluentValidation; 
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Application.Services.FileUpload;


namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) 
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PresetBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IFileUploadService, FileUploadService>();

            //services.AddValidatorsFromAssemblyContaining(typeof(AddProductValidator));

            services.AddAutoMapper(typeof(MapperProfile));
            //services.AddHostedService<MyBackGroundService>();

            //services.AddHostedService<QueuedHostedService>();
            //services.AddSingleton<IBackgroundTaskQueue>(ctx =>
            //{
            //    if (!int.TryParse(configuration["QueueCapacity"], out var queueCapacity))
            //        queueCapacity = 100;
            //    return new BackgroundTaskQueue(queueCapacity);
            //});





            //services.AddHangfire(config =>
            //    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            //                 .UseSimpleAssemblyNameTypeSerializer()
            //                 .UseRecommendedSerializerSettings()
            //                 .UseSqlServerStorage("Server=.\\SQL2;Database=hangFire;Trusted_Connection=True;TrustServerCertificate=True", new SqlServerStorageOptions
            //                 {
            //                     CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            //                     SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            //                     QueuePollInterval = TimeSpan.Zero,
            //                     UseRecommendedIsolationLevel = true,
            //                     UsePageLocksOnDequeue = true,
            //                     DisableGlobalLocks = true
            //                 }));

            //// Add the processing server as IHostedService
            //services.AddHangfireServer();



            //services.AddSignalR();
            //services.AddSingleton<IUserConnectionManager, UserConnectionManager>();
            return services;

        }
    }
}
