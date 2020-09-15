using App.Views;
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
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(0, 20, 0, 0);
                    break;
            }
           

        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(usernameText.Text)
                || string.IsNullOrWhiteSpace(passwordText.Text))
            {
                DisplayAlert("Error", "Username or password are empty", "OK");
                return;
            }

            if(usernameText.Text == "admin@uteco.edu.do"
                || passwordText.Text == "Password")
            {
               await Navigation.PushModalAsync(new HomeView());
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password", "OK");
                return;
            }
        }
    }
}