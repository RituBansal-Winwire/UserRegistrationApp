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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (FName.Text != "" && LName.Text != "" && email.Text != "" && phone.Text != "")
            {
                var response = await DisplayActionSheet("Save", "Ok", "Cancel", "Data Saved successfully");
                {
                    if (response == "Ok")
                    {
                        await Navigation.PopModalAsync();
                    }
                }
            }
            else {
                await DisplayAlert("Warning", "Please enter all the details", "Ok");
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}