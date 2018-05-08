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
        }
    }
}
