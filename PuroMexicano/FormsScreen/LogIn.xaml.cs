using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using PuroMexicano.Clases;
using Newtonsoft.Json;

namespace PuroMexicano.FormsScreen
{
    public partial class LogIn : ContentPage
    {

        public LogIn()
        {
            InitializeComponent();

        }

        public async void Login()
        {

            if (valida())
            {
                var result = await Task.Run<String>(() => { return SQL.logIn_Server(eEmail.Text, ePassword.Text); });
                switch (result)
                {
                    case "Login":
                        globales.ToastInfo( "Bienvenido " + Application.Current.Properties[key: "nombre"].ToString());

                        Application.Current.MainPage = new NavigationPage(new Menu());

                        break;
                    case "Password":
                        globales.Error("Contraseña incorrecta");
                        ePassword.Text = "";
                       
                        break;
                    case "email":
                        eEmail.Text = ePassword.Text = "";
                        globales.Error("Correo incorrecto");
                        break;
                    default:
                        await DisplayAlert("Login", result, "Aceptar");
                        break;
                }

            }
        }

        private bool valida()
        {
            bool res = true;

            if(!globales.isEmail(eEmail.Text))
            {
                eEmail.Text = ePassword.Text = "";
                eEmail.Focus();
                res = false;
            }
            if(ePassword.Text.Length == 0)
            {
                ePassword.Text = "";
                ePassword.Focus();
                res = false;
            }
            return res;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Login();
        }
    }
}
