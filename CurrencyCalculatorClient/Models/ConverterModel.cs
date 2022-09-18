using CurrencyCalculatorClient.Infrastructure.Entities;
using CurrencyCalculatorClient.Infrastructure.Extensions;
using CurrencyCalculatorClient.Infrastructure.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyCalculatorClient.Models
{
    /// <summary>
    /// Converter model
    /// </summary>
    public sealed class ConverterModel
    {
        private readonly UdpServerOptions _udpServerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterModel"/> class.
        /// </summary>
        /// <param name="udpServerOptions">The UDP server options.</param>
        public ConverterModel(IOptions<UdpServerOptions> udpServerOptions)
        {
            _udpServerOptions = udpServerOptions.Value;
        }

        /// <summary>
        /// Converts the currency.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <param name="date">The date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="onUpdate">The on update.</param>
        /// <exception cref="System.ApplicationException">Invalid argumants</exception>
        public async Task ConvertCurrency(double quantity, DateTime date, string currencyCode, Action<List<GetConversionRatesResponse>> onUpdate)
        {           
            try
            {
                if (string.IsNullOrWhiteSpace(currencyCode) || quantity < 0 || date > DateTime.Now)
                {
                    throw new ApplicationException("Invalid argumants");
                }

                using var listener = new UdpClient();

                var request = new GetConversionRatesRequest
                {
                    Quantity = quantity,
                    Date = date,
                    CurrencyCode = currencyCode
                };

                await listener.SendAsync(request.GetBytes(),
                    new IPEndPoint(_udpServerOptions.Address, _udpServerOptions.Port)).ConfigureAwait(false);

                var response = await listener.ReceiveAsync().ConfigureAwait(false);

                if (response.Buffer.Length == 0)
                    throw new ApplicationException("Invalid argumants");

                var models = response.Buffer.FromBytesArray<GetConversionRatesResponse>();

                onUpdate(models.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Try again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}