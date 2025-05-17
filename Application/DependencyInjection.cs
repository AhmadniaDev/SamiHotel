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

           

            services.AddAutoMapper(typeof(MapperProfile));
         

            return services;

        }
    }
}
