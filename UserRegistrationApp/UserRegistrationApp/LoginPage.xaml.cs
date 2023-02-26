using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserRegistrationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

       async private void Button_Clicked(object sender, EventArgs e)
        {
            if (uname.Text != "" && pwd.Text != "")
                await Navigation.PushAsync(new HomePage());
            else
                await DisplayAlert("Fail", "Login Failed", "Ok");
        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}