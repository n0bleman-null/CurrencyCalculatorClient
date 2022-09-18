using CurrencyCalculatorClient.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CurrencyCalculatorClient.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ConverterWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterWindow"/> class.
        /// </summary>
        /// <param name="converterViewModel">The converter view model.</param>
        public ConverterWindow(ConverterViewModel converterViewModel)
        {
            InitializeComponent();

            DataContext = converterViewModel;
        }

        /// <summary>
        /// Numbers the validation text box.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextCompositionEventArgs"/> instance containing the event data.</param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
