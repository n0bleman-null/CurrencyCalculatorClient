using System;
using System.Runtime.InteropServices;

namespace CurrencyCalculatorClient.Infrastructure.Entities
{
    /// <summary>
    /// GetConversionRatesRequest
    /// </summary>
    public struct GetConversionRatesRequest
    {
        /// <summary>
        /// The currency code
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]

        public string CurrencyCode = "USD";
        /// <summary>
        /// The quantity
        /// </summary>
        public double Quantity = 0;

        /// <summary>
        /// The date
        /// </summary>
        public DateTime Date = DateTime.Today;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetConversionRatesRequest"/> struct.
        /// </summary>
        public GetConversionRatesRequest()
        {
        }
    }
}
