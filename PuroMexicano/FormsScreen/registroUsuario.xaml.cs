using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using PuroMexicano.Clases;

namespace PuroMexicano.FormsScreen
{
    public partial class registroUsuario : ContentPage
    {
        public registroUsuario()
        {
            InitializeComponent();
        }

        public async void registra()
        {
            
            if (valida())
            {
                String result = await Task.Run<String>(() => { return SQL.insertUser(eEmail.Text, ePassword.Text, eUsuario.Text); });
                switch (result)
                {
                    case "existe":
                        await DisplayAlert("Registro", "Ya existe un usuario con este correo", "Aceptar");
                        eEmail.Text = "";
                        eEmail.Focus();
                        break;
                    case "nuevo":
                        await DisplayAlert("Registro", "Usuario registrado", "Aceptar");
                        await Navigation.PushAsync(new PuroMexicanoPage());
                        break;
                    default:
                        await DisplayAlert("Login", result, "Aceptar");
                        break;
                }

            }
            else
                await DisplayAlert("Error", "Datos incorrectos", "Aceptar");

        }

        private bool valida()
        {
            bool res = true;

            if (!globales.isEmail(eEmail.Text))
            {
                eEmail.Text = ePassword.Text = "";
                eEmail.Focus();
                res = false;
            }
            if (ePassword.Text.Length == 0)
            {
                ePassword.Text = "";
                ePassword.Focus();
                res = false;
            }
            if (eUsuario.Text.Length == 0 || eUsuario.Text.Length >= globales.Length_nombre)
            {
                eUsuario.Text = "";
                eUsuario.Focus();
                res = false;
            }
            return res;
        }


        void OnButtonClicked(object sender, EventArgs e)
        {
            registra();
        }
    }
}
