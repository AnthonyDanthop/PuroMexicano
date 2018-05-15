using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PuroMexicano.Clases;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();

			llenado();
           
        }

		private void llenado(){
			lCorreo.Text = "";
			if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
                lCorreo.Text = Application.Current.Properties[key: "email"].ToString();
                iFoto.Source = (Application.Current.Properties[key: "foto"].ToString() != "") ? (Application.Current.Properties[key: "foto"].ToString()) : ("puromex");

            }
		}

        async void configPerfil(object sender, System.EventArgs e)
        {
            if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
                await Navigation.PushAsync(new ConfigPerfil());
            }
        }

		private async void close(object sender, System.EventArgs e)
		{
			if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
			{
				globales.ToastInfo("Adios " + Application.Current.Properties[key: "nombre"].ToString());
				Application.Current.Properties.Clear();
				//Application.Current.MainPage = new NavigationPage(new PuroMexicanoPage());
				await Navigation.PushAsync(new PuroMexicanoPage());
			}
		}


        async void misPuntos_Click(object sender, System.EventArgs e)
        {
            if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
                await Navigation.PushAsync(new misPuntos());
            }
        }

		async void favoritos_Click(object sender, System.EventArgs e)
        {
            if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
				
					await Navigation.PushAsync(new negociosCat());
					
            }
        }

		async void miNegocio_Click(object sender, System.EventArgs e)
        {
            if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
                await Navigation.PushAsync(new miNegocio());
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
