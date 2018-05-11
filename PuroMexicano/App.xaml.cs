using PuroMexicano.Clases;
using PuroMexicano.FormsScreen;
using Xamarin.Forms;

namespace PuroMexicano
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
			MainPage = new NavigationPage(new PuroMexicanoPage());
            
			try
			{
				if (!bool.Parse(Application.Current.Properties[key: "Sesion"].ToString()))
				{
					MainPage = new NavigationPage(new PuroMexicanoPage());
				}
				else
				{
					globales.ToastInfo("Bienvenido " + Application.Current.Properties[key: "nombre"].ToString());
					MainPage = new NavigationPage(new PuroMexicano.FormsScreen.Menu());

				}
			}
			catch{
				MainPage = new NavigationPage(new PuroMexicanoPage());
			}
            //MainPage = new PuroMexicanoPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
