using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.Material.Forms.Resources;
using XF.Material.Forms.UI;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace dortam_mobile.Utils
{
    public static class CustomAlert
    {
        public static async Task AlertDialogAsync(string Msg, string Title)
        {
            MaterialInputDialogConfiguration alertDialogConfiguration = new MaterialInputDialogConfiguration()
            {
                InputType = MaterialTextFieldInputType.Text,
                CornerRadius = 8,
                BackgroundColor = Color.FromHex("#103E72"),
                InputTextColor = Color.White,
                InputPlaceholderColor = Color.White.MultiplyAlpha(0.6),
                TintColor = Color.White,
                TitleTextColor = Color.White,
                MessageFontFamily = "ThemeFontMedium",
                MessageTextColor = Color.FromHex("#DEFFFFFF")
            };
            await MaterialDialog.Instance.AlertAsync(message: Msg,
                                                            title: Title,
                                                            acknowledgementText: "Got It",
                                                            configuration: alertDialogConfiguration);
        }
        public static async Task<IMaterialModalPage> LoadingDialogAsync(string message = "Loading, please wait...")
        {
            try
            {
                MaterialLoadingDialogConfiguration loadingDialogConfiguration = new MaterialLoadingDialogConfiguration()
                {
                    BackgroundColor = Color.FromHex("#103E72"),
                    MessageTextColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.ON_PRIMARY).MultiplyAlpha(0.8),
                    TintColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.ON_PRIMARY),
                    CornerRadius = 8,
                    MessageFontFamily = "ThemeFontBold",
                    ScrimColor = Color.FromHex("#232F34").MultiplyAlpha(0.32)
                };

                return await MaterialDialog.Instance.LoadingDialogAsync(message: message,
                                                                 configuration: loadingDialogConfiguration);
            }
            catch (Exception e)
            {
                return default;
            }

        }

        public static async Task AlertSnackbarAsync(string Msg, string ButtonText)
        {
            await MaterialDialog.Instance.SnackbarAsync(message: Msg,
                                actionButtonText: ButtonText,
                       msDuration: 3000);
        }
    }
}
