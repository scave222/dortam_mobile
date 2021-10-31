using dortam_mobile.Services;
using dortam_mobile.Utils;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;

namespace dortam_mobile.Settings
{
    public sealed class ApplicationSetting
    {
        private ApplicationSetting()
        {

        }

        private readonly static Lazy<ApplicationSetting> lazy = new Lazy<ApplicationSetting>(() => new ApplicationSetting());
        public static ApplicationSetting Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public Color DefaultColor
        {
            get
            {
                ApplicationSetting.Instance.DefaultColor = Color.Black;
                var value = Service.StorageService.Read<Color>(Constants.DefaultColor).Result;
                if (value == default)
                {
                    value = ApplicationSetting.Instance.DefaultColor = Color.Black;
                }
                return value;
            }
            set
            {
                Service.StorageService.Write<Color>(Constants.DefaultColor, value).Wait();
            }
        }
    }
}
