using System.Runtime.InteropServices;

namespace CurrencyCalculatorClient.Infrastructure.Entities
{
    /// <summary>
    /// GetConversionRatesResponse
    /// </summary>
    public struct GetConversionRatesResponse
    {
        /// <summary>
        /// The abbreviation
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string Abbreviation;

        /// <summary>
        /// The value
        /// </summary>
        public decimal Value;
    }
}
