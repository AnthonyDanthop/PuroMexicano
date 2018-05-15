using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PuroMexicano.Clases;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class negociosCat : ContentPage
    {
        private String _Catalogo;
        private int _idNegocio;

        /// <summary>
        /// Muestra negocios por categoria
        /// </summary>
        /// <param name="catalogo">Catalogo.</param>
        public negociosCat(String catalogo)
        {
            InitializeComponent();
            _Catalogo = catalogo;
            loadNegocios();
            this.Ltitle.Text = "Negocios";
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
			this.Ltitle.Text = "Promociones";
        }

		protected override void OnAppearing()
        {
            base.OnAppearing();
			if (Ltitle.Text == "Favoritos")
			{
				layout_Log.Children.Clear();
				loadFavoritos();
			}

        }

        /// <summary>
        /// muestra los negocios cargados en favoritos
        /// </summary>
		public negociosCat()
        {
            InitializeComponent();
            _Catalogo = String.Empty;
            //loadFavoritos();
            this.Ltitle.Text = "Favoritos";
        }

		public async void loadFavoritos()
        {
            //var _result = await Task.Run<String>(() => { return SQL.getNegocios(id); });
			string query = "SELECT * FROM `negocio` WHERE `id` in (SELECT `id_negocio` from `favoritos` where `id_usuario` =  "
                    + Application.Current.Properties[key: "id"].ToString() + ");";

            var _result = await Task.Run<String>(() => { return SQL.queryResult(query); });

			if (_result != "NULL")
			{
				globales.lnegocios = JsonConvert.DeserializeObject<List<negocio>>(_result);
				foreach (negocio it in globales.lnegocios)
				{

					Grid grid = new Grid
					{

					};
					grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1f, GridUnitType.Auto) });
					grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1f, GridUnitType.Auto) });

					Button button = new Button
					{
						Text = "",
						Font = Font.SystemFontOfSize(NamedSize.Large),
						BorderWidth = 1,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						ClassId = it.Id,
						Image = "barracorazon",
						HeightRequest = 50,

						BackgroundColor = Color.Transparent
					};
					button.Clicked += onClicked;

					Label name = new Label
					{
						Text = it.Nombre,
						TextColor = Color.Gray,
						FontSize = 18f,
						HorizontalOptions = LayoutOptions.Start,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
						Margin = new Thickness(10, 0)
					};

					grid.Children.Add(name, 0, 0);
					grid.Children.Add(button, 0, 0);



					layout_Log.Children.Add(grid);

				}
			}
			else
				globales.success("Aún no agregas favoritos");

        }


        public async void loadNegocios()
        {
            string id = getValue();
            var _result = await Task.Run<String>(() => { return SQL.getNegocios(id); }); 
            if(_result != "null")
            {
                foreach(negocio it in globales.lnegocios)
                {
                    
                    Grid grid = new Grid
                    {

                    };
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1f, GridUnitType.Auto) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1f, GridUnitType.Auto) });

					Button button = new Button
					{
						Text = "",
						Font = Font.SystemFontOfSize(NamedSize.Large),
						BorderWidth = 1,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						ClassId = it.Id,
						Image = this.getImage(),
                        HeightRequest = 50,

                        BackgroundColor = Color.Transparent
                    };
                    button.Clicked += onClicked; 

                    Label name = new Label
                    {
                        Text = it.Nombre,
                        TextColor = Color.Gray,
                        FontSize = 18f,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        Margin = new Thickness(10, 0)
                    };              

					grid.Children.Add(name, 0, 0);
                    grid.Children.Add(button, 0, 0);
                                          
                    layout_Log.Children.Add(grid);
                    
                }
            }

        }

        public async void loadPromociones()
        {
            string id = getValue();
            var _result = await Task.Run<String>(() => { return SQL.getPromociones(_idNegocio.ToString()); });
			int cont = 1;
            
            if (_result != "null")
            {
				
                foreach (promocion it in globales.lpromociones)
                {
					Grid grid = new Grid
                    {
						VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1f, GridUnitType.Auto) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(310f, GridUnitType.Absolute) });
					grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30f, GridUnitType.Absolute) });

                    Button button = new Button
                    {
                        Text = "",
                        Font = Font.SystemFontOfSize(NamedSize.Large),
                        BorderWidth = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        BackgroundColor = Color.Transparent,
                        HeightRequest = 50,
                        ClassId = it.id,
                        Image = "promo"
					};
					button.Clicked += onClickedPromo;
                    
					Label name = new Label
                    {
                        Text = it.nombre,
                        TextColor = Color.Gray,
                        FontSize = 18f,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        Margin = new Thickness(15, 0)
                    };

					Label num = new Label
					{
						Text = cont.ToString(),
						TextColor = Color.White,
						FontSize = 18f,
						FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
						Margin = new Thickness(2, 0)
                        
                    };          
               
                    grid.Children.Add(name, 0, 0);

					grid.Children.Add(button, 0, 0);
					grid.Children.Add(num, 1, 0);
					Grid.SetColumnSpan(button, 2);

                    layout_Log.Children.Add(grid);
					cont++;
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
                case "MASCOTAS": res = "11"; break;
                default: res = ""; break;
            }
            return res;
        }

        private String getImage()
        {
            String res = "";
            switch (_Catalogo)
            {
                case "COMIDA": res = "barracomida"; break;
                case "BEBIDA": res = "barrabebida"; break;
                case "EDUCACION": res = "barraeducacion"; break;
                case "VIAJES": res = "barraviajes"; break;
                case "DIVERSION": res = "barradiversion"; break;
                case "HOGAR": res = "barrahogar"; break;
                case "CUIDADO_PERSONAL": res = "barracuidadopersonal"; break;
                case "FIESTA": res = "barrafiesta"; break;
				case "SERVICIOS": res = "barraservicios"; break;
				case "MASCOTAS": res = "barramascotas"; break;
                default: res = ""; break;
            }
            return res;
        }
    }
}
