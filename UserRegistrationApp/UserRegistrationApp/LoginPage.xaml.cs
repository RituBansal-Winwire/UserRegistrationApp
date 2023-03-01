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
   
    public partial class LoginPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<User> _user;
        public LoginPage()
        {
            InitializeComponent();
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
            if (uname.Text != "" && pwd.Text != "")
            {
                foreach (var details in _user) {
                    if (uname.Text == details.UName && pwd.Text == details.Pwd) {
                        Application.Current.Properties["Name"] = uname.Text;
                        await Navigation.PushAsync(new HomePage());
                        return;
                    }
                }
                await DisplayAlert("Fail", "Login Failed", "Ok");
            }
            else
                await DisplayAlert("Fail", "Enter UserName and Password", "Ok");
        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
        
    }
}