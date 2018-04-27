using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using PuroMexicano.Clases;
using System.Threading.Tasks;

namespace PuroMexicano.FormsScreen
{
    public partial class loginFB : ContentPage
    {
        private const string ClientId = "1757055714352370";

        public loginFB()
        {
            InitializeComponent();
            ChecaConexion();

           
        }

        private async void existId()
        {
            
            var result = await Task.Run<String>(() => { return SQL.idFB_Server(ID.Text); });
            if(result == "Login")
            {
                eEmail.Text = Application.Current.Properties[key: "email"].ToString();

                eEmail.IsEnabled = false;
                await DisplayAlert("Login", "Bienvenido " + Application.Current.Properties[key: "nombre"].ToString(), "Aceptar");

                Application.Current.MainPage = new NavigationPage(new Menu());
            }
        }

        private void ChecaConexion()
        {


            //https://www.facebook.com/dialog/oauth?client_id=325767284569084&display=popup&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html
            var apiRequest = "https://www.facebook.com/dialog/oauth?client_id="
                + ClientId
                + "&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";

            var webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;

            Content = webView;
        }

        private async void aceptar(object sender, System.EventArgs e)
        {
            
            if(globales.isEmail(eEmail.Text))
            {
                var result = await Task.Run<String>(() => { return SQL.logInFB_Server(eEmail.Text, ID.Text, nombre.Text, Img.Source.ToString().Replace("Uri:", ""));});
                if(result == "Login")
                {
                    await DisplayAlert("Login", "Bienvenido " + Application.Current.Properties[key: "nombre"].ToString(), "Aceptar");

                    Application.Current.MainPage = new NavigationPage(new Menu());

                }
            }
        }


        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            try
            {
                var accessToken = ExtractAccessTokenFromUrl(e.Url);

                if (accessToken != "")
                {
                    Content.IsVisible = false;
                    var vm = BindingContext as FacebookViewModel;
                    await vm.SetFacebookUserProfileAsync(accessToken);

                    Content = MainStackLayout;
                    existId();
                }
            }
            catch (Exception exc)
            {
                await DisplayAlert("Error en FaceBook", exc.ToString(), "Aceptar");
            }
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                #pragma warning disable CS0612 // Type or member is obsolete
                #pragma warning disable CS0618 // Type or member is obsolete
                                if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                #pragma warning restore CS0618 // Type or member is obsolete
                #pragma warning restore CS0612 // Type or member is obsolete
                {
                    at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in=", StringComparison.Ordinal));

                return accessToken;
            }
            return string.Empty;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}

