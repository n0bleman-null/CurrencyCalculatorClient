using System.Net;

namespace CurrencyCalculatorClient.Infrastructure.Options
{
    /// <summary>
    /// Udp server pptions
    /// </summary>
    public class UdpServerOptions
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public IPAddress Address { get; set; } = IPAddress.Any;

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port { get; set; }
    }
}
