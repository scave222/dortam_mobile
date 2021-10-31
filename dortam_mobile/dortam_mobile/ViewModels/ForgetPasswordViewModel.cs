using dortam_mobile.Models;
using dortam_mobile.Services;
using System;
using Xamarin.Forms;

namespace dortam_mobile.ViewModels
{
    public class ForgetPasswordViewModel : BaseViewModel
    {
        public Command ForgetPasswordCommand { get; }

        public ForgetPasswordViewModel()
        {
            ForgetPasswordCommand = new Command(OnForgetPasswordClicked);
        }

        #region Properties
        private string email = default(string);
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        #endregion

        private async void OnForgetPasswordClicked(object obj)
        {
            try
            {
                IsBusy = true;
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                {
                    var url = BaseUrl + "api/ForgotPassword?Email=" + Email;
                    var response = await GenericService.GetAsync<LoginResponse>(url);
                    if (response.status.ToLower() == "success")
                        App.Current.MainPage = new AppShell();
                    else if (response.status.ToLower().Contains("fail"))
                        await Application.Current.MainPage.DisplayAlert("oops", response.data, "Ok");
                    else
                        await Application.Current.MainPage.DisplayAlert("oops", "Somthing went wrong", "Ok");
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
