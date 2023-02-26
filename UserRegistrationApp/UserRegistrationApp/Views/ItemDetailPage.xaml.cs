using System.ComponentModel;
using UserRegistrationApp.ViewModels;
using Xamarin.Forms;

namespace UserRegistrationApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}