using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CurrencyCalculatorClient.Infrastructure.Entities;
using CurrencyCalculatorClient.Models;
using CurrencyCalculatorClient.ViewModels.Base;

namespace CurrencyCalculatorClient.ViewModels
{
    /// <summary>
    /// Converter ViewModel
    /// </summary>
    /// <seealso cref="CurrencyCalculatorClient.ViewModels.Base.ViewModelBase" />
    public sealed class ConverterViewModel : ViewModelBase
    {
        private readonly ConverterModel _model;
        private double _quantity = 100;
        private DateTime _date = DateTime.Now;
        private string _currencyCode = "USD";
        private List<CurrencyPriceModel> _data = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public ConverterViewModel(ConverterModel model) =>
            (_model) = (model);

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public double Quantity
        {
            get => _quantity;
            set => Update(ref _quantity, value);
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date
        {
            get => _date;
            set => Update(ref _date, value);
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode
        {
            get => _currencyCode;
            set => Update(ref _currencyCode, value);
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<CurrencyPriceModel> Data
        {
            get => _data;
            set => Update(ref _data, value);
        }

        /// <summary>
        /// Gets the convert currency command.
        /// </summary>
        /// <value>
        /// The convert currency command.
        /// </value>
        public ICommand ConvertCurrencyCommand
            => new Command(_ => _model.ConvertCurrency(Quantity, Date, CurrencyCode, onUpdate).GetAwaiter().GetResult());

        /// <summary>
        /// On update action.
        /// </summary>
        /// <param name="data">The data.</param>
        private void onUpdate(List<GetConversionRatesResponse> data)
        {
            Data = data.Select(e => new CurrencyPriceModel
            {
                Abbreviation = e.Abbreviation,
                Value = e.Value,
            }).ToList();
        }
    }
}