using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserRegistrationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserList : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<User> _user;
        public UserList()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQlliteDb>().GetConnection();
        }
        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<User>();
            var user = await _connection.Table<User>().ToListAsync();
            _user = new ObservableCollection<User>(user);
           
            lstView.ItemsSource = _user;
            base.OnAppearing();
        }
    }
}