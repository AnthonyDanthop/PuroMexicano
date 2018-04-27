using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
            lCorreo.Text = "";

            if(bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
                lCorreo.Text = Application.Current.Properties[key: "email"].ToString();
                iFoto.Source = Application.Current.Properties[key: "foto"].ToString();

            }
        }

        async void configPerfil(object sender, System.EventArgs e)
        {
            if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
                await Navigation.PushAsync(new ConfigPerfil());
            }
        }

        async void misPuntos_Click(object sender, System.EventArgs e)
        {
            if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
                await Navigation.PushAsync(new misPuntos());
            }
        }
        async void obtenerPuntos_Click(object sender, System.EventArgs e)
        {
            if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
                await Navigation.PushAsync(new obtenerPuntos());
            }
        }
    }
}
