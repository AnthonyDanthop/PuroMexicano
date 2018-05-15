using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen.popUp
{
	public partial class popUpLogin : PopupPage
    {
        public popUpLogin()
        {
            InitializeComponent();
        }

		private async void close(object sender, EventArgs e)
		{ 
			await Navigation.PopAllPopupAsync();
		}
        
        private async void registro()
		{
			
		}
    }
}
