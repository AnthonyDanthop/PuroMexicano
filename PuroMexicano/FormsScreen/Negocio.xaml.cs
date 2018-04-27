using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NodaTime;
using PuroMexicano.Clases;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class Negocio : ContentPage
    {
       private string _id;

        public Negocio(String id)
        {
            InitializeComponent();
            _id = id;
            iniImage();

            negocio n = globales.GetNegocio(_id);
            lNombre.Text = n.Nombre;
            lDesc.Text = n.descripcion;
            lHorario.Text = n.horario;
            this.setStar(int.Parse(n.rating));
        }

        private void setStar(int reiting)
        {
            switch (reiting)
            {
                case 0:
                    star1.Source = null;
                    star2.Source = null;
                    star3.Source = null;
                    star4.Source = null;
                    star5.Source = null;
                    break;
                case 1:
                    star2.Source = null;
                    star3.Source = null;
                    star4.Source = null;
                    star5.Source = null;
                    break;
                case 2:
                    star3.Source = null;
                    star4.Source = null;
                    star5.Source = null;
                    break;
                case 3:
                    star4.Source = null;
                    star5.Source = null;
                    break;
                case 4:
                    star5.Source = null;
                    break;
                case 5:
                    break;
                default:
                    star1.Source = null;
                    star2.Source = null;
                    star3.Source = null;
                    star4.Source = null;
                    star5.Source = null;
                    break;
            }
        }

        async void viewPromociones(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new negociosCat(int.Parse(_id)));
        }

        private async void iniImage()
        {
            var _result = await Task.Run<String>(() => { return SQL.getImgNegocio(_id); });
            var images = new List<string>();
            if (_result == "List")
            {
                foreach (imgNegocio it in globales.limgNeg)
                {
                    images.Add(it.Nombre);
                }

            }

            TutoCarousel.ItemsSource = images;
           
        }

    }
}
