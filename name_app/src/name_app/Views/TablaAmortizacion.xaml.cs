using name_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace name_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablaAmortizacion : ContentPage
    {
        List<AmortizacionOutputDTO> amortizacion = Enumerable.Empty<AmortizacionOutputDTO>().ToList();
        public TablaAmortizacion()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(0, 20, 0, 0);
                    break;
            }

            Months.ItemsSource = new List<int>()
            {
               1, 2, 3, 4,5,6,7,8,9,10,11,12
            };

            AmortizacionListView.IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            double loanAmount = 0;
            double loanRate = 0;
            var amount = Amount.Text;
            var rate = LoanRate.Text;

            int selectedIndexMonths = ((Picker)Months).SelectedIndex;

            if (selectedIndexMonths < 0
                || !Double.TryParse(amount, out loanAmount)
                || !Double.TryParse(rate, out loanRate)
                || loanAmount <=0
                || loanRate<=0 )
            {

                DisplayAlert("Error", "Some values are empty", "OK");
                return;
            }

            CalculateAmortizacion(loanAmount, loanRate);
        }

        private void CalculateAmortizacion(double loanAmount, double loanRate)
        {
            var months = (Picker)Months;
            int selectedIndexMonths = months.SelectedIndex;

            var monthsNumber = (int)months.ItemsSource[selectedIndexMonths];
            double t = loanRate / 1200;
            double b = Math.Pow((1 + t), monthsNumber);
            var montlyAmount = Math.Round(t * loanAmount * b / (b - 1),2);
            loanMontlyAmount.Text = montlyAmount.ToString("C2");

            var decimalLoanRate = loanRate / 100;
            for (int i=0;i<= monthsNumber; i++)
            {
                var amortiz = new AmortizacionOutputDTO();

                amortiz.Periodo = i;
                if (i == 0)
                {
                    amortiz.Cuota = 0;
                    amortiz.Capital = 0;
                    amortiz.Interes = 0;
                    amortiz.Balance = loanAmount;
                }
                else
                {
                    amortiz.Cuota = montlyAmount;
                    amortiz.Interes = Math.Round((loanAmount / monthsNumber) * decimalLoanRate, 2);
                    amortiz.Capital = Math.Round(amortiz.Cuota- amortiz.Interes,2);

                    var pendingBalance = Math.Round(loanAmount - amortiz.Capital,2);
                    amortiz.Balance = pendingBalance < 0 ? 0 : pendingBalance;
                    loanAmount = amortiz.Balance;
                }

                amortizacion.Add(amortiz);
            }

            AmortizacionListView.IsVisible = true;
            ListTitle.IsVisible = true;
            AmortizacionListView.ItemsSource = amortizacion;
        }

        void Amortizacion_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as AmortizacionOutputDTO;
            if (selectedItem == null) { return; }

            var details = string.Format("Cuota: {0}\n\rCapital: {1}\n\rInteres: {2}\n\rBalance Pendiente{3}", selectedItem.Cuota.ToString("C2"),
                selectedItem.Capital.ToString("C2"), selectedItem.Interes.ToString("C2"), selectedItem.Balance.ToString("C2"));

            DisplayAlert($"Amortización del periodo {selectedItem.Periodo}", details, "Ok");
            // AmortizacionListView.SelectedItem = null;
        }
    }
}