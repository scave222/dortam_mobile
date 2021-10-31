using dortam_mobile.ViewModels;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dortam_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgetPassword : ContentPage
    {
        public ForgetPassword()
        {
            InitializeComponent();
            this.BindingContext = new ForgetPasswordViewModel();
        }
    }
}