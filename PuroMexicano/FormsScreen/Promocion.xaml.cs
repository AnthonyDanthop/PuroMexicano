using System;
using System.Collections.Generic;
using PuroMexicano.Clases;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using PuroMexicano.FormsScreen.popUp;

namespace PuroMexicano.FormsScreen
{
    public partial class Promocion : ContentPage
    {
        private String _id;
        private promocion n;

        public Promocion()
        {
            InitializeComponent();


        }

        public Promocion(string id)
        {
            InitializeComponent();
            _id = id;
            n = globales.GetPromocion(_id);
            lNombre.Text = n.nombre;
            lDescripcion.Text = n.descripcion;
            lRestricciones.Text = n.restricciones;
            DateTime ini, fin;
            ini = DateTime.Parse(n.inicia);
            fin = DateTime.Parse(n.vigencia);

            lFechaV.Text = "De " + ini.Day + "/" + globales.MonthName(ini) + "/" + ini.Year + " " + ini.Hour + ":" + ini.Minute.ToString().PadLeft(2,'0') + " hrs " 
                         + "\nAl " + fin.Day + "/" + globales.MonthName(fin) + "/" + fin.Year + " " + fin.Hour + ":" + fin.Minute.ToString().PadLeft(2, '0') + " hrs ";
        }

        async void onValidate(object sender, System.EventArgs e)
        {
			if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
				await Navigation.PushAsync(new validaPromo(_id, n.codigo));
            }
            else
            {
                popUpLogin popUpLogin = new popUpLogin();
                await Navigation.PushPopupAsync(popUpLogin);

            }
            
        }
       
    }
}
