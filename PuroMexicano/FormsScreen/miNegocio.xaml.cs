using System;
using System.Collections.Generic;
using PuroMexicano.Clases;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class miNegocio : ContentPage
    {
        public miNegocio()
        {
            InitializeComponent();
        }

		async void send(object sender, System.EventArgs e)
        {
			if (valida())
			{
				globales.ToastInfo("Informacion enviada");
				this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 1]);

				await Navigation.PopAsync();
			}
			else
				globales.ToastInfo("Todos los datos son necesarios");
				
        }

        private bool valida()
		{
			bool res = true;
			if (eEmail.Text.Length == 0 || eNombre.Text.Length == 0 || eContacto.Text.Length == 0 || eDireccion.Text.Length == 0 || eTelContacto.Text.Length == 0)
				res = false;

			return res;
		}
    }
}
