using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PuroMexicano.Clases;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class validaPromo : ContentPage
    {
        private int []puntaje;
        private String _idPromo;

        public validaPromo(String id, String Codigo)
        {
            InitializeComponent();
            _idPromo = id;
            
            lCodigo.Text = Codigo;//temp 
            loadCalif();
        }


        private async void loadCalif()
        {
            puntaje = new int[5];
            var result = await Task.Run<String>(() => { return SQL.calificaPromocion(_idPromo, null, true); });

            if (result != "none" && result != "Fail")
            {
                CalificacionPromo promo = JsonConvert.DeserializeObject<CalificacionPromo>(result);
                setStar("0" + promo.limpieza);
                setStar("1" + promo.servicioCliente);
                setStar("2" + promo.rapidez);
                setStar("3" + promo.calidad);
                setStar("4" + promo.precio);
            }
            else
            {
                setStar("05");
                setStar("15");
                setStar("25");
                setStar("35");
                setStar("45");
            }
        }

        async void setCalif(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            String name = button.ClassId;
            setStar(name);
        }
               
        async void updateCalif(object sender, System.EventArgs e)
        {
            var result = await Task.Run<String>(() => { return SQL.calificaPromocion(_idPromo, puntaje); });
            if(result == "done")
            {
                globales.ToastInfo("Gracias por tu puntuación");
                this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 1]);
                this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);

                await Navigation.PopAsync();
            }
        }

        private void setStar(string seccion)
        {
            String i, j;
            i = seccion.Substring(0, 1);
            j = seccion.Substring(1);

            switch(i)
            {
                case "0":
                    switch(j)
                    {
                        case "1":
                            Star01.Image = "star_on";
                            Star02.Image = "star_off";
                            Star03.Image = "star_off";
                            Star04.Image = "star_off";
                            Star05.Image = "star_off";
                            puntaje[0] = 1;
                            break;
                        case "2":
                            Star01.Image = "star_on";
                            Star02.Image = "star_on";
                            Star03.Image = "star_off";
                            Star04.Image = "star_off";
                            Star05.Image = "star_off";
                            puntaje[0] = 2;
                            break;
                        case "3":
                            Star01.Image = "star_on";
                            Star02.Image = "star_on";
                            Star03.Image = "star_on";
                            Star04.Image = "star_off";
                            Star05.Image = "star_off";
                            puntaje[0] = 3;
                            break;
                        case "4":
                            Star01.Image = "star_on";
                            Star02.Image = "star_on";
                            Star03.Image = "star_on";
                            Star04.Image = "star_on";
                            Star05.Image = "star_off";
                            puntaje[0] = 4;
                            break;
                        case "5":
                            Star01.Image = "star_on";
                            Star02.Image = "star_on";
                            Star03.Image = "star_on";
                            Star04.Image = "star_on";
                            Star05.Image = "star_on";
                            puntaje[0] = 5;
                            break;
                    }
                    break;
                case "1":
                    switch (j)
                    {
                        case "1":
                            Star11.Image = "star_on";
                            Star12.Image = "star_off";
                            Star13.Image = "star_off";
                            Star14.Image = "star_off";
                            Star15.Image = "star_off";
                            puntaje[1] = 1;
                            break;
                        case "2":
                            Star11.Image = "star_on";
                            Star12.Image = "star_on";
                            Star13.Image = "star_off";
                            Star14.Image = "star_off";
                            Star15.Image = "star_off";
                            puntaje[1] = 2;
                            break;
                        case "3":
                            Star11.Image = "star_on";
                            Star12.Image = "star_on";
                            Star13.Image = "star_on";
                            Star14.Image = "star_off";
                            Star15.Image = "star_off";
                            puntaje[1] = 3;
                            break;
                        case "4":
                            Star11.Image = "star_on";
                            Star12.Image = "star_on";
                            Star13.Image = "star_on";
                            Star14.Image = "star_on";
                            Star15.Image = "star_off";
                            puntaje[1] = 4;
                            break;
                        case "5":
                            Star11.Image = "star_on";
                            Star12.Image = "star_on";
                            Star13.Image = "star_on";
                            Star14.Image = "star_on";
                            Star15.Image = "star_on";
                            puntaje[1] = 5;
                            break;
                    }
                    break;
                case "2":
                    switch (j)
                    {
                        case "1":
                            Star21.Image = "star_on";
                            Star22.Image = "star_off";
                            Star23.Image = "star_off";
                            Star24.Image = "star_off";
                            Star25.Image = "star_off";
                            puntaje[2] = 1;
                            break;
                        case "2":
                            Star21.Image = "star_on";
                            Star22.Image = "star_on";
                            Star23.Image = "star_off";
                            Star24.Image = "star_off";
                            Star25.Image = "star_off";
                            puntaje[2] = 2;
                            break;
                        case "3":
                            Star21.Image = "star_on";
                            Star22.Image = "star_on";
                            Star23.Image = "star_on";
                            Star24.Image = "star_off";
                            Star25.Image = "star_off";
                            puntaje[2] = 3;
                            break;
                        case "4":
                            Star21.Image = "star_on";
                            Star22.Image = "star_on";
                            Star23.Image = "star_on";
                            Star24.Image = "star_on";
                            Star25.Image = "star_off";
                            puntaje[2] = 4;
                            break;
                        case "5":
                            Star21.Image = "star_on";
                            Star22.Image = "star_on";
                            Star23.Image = "star_on";
                            Star24.Image = "star_on";
                            Star25.Image = "star_on";
                            puntaje[2] = 5;
                            break;
                    }
                    break;
                case "3":
                    switch (j)
                    {
                        case "1":
                            Star31.Image = "star_on";
                            Star32.Image = "star_off";
                            Star33.Image = "star_off";
                            Star34.Image = "star_off";
                            Star35.Image = "star_off";
                            puntaje[3] = 1;
                            break;
                        case "2":
                            Star31.Image = "star_on";
                            Star32.Image = "star_on";
                            Star33.Image = "star_off";
                            Star34.Image = "star_off";
                            Star35.Image = "star_off";
                            puntaje[3] = 2;
                            break;
                        case "3":
                            Star31.Image = "star_on";
                            Star32.Image = "star_on";
                            Star33.Image = "star_on";
                            Star34.Image = "star_off";
                            Star35.Image = "star_off";
                            puntaje[3] = 3;
                            break;
                        case "4":
                            Star31.Image = "star_on";
                            Star32.Image = "star_on";
                            Star33.Image = "star_on";
                            Star34.Image = "star_on";
                            Star35.Image = "star_off";
                            puntaje[3] = 4;
                            break;
                        case "5":
                            Star31.Image = "star_on";
                            Star32.Image = "star_on";
                            Star33.Image = "star_on";
                            Star34.Image = "star_on";
                            Star35.Image = "star_on";
                            puntaje[3] = 5;
                            break;
                    }
                    break;
                case "4":
                    switch (j)
                    {
                        case "1":
                            Star41.Image = "star_on";
                            Star42.Image = "star_off";
                            Star43.Image = "star_off";
                            Star44.Image = "star_off";
                            Star45.Image = "star_off";
                            puntaje[4] = 1;
                            break;
                        case "2":
                            Star41.Image = "star_on";
                            Star42.Image = "star_on";
                            Star43.Image = "star_off";
                            Star44.Image = "star_off";
                            Star45.Image = "star_off";
                            puntaje[4] = 2;
                            break;
                        case "3":
                            Star41.Image = "star_on";
                            Star42.Image = "star_on";
                            Star43.Image = "star_on";
                            Star44.Image = "star_off";
                            Star45.Image = "star_off";
                            puntaje[4] = 3;
                            break;
                        case "4":
                            Star41.Image = "star_on";
                            Star42.Image = "star_on";
                            Star43.Image = "star_on";
                            Star44.Image = "star_on";
                            Star45.Image = "star_off";
                            puntaje[4] = 4;
                            break;
                        case "5":
                            Star41.Image = "star_on";
                            Star42.Image = "star_on";
                            Star43.Image = "star_on";
                            Star44.Image = "star_on";
                            Star45.Image = "star_on";
                            puntaje[4] = 5;
                            break;
                    }
                    break;
            }
        }
    }
}
