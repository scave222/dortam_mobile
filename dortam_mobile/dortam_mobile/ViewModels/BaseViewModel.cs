using dortam_mobile.Interface;
using dortam_mobile.Models;
using dortam_mobile.Services;
using dortam_mobile.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace dortam_mobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //public readonly IHttpClientService refitService;
        protected string BaseUrl = Constants.BaseUrl;
        public ILocalDatabaseService LocalDatabaseService => DependencyService.Get<ILocalDatabaseService>();
        public IStorageService StorageService => DependencyService.Get<IStorageService>();
        public BaseViewModel()
        {
            // refitService = Refit.RestService.For<IHttpClientService>(new System.Net.Http.HttpClient() { BaseAddress = new Uri(Constants.BaseUrl), Timeout = TimeSpan.FromMinutes(60) });
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
