using Depark.Contexts;
using Depark.Contracts.Services;
using Depark.Services;
using Depark.ViewModels;
using Depark.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Depark
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddHostedService<ApplicationHostService>();

            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();

            services.AddDbContext<CompanyDBContext>();

            services.AddScoped<ICompanyService, CompanyService>();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
        }
    }
}