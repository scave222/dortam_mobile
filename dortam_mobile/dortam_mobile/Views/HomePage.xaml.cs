using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dortam_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            AnimateCarousel();
        }
        Timer timer;
        private void AnimateCarousel()
        {
            timer = new Timer(5000) { AutoReset = true, Enabled = true };
            timer.Elapsed += (s, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (cvOnboarding.Position == 2)
                    {
                        cvOnboarding.Position = 0;
                    }
                    cvOnboarding.Position += 1;
                });
            };
        }
    }
}