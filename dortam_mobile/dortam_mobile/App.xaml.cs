using dortam_mobile.Services;
using dortam_mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dortam_mobile
{
    public interface appss
    {

    }
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<LocalDatabaseService>();
            DependencyService.Register<StorageService>();
            DependencyService.Register<ServiceProvider>();
            //MainPage = new LoginPage();
            MainPage = new AppShell();
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
