using dortam_mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dortam_mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
		public Register()
		{
			InitializeComponent();
			this.BindingContext = new RegisterViewModel();
		}

		private void Login(object sender, EventArgs e)
		{
			App.Current.MainPage = new LoginPage();
		}
	}

}