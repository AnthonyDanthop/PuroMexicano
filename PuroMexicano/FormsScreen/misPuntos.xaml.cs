using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PuroMexicano.Clases;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class misPuntos : ContentPage
    {
        private List<puntosUsuario> lPuntos;

        public misPuntos()
        {
            InitializeComponent();
            this.loadPuntos();

        }

        public async void loadPuntos()
        {
            string query = "SELECT `p`.*, `n`.`id`, `n`.`nombre` FROM `puntos` AS `p` inner join `negocio` as `n` on `p`.`id_negocio` = `n`.`id` where `p`.`id_usuario` = " 
                         + Application.Current.Properties[key: "id"].ToString();
            
            var _result = await Task.Run<String>(() => { return SQL.queryResult(query); });

            if (_result != "NULL")
            {
                lPuntos = JsonConvert.DeserializeObject<List<puntosUsuario>>(_result);
            }
            this.gridUI();
        }

        public void gridUI()
        {
            Grid grid = new Grid();
            int i = 0;
            int total = 0;
            grid.RowSpacing = 0;
            grid.ColumnSpacing = 0;
            grid.Padding = new Thickness(1, 1);

            foreach(puntosUsuario it in lPuntos)
            {
                total += int.Parse(it.puntos);
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1.5, GridUnitType.Auto) });
                AbsoluteLayout absoluteLayout = new AbsoluteLayout();

                Image image = new Image
                {
                    Aspect = Aspect.Fill,
                    ClassId = it.puntosId,
                    Source = "bar.png",
                    VerticalOptions = LayoutOptions.FillAndExpand
                                                   
                };
                absoluteLayout.Children.Add(image);

                Label label = new Label
                {
                    Text = it.puntos,
                    HorizontalOptions = LayoutOptions.Center
                };
                AbsoluteLayout.SetLayoutBounds(label, new Rectangle(.93, .3, -1, -1));
                AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.PositionProportional);

                absoluteLayout.Children.Add(label);

                Label labelName = new Label
                {
                    Text = it.nombre,
                    HorizontalOptions = LayoutOptions.Center
                };
                AbsoluteLayout.SetLayoutBounds(labelName, new Rectangle(0.1, .5, -1, -1));
                AbsoluteLayout.SetLayoutFlags(labelName, AbsoluteLayoutFlags.PositionProportional);
                absoluteLayout.Children.Add(labelName);

                grid.Children.Add(absoluteLayout, 0, i);
                i++;
            }

            ScrollPuntos.Content = grid;
            lpuntos.Text = total + " Puntos";
        }
    }
}