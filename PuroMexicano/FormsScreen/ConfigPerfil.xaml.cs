using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuroMexicano.Clases;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class ConfigPerfil : ContentPage
    {
        private String notificaciones;

        public ConfigPerfil()
        {
            InitializeComponent();
            Img.Source = Application.Current.Properties[key: "foto"].ToString();
            eEmail.Text = Application.Current.Properties[key: "email"].ToString();
            eUsuario.Text = Application.Current.Properties[key: "nombre"].ToString();
            eEdad.Text = Application.Current.Properties[key: "edad"].ToString();
            notificaciones = Application.Current.Properties[key: "notificaciones"].ToString();

            if (notificaciones == "1")
                bSi.BackgroundColor = Color.Pink;
            else
                bNo.BackgroundColor = Color.Pink;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int edad = -1;

                int.TryParse(eEdad.Text, out edad);
                if (edad >= 100)
                    eEdad.Text = "18";
                else
                    eEdad.Text = edad.ToString();
            }
            catch{
                eEdad.Text = "18";
            }
        }

        private bool valida()
        {
            bool res = true;

            if (!globales.isEmail(eEmail.Text))
            {
                eEmail.Text = Application.Current.Properties[key: "email"].ToString();
                eEmail.Focus();
                res = false;
            }
            if (int.Parse(eEdad.Text) < 18)
            {
                eEdad.Text = "18";
                eEdad.Focus();
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
            Button button = (Button)sender;

            this.notificaciones = (button.Text == "SI") ? "1" : "0";
            bSi.BackgroundColor = (notificaciones == "1")? (Color.Pink):(Color.White);
            bNo.BackgroundColor = (notificaciones == "0") ? (Color.Pink) : (Color.White);
        }

        void Save(object sender, EventArgs e)
        { 
            if(valida())
            {
                update();
            }
        }

        private async void update()
        {
            var result = await Task.Run<String>(() => { return SQL.updateUser(eUsuario.Text, eEmail.Text, eEdad.Text, notificaciones); });
            if(result == "Login")
            {
                await DisplayAlert("Configuraciones", "Perfil Actualizado", "Aceptar");
                Application.Current.MainPage = new NavigationPage(new Menu());
            }
        }
    }
}
