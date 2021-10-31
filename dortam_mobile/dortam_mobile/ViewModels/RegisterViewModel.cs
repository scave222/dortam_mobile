using dortam_mobile.Models;
using dortam_mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace dortam_mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
        }

        #region Properties
        private string firstName = default(string);
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        private string middleName = default(string);
        public string MiddleName
        {
            get { return middleName; }
            set { SetProperty(ref middleName, value); }
        }

        private string lastName = default(string);
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        private string password = default(string);
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private string confirmPassword = default(string);
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { SetProperty(ref confirmPassword, value); }
        }

        private string email = default(string);
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        #endregion

        private async void OnRegisterClicked(object obj)
        {
            try
            {
                IsBusy = true;
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                {
                    var url = BaseUrl + "api/register?FirstName=" + FirstName + "&MiddleName=" + MiddleName + "&LastName=" + LastName + "&Password=" + Password + "&ConfirmPassword=" + ConfirmPassword + "&Email=" + Email;
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
