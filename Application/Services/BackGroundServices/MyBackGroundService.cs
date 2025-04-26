using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BackGroundService
{
    public class MyBackGroundService : BackgroundService
    {
        private readonly ILogger<MyBackGroundService> _logger;
        public MyBackGroundService(ILogger<MyBackGroundService> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MyBackgroundService is starting.");

            stoppingToken.Register(() =>
                _logger.LogInformation("MyBackgroundService is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("MyBackgroundService is doing background work.");

                // Simulate background work
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            _logger.LogInformation("MyBackgroundService has stopped.");
        }
    }
}
