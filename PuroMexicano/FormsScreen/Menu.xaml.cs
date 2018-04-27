using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail()){BarBackgroundColor = Color.FromHex("#C7C6C6"), BarTextColor = Color.Black};
        }
    }
}
