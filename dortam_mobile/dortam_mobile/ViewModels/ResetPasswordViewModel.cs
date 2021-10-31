using System;
using dortam_mobile.Models;
using dortam_mobile.Services;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace dortam_mobile.ViewModels
{
    public class ResetPasswordViewModel : BaseViewModel
    {
        public Command ResetPasswordCommand { get; }

        public ResetPasswordViewModel()
        {
            ResetPasswordCommand = new Command(OnResetPasswordClicked);
        }

        #region Properties

        private string newPassword = default(string);
        public string NewPassword
        {
            get { return newPassword; }
            set { SetProperty(ref newPassword, value); }
        }

        private string confirmPassword = default(string);
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { SetProperty(ref confirmPassword, value); }
        }

        private string token = default(string);
        public string Token
        {
            get { return token; }
            set { SetProperty(ref token, value); }
        }
        #endregion

        private async void OnResetPasswordClicked(object obj)
        {
            try
            {
                IsBusy = true;
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                {
                    var url = BaseUrl + "api/ResetPassword?NewPassword=" + NewPassword + "&ConfirmPassword=" + ConfirmPassword + "&Token=" + Token;
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
