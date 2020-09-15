using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingWorkDetails : ContentPage
    {
        public PendingWorkDetails(Works model)
        {
            InitializeComponent();

            titleText.Text = model.Title;
            descriptionText.Text = model.Description;
            dateText.Text = model.Date.ToString();
            pendingDaysText.Text = model.MissingDates.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //}
    }
}