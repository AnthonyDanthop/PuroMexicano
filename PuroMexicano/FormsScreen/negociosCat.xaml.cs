using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PuroMexicano.Clases;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class negociosCat : ContentPage
    {
        private String _Catalogo;
        private int _idNegocio;

        public negociosCat(String catalogo)
        {
            InitializeComponent();
            _Catalogo = catalogo;
            loadNegocios();
            this.Title = "Negocios";
        }
        /// <summary>
        /// cuando se muestran las promociones del negocio
        /// </summary>
        /// <param name="idNegocio">Identifier negocio.</param>
        public negociosCat(int idNegocio)
        {
            InitializeComponent();
            _Catalogo = String.Empty;
            _idNegocio = idNegocio;
            loadPromociones();
            this.Title = "Promociones";
        }
        public async void loadNegocios()
        {
            string id = getValue();
            var _result = await Task.Run<String>(() => { return SQL.getNegocios(id); }); 
            if(_result != "null")
            {
                foreach(negocio it in globales.lnegocios)
                {
                    Button button = new Button
                    {
                        Text = it.Nombre,
                        Font = Font.SystemFontOfSize(NamedSize.Large),
                        BorderWidth = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        ClassId = it.Id
                                                       
                    };
                    button.Clicked += onClicked;    
                    layout_Log.Children.Add(button);
                    
                }
            }

        }

        public async void loadPromociones()
        {
            string id = getValue();
            var _result = await Task.Run<String>(() => { return SQL.getPromociones(_idNegocio.ToString()); });
            if (_result != "null")
            {
                foreach (promocion it in globales.lpromociones)
                {
                    Button button = new Button
                    {
                        Text = it.nombre,
                        Font = Font.SystemFontOfSize(NamedSize.Large),
                        BorderWidth = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        ClassId = it.id

                    };
                    button.Clicked += onClickedPromo;
                    layout_Log.Children.Add(button);

                }
            }

        }

        async void onClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new Negocio(button.ClassId));
        }

        async void onClickedPromo(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new Promocion(button.ClassId));
        }

       
        private String getValue()
        {
            String res = "";
            switch(_Catalogo)
            {
                case "COMIDA": res = "2"; break;
                case "BEBIDA": res = "3"; break;
                case "EDUCACION": res = "4"; break;
                case "VIAJES": res = "5"; break;
                case "DIVERSION": res = "6"; break;
                case "HOGAR": res = "7"; break;
                case "CUIDADO_PERSONAL": res = "8"; break;
                case "FIESTA": res = "9"; break;
                case "SERVICIOS": res = "10"; break;
                default: res = ""; break;
            }
            return res;
        }
    }
}
