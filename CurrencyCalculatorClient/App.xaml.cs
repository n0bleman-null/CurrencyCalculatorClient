using CurrencyCalculatorClient.Infrastructure.Options;
using CurrencyCalculatorClient.Models;
using CurrencyCalculatorClient.ViewModels;
using CurrencyCalculatorClient.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net;
using System.Windows;

namespace CurrencyCalculatorClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureServices(IServiceCollection services)
        {
            services.Configure<UdpServerOptions>(e =>
            {
                e.Address = IPAddress.Loopback;
                e.Port = 8085;
            });
            services.AddSingleton<ConverterModel>();
            services.AddSingleton<ConverterViewModel>();
            services.AddSingleton<ConverterWindow>();
        }

        /// <summary>
        /// Called when [startup].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="StartupEventArgs"/> instance containing the event data.</param>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<ConverterWindow>();
            mainWindow.Show();
        }
    }
}
