using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NodaTime;
using PuroMexicano.Clases;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class Negocio : ContentPage
    {
        private string _id;
		private bool isFavoito;

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
			this.Favorito();
        }

        private async void Favorito()
		{
			string query = "SELECT `F`.`id_negocio` FROM `favoritos` AS `F` where `F`.`id_usuario` = "
                   + Application.Current.Properties[key: "id"].ToString() + " and `F`.`id_negocio` = " + _id;

            var _result = await Task.Run<String>(() => { return SQL.queryResult(query); });

			if (_result != "NULL")
			{
				fav.Image = "corazon_morado";
				isFavoito = true;
			}
			else
			{
				fav.Image = "corazon";
				isFavoito = false;
			}
			
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

		async void addFavorito(object sender, System.EventArgs e)
        {
			if (bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
            {
				String query = "";
				String msj = "Favorito ";
				if(isFavoito)
				{
					query = "DELETE FROM `favoritos` where `id_usuario` = "
                   + Application.Current.Properties[key: "id"].ToString() + " and `id_negocio` = " + _id;
					msj += " eliminado";
					fav.Image = "corazon";

				}
				else
				{
					query = "INSERT INTO `favoritos`(`id_usuario`, `id_negocio`) VALUES (" + Application.Current.Properties[key: "id"].ToString() + ", " + _id + ")";
					msj += " agregado";
					fav.Image = "corazon_morado";
				}
				isFavoito = !isFavoito;
				await Task.Run<String>(() => { return SQL.queryResult(query); });
				globales.success(msj);

            }
            else
            {
                globales.success("Es necesario iniciar sesión");
            }
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
