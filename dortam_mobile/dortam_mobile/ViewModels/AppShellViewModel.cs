using dortam_mobile.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace dortam_mobile.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        public Color backgroundColor = ApplicationSetting.Instance.DefaultColor;
    }
}
