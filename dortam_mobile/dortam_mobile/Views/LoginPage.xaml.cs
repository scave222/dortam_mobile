using dortam_mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dortam_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        protected override void OnAppearing()
        {
            var colorFrame = Application.Current.RequestedTheme;
            if (colorFrame == OSAppTheme.Light)
                FrameColor.BackgroundColor = Color.White;
            else
                FrameColor.BackgroundColor = Color.Gray;
        }

        private void Register(object sender, EventArgs e)
        {
            App.Current.MainPage = new Register();
        }
        private void ForgetPassword(object sender, EventArgs e)
        {
            App.Current.MainPage = new ForgetPassword();
        }
    }
}