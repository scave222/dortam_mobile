using dortam_mobile.Models;
using dortam_mobile.Services;
using dortam_mobile.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace dortam_mobile.ViewModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        public Command ChangePasswordCommand { get; }

        public ChangePasswordViewModel()
        {
            ChangePasswordCommand = new Command(OnChangePasswordClicked);
        }

        #region Properties
        private string password = default(string);
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

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
        #endregion

        private async void OnChangePasswordClicked(object obj)
        {
            try
            {
                IsBusy = true;
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                {
                    var url = BaseUrl + "api/ChangePassword?oldPassword=" + Password + "&newPassword=" + NewPassword + "&ConfirmPassword=" + ConfirmPassword;
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
                await Application.Current.MainPage.DisplayAlert("oops", "Somthing went wrong", "Ok");
                IsBusy = false;
            }
        }
    }
}
