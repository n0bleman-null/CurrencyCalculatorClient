using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCalculatorClient.Models
{
    /// <summary>
    /// Currency price value
    /// </summary>
    public class CurrencyPriceModel
    {
        /// <summary>
        /// Gets or sets the abbreviation.
        /// </summary>
        /// <value>
        /// The abbreviation.
        /// </value>
        public string? Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }
    }
}
