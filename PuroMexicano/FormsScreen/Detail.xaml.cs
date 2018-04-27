using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();
            ToolbarItems.Add(new ToolbarItem("Mapa", "", () => { Navigation.PushAsync(new mapa()); }));

        }

        public async void OnButtonClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
           
            await Navigation.PushAsync(new negociosCat(btn.ClassId));
        }
    }
}
