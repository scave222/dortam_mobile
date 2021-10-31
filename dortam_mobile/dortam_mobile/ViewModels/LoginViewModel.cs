using dortam_mobile.Models;
using dortam_mobile.Services;
using dortam_mobile.Utils;
using dortam_mobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace dortam_mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        #region Properties
        private string email = default(string);
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string password = default(string);
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        #endregion

        private async void OnLoginClicked(object obj)
        {
            try
            {
                IsBusy = true;
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                {
                    //using (await CustomAlert.LoadingDialogAsync())
                    //{
                    var url = BaseUrl + "api/login?Password=" + Password + "&Email=" + Email;
                    var response = await GenericService.GetAsync<LoginResponse>(url);
                    if (response.status.ToLower() == "success")
                        App.Current.MainPage = new AppShell();
                    else if (response.status.ToLower().Contains("fail"))
                        await Application.Current.MainPage.DisplayAlert("oops", response.data, "Ok");
                    else
                        await Application.Current.MainPage.DisplayAlert("oops", "Somthing went wrong", "Ok");
                    //}
                }

                else
                    await Application.Current.MainPage.DisplayAlert("oops", "No network connection", "Ok");
                IsBusy = false;
            }
            catch (Exception e)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("oops", "Somthing went wrong", "Ok");
            }

        }
    }

}
