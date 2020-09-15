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
    public partial class PersonalInfoView : ContentPage
    {
        public PersonalInfoView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(nameText.Text))
            {
                DisplayAlert("Error", "Name is required", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(lasNameText.Text))
            {
                DisplayAlert("Error", "Last name is required", "OK");
                return;
            }

            DisplayAlert("Success", $"Data successfully saved.\r Name: {nameText.Text}\r Last name: {lasNameText.Text}", "OK");
        }
    }
}