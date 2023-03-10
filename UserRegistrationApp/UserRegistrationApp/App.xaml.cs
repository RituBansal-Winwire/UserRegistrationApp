using System;
using UserRegistrationApp.Services;
using UserRegistrationApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserRegistrationApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
