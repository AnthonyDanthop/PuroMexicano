using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace PuroMexicano.Clases
{
    public class FacebookServices
    {

        public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
        {
            string requestUrl = "https://graph.facebook.com/v2.12/me?fields=id,name,email,last_name,first_name,birthday,picture.width(200).height(200)&access_token=" + accessToken;
            //String requestUrl = $"https://graph.facebook.com/me?fields=email&access_token={accessToken}";
            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);
            var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

            return facebookProfile;
        }
    }

    public class Usuario
    {
        public static string Id { get; set; }
        public static string Nombre { get; set; }
        public static DateTime FechaCumpleaños { get; set; }
        public static int status { get; set; }
    }

    public class puntosUsuario
    {
        public string puntosId { get; set; }
        public string puntos { get; set; }
        public string id_usuario { get; set; }
        public string id_negocio { get; set; }
        public string monto { get; set; }
        public string nombre { get; set; }
    }


    public class FacebookProfile
    {
        public string Id { get; set; }
        public string Birthday { get; set; }
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Picture Picture { get; set; }
    }

    public class CalificacionPromo
    { 
        public String Id { get; set; }
        public String usuarioId { get; set; }
        public String promocionId { get; set; }
        public String limpieza { get; set; }
        public String servicioCliente { get; set; }
        public String rapidez { get; set; }
        public String calidad { get; set; }
        public String precio { get; set; }
    }

    public class Picture
    {
        public Data Data { get; set; }

    }

    public class Data {
        public bool IsSilhouette { get; set; }
        public String Url { get; set; }
    }

    public class promocion
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string id_negocio { get; set; }
        public string inicia { get; set; }
        public string vigencia { get; set; }
        public string restricciones { get; set; }
        public string rating { get; set; }
        public string notificaiones { get; set; }
        public string status { get; set; }
        public string codigo { get; set; }
    }

    public class negocio 
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string email { get; set; }
        public string logo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string horario { get; set; }
        public string rating { get; set; }
        public string categoriaId { get; set; }
        public string descripcion { get; set; }
    }

    public class imgNegocio
    {
        public string Nombre { get; set; }
        public string tam { get; set; }
    }

    public static class globales
    {
        public const int Length_nombre = 41;
        public static List<negocio> lnegocios;
        public static List<promocion> lpromociones;
        public static List<imgNegocio> limgNeg;

        public static bool isEmail(String Email)
        {
			if (Email != null)
			{
				if (Email.Length > 0)
				{
					var str = Email;
					Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
					Match match = regex.Match(str);

					return match.Success;
				}
				else
					return false;
			}
			else
				return false;
        }

        public static negocio GetNegocio(string id)
        {
            foreach (negocio n in globales.lnegocios)
            {
                if (n.Id == id)
                    return n;
                else
                    continue;

            }
            return null;
        }

        public static promocion GetPromocion(string id)
        {
            foreach (promocion n in globales.lpromociones)
            {
                if (n.id == id)
                    return n;
                else
                    continue;

            }
            return null;
        }

        public static string MonthName(DateTime date)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES").DateTimeFormat;
            return dtinfo.GetMonthName(date.Month);
        }

        public static string codigoRandom(int length)
        {
            Random obj = new Random();
            string posibles = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            int longitudnuevacadena = length;
            string nuevacadena = "";

            for (int i = 0; i < longitudnuevacadena; i++)
            {
                letra = posibles[obj.Next(longitud)];
                nuevacadena += letra.ToString();
            }
            return nuevacadena;
        }

        public static void Error(string Mensaje)
        {
            ToastConfig.DefaultBackgroundColor = System.Drawing.Color.FromArgb(244, 47, 73);
            UserDialogs.Instance.ShowError(Mensaje);

            //return mensajeError;
        }

        public static void ToastInfo(string Mensaje)
        {
            ToastConfig.DefaultBackgroundColor = System.Drawing.Color.FromArgb(109, 188, 219);
            UserDialogs.Instance.Toast(Mensaje);

        }

        public static void success(string Mensaje)
        {

            ToastConfig.DefaultBackgroundColor = System.Drawing.Color.FromArgb(56, 166, 84);
            UserDialogs.Instance.Toast(Mensaje);
        }
    }
}
