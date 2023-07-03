using Depark.Contexts;
using Depark.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Depark.Services
{
    internal class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly CompanyDBContext context;
        private MainWindow? mainWindow;


        public ApplicationHostService(IServiceProvider serviceProvider, CompanyDBContext context)
        {
            this.serviceProvider = serviceProvider;
            this.context = context;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await InitializeAsync();

            await HandleActivationAsync();
        }

        private async Task InitializeAsync()
        {
            await context.Database.MigrateAsync();
        }

        private Task HandleActivationAsync()
        {
            mainWindow = serviceProvider.GetService(typeof(MainWindow)) as MainWindow ?? throw new Exception();
            mainWindow.Show();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}