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
                        await DisplayAlert("Login", "Bienvenido " + Application.Current.Properties[key: "nombre"].ToString(), "Aceptar");

                        Application.Current.MainPage = new NavigationPage(new Menu());
                        break;
                    case "Password":
                        await DisplayAlert("Login", "Contraseña incorrecta", "Aceptar");
                        ePassword.Text = "";
                        ePassword.Focus();
                       
                        break;
                    case "email":
                        eEmail.Text = ePassword.Text = "";
                        eEmail.Focus();
                        await DisplayAlert("Login", "Correo incorrecto", "Aceptar");
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
