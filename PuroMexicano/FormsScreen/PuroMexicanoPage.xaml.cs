using Xamarin.Forms;
using PuroMexicano.FormsScreen;
using PuroMexicano.Clases;

namespace PuroMexicano
{
    public partial class PuroMexicanoPage : ContentPage
    {
        public PuroMexicanoPage()
        {
            InitializeComponent();

        }

        async void LogIn(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new LogIn());
        }

        async void Register(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new registroUsuario());
        }

        async void RegisterFaceBook(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new loginFB());
        }

        async void sinRegistro(object sender, System.EventArgs e)
        {
            globales.ToastInfo("login sin perfil");
			Application.Current.Properties[key: "id"] =
			Application.Current.Properties[key: "nombre"] =
			Application.Current.Properties[key: "email"] =
			Application.Current.Properties[key: "password"] =
			Application.Current.Properties[key: "fecha_nacimiento"] =
			Application.Current.Properties[key: "status"] =
			Application.Current.Properties[key: "foto"] =
			Application.Current.Properties[key: "edad"] =
			Application.Current.Properties[key: "notificaciones"] = "";
			Application.Current.Properties[key: "Sesion"] = false; 
         
			Application.Current.MainPage = new NavigationPage(new PuroMexicano.FormsScreen.Menu());
        }
    }
}
