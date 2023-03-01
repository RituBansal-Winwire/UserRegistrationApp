using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<User> _user;
        public RegisterPage ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQlliteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<User>();
            var user = await _connection.Table<User>().ToListAsync();
            _user = new ObservableCollection<User>(user);
            base.OnAppearing();
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
                        var user = new User { FName = FName.Text, LName = LName.Text, Email = email.Text, Phone = Convert.ToInt16(phone.Text), UName = UName.Text, Pwd = Pwd.Text };
                        await _connection.InsertAsync(user);
                        ClearFields();
                        return;
                    }
                }

            }
            else {
                await DisplayAlert("Warning", "Please enter all the details", "Ok");
            }
        }

        private void ClearFields()
        {
            FName.Text = "";
            LName.Text = "";
            email.Text = "";
            phone.Text = "";
            UName.Text = "";
            Pwd.Text = "";
        }
    }
}