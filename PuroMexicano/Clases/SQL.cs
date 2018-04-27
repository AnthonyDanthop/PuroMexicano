using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace PuroMexicano.Clases
{
    public static class SQL
    {
        private static string url_Client = "http://puro-mexicano.com.mx";
        private static string _login = "PMApp/logIn.php";
        private static string _getNegocios = "PMApp/getNegocios.php";
        private static string _Update = "PMApp/update.php";
        private static string _getImgNegocios = "PMApp/getImgNegocio.php";
        private static string _getPromociones = "PMApp/getPromociones.php";
        private static string _CalifPromocion = "PMApp/promocionCalif.php";
        private static string _Query = "PMApp/queryResult.php";

        public async static Task<String> logIn_Server(String mail, String pass)
        {
            String res = "";
            try
            {

                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("email", mail),
                    new KeyValuePair<string, string>("password", pass)
                };

                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url_Client);

                var response = await client.PostAsync(_login, content);

                if( response.Content.ReadAsStringAsync().Result.Contains("{") )
                {
                    var _result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    Application.Current.Properties[key: "id"] = JObject.Parse(_result.ToString())["id"].ToObject<string>();
                    Application.Current.Properties[key: "nombre"] = JObject.Parse(_result.ToString())["nombre"].ToObject<string>();
                    Application.Current.Properties[key: "email"] = JObject.Parse(_result.ToString())["email"].ToObject<string>();
                    Application.Current.Properties[key: "password"] = JObject.Parse(_result.ToString())["password"].ToObject<string>();
                    Application.Current.Properties[key: "fecha_nacimiento"] = JObject.Parse(_result.ToString())["fecha_nacimiento"].ToObject<string>();
                    Application.Current.Properties[key: "status"] = JObject.Parse(_result.ToString())["status"].ToObject<string>();
                    Application.Current.Properties[key: "foto"] = JObject.Parse(_result.ToString())["foto"].ToObject<string>();
                    Application.Current.Properties[key: "edad"] = JObject.Parse(_result.ToString())["edad"].ToObject<string>();
                    Application.Current.Properties[key: "notificaciones"] = JObject.Parse(_result.ToString())["notificaciones"].ToObject<string>();
                    Application.Current.Properties[key: "Sesion"] = true;
                    await Application.Current.SavePropertiesAsync();

                    res = "Login";
                }
                else
                    res = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception e)
            {
                 res = e.Message;
            }
            return res;
        }

        public async static Task<String> logInFB_Server(String mail, String idFB, String name, String imgSource)
        {
            String res = "";
            try
            {

                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("email", mail),
                    new KeyValuePair<string, string>("idFB", idFB),
                    new KeyValuePair<string, string>("usuario", name),
                    new KeyValuePair<string, string>("foto", imgSource),
                    new KeyValuePair<string, string>("loginFB", "1")
                };

                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url_Client);

                var response = await client.PostAsync(_login, content);

                if (response.Content.ReadAsStringAsync().Result.Contains("{"))
                {
                    var _result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    Application.Current.Properties[key: "id"] = JObject.Parse(_result.ToString())["id"].ToObject<string>();
                    Application.Current.Properties[key: "nombre"] = JObject.Parse(_result.ToString())["nombre"].ToObject<string>();
                    Application.Current.Properties[key: "email"] = JObject.Parse(_result.ToString())["email"].ToObject<string>();
                    Application.Current.Properties[key: "password"] = JObject.Parse(_result.ToString())["password"].ToObject<string>();
                    Application.Current.Properties[key: "fecha_nacimiento"] = JObject.Parse(_result.ToString())["fecha_nacimiento"].ToObject<string>();
                    Application.Current.Properties[key: "status"] = JObject.Parse(_result.ToString())["status"].ToObject<string>();
                    Application.Current.Properties[key: "idFB"] = JObject.Parse(_result.ToString())["id_FB"].ToObject<string>();
                    Application.Current.Properties[key: "edad"] = JObject.Parse(_result.ToString())["edad"].ToObject<string>();
                    Application.Current.Properties[key: "notificaciones"] = JObject.Parse(_result.ToString())["notificaciones"].ToObject<string>();
                    Application.Current.Properties[key: "foto"] = JObject.Parse(_result.ToString())["foto"].ToObject<string>();
                    Application.Current.Properties[key: "Sesion"] = true;
                    await Application.Current.SavePropertiesAsync();

                    res = "Login";
                }
                else
                    res = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public async static Task<String> idFB_Server(String idFB)
        {
            String res = "";
            try
            {

                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Eid_FB", idFB),
                    new KeyValuePair<string, string>("loginFB", "1")
                };

                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url_Client);

                var response = await client.PostAsync(_login, content);

                if (response.Content.ReadAsStringAsync().Result.Contains("{"))
                {
                    var _result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    Application.Current.Properties[key: "id"] = JObject.Parse(_result.ToString())["id"].ToObject<string>();
                    Application.Current.Properties[key: "nombre"] = JObject.Parse(_result.ToString())["nombre"].ToObject<string>();
                    Application.Current.Properties[key: "email"] = JObject.Parse(_result.ToString())["email"].ToObject<string>();
                    Application.Current.Properties[key: "password"] = JObject.Parse(_result.ToString())["password"].ToObject<string>();
                    Application.Current.Properties[key: "fecha_nacimiento"] = JObject.Parse(_result.ToString())["fecha_nacimiento"].ToObject<string>();
                    Application.Current.Properties[key: "status"] = JObject.Parse(_result.ToString())["status"].ToObject<string>();
                    Application.Current.Properties[key: "idFB"] = JObject.Parse(_result.ToString())["id_FB"].ToObject<string>();
                    Application.Current.Properties[key: "foto"] = JObject.Parse(_result.ToString())["foto"].ToObject<string>();
                    Application.Current.Properties[key: "edad"] = JObject.Parse(_result.ToString())["edad"].ToObject<string>();
                    Application.Current.Properties[key: "notificaciones"] = JObject.Parse(_result.ToString())["notificaciones"].ToObject<string>();
                    Application.Current.Properties[key: "Sesion"] = true;
                    await Application.Current.SavePropertiesAsync();

                    res = "Login";
                }
                else
                    res = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public async static Task<String> insertUser(String mail, String pass, String name)
        {
            String res = "";
            try
            {

                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("email", mail),
                    new KeyValuePair<string, string>("password", pass),
                    new KeyValuePair<string, string>("usuario", name),
                    new KeyValuePair<string, string>("new_user", "1")
                };

                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url_Client);

                var response = await client.PostAsync(_login, content);
                res = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }
        public async static Task<String> updateUser(String nombre, String email, String edad, String notificaciones)
        {
            String res = "";
            try
            {

                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("type", "0"),
                    new KeyValuePair<string, string>("nombre", nombre),
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("edad", edad),
                    new KeyValuePair<string, string>("notificaciones", notificaciones),
                    new KeyValuePair<string, string>("id", Application.Current.Properties[key: "id"].ToString())
                };

                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url_Client);

                var response = await client.PostAsync(_Update, content);
                if (response.Content.ReadAsStringAsync().Result.Contains("{"))
                {
                    var _result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                    Application.Current.Properties[key: "nombre"] = JObject.Parse(_result.ToString())["nombre"].ToObject<string>();
                    Application.Current.Properties[key: "email"] = JObject.Parse(_result.ToString())["email"].ToObject<string>();
                    Application.Current.Properties[key: "edad"] = JObject.Parse(_result.ToString())["edad"].ToObject<string>();
                    Application.Current.Properties[key: "notificaciones"] = JObject.Parse(_result.ToString())["notificaciones"].ToObject<string>();
                    await Application.Current.SavePropertiesAsync();

                    res = "Login";
                }
                else
                res = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public async static Task<String> getNegocios(String CategoriaId)
        {
            try
            {
                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", CategoriaId)
                };

                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url_Client);

                var response = await client.PostAsync(_getNegocios, content);
                var res = response.Content.ReadAsStringAsync().Result;
                if (!response.Content.ReadAsStringAsync().Result.Equals("NULL"))
                {
                    //var _result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    //var _result = JsonConvert.DeserializeObject<List<negocio>>(res);
                    globales.lnegocios = JsonConvert.DeserializeObject<List<negocio>>(res);
                    return "List";
                }
                else
                    return "null";
            }
            catch
            {
               return "null";
            }
        }

        public async static Task<String> getPromociones(String negocioId)
        {
            try
            {
                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", negocioId)
                };

                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url_Client);

                var response = await client.PostAsync(_getPromociones, content);
                var res = response.Content.ReadAsStringAsync().Result;
                if (!response.Content.ReadAsStringAsync().Result.Equals("NULL"))
                {
                    //var _result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    //var _result = JsonConvert.DeserializeObject<List<negocio>>(res);
                    globales.lpromociones = JsonConvert.DeserializeObject<List<promocion>>(res);
                    return "List";
                }
                else
                    return "null";
            }
            catch
            {
                return "null";
            }
        }


        public async static Task<String> getImgNegocio(String negocioId)
        {
            try
            {
                globales.limgNeg = new List<imgNegocio>();
                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", negocioId)
                };

                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url_Client);

                var response = await client.PostAsync(_getImgNegocios, content);
                var res = response.Content.ReadAsStringAsync().Result;

                if (!response.Content.ReadAsStringAsync().Result.Equals("NULL"))
                {
                    //var _result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    //var _result = JsonConvert.DeserializeObject<List<negocio>>(res);
                    globales.limgNeg = JsonConvert.DeserializeObject<List<imgNegocio>>(res);
                    return "List";
                }
                else
                {
                    
                    return "null";
                }
            }
            catch
            {
                return "null";
            }
        }

        public async static Task<String> calificaPromocion(String promocionId, int [] arrCalif , bool get = false)
        {
            try
            {
                var postData = new List < KeyValuePair<string, string>>();

                if (!get)
                {
                    postData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("usuarioId", Application.Current.Properties[key: "id"].ToString()),
                        new KeyValuePair<string, string>("promocionId", promocionId),
                        new KeyValuePair<string, string>("limpieza", arrCalif[0].ToString()),
                        new KeyValuePair<string, string>("servicio", arrCalif[1].ToString()),
                        new KeyValuePair<string, string>("rapidez", arrCalif[2].ToString()),
                        new KeyValuePair<string, string>("calidad", arrCalif[3].ToString()),
                        new KeyValuePair<string, string>("precio", arrCalif[4].ToString())
                    };
                }
                else
                {
                    postData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("usuarioId", Application.Current.Properties[key: "id"].ToString()),
                        new KeyValuePair<string, string>("promocionId", promocionId),
                        new KeyValuePair<string, string>("get", "1")
                    };
                }

                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url_Client);

                var response = await client.PostAsync(_CalifPromocion, content);
                var res = response.Content.ReadAsStringAsync().Result;
                return res;
            }
            catch
            {
                return "null";
            }
        }

        public async static Task<String> queryResult(String query)
        {
            try
            {

                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("query",query)
                };

                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url_Client);

                var response = await client.PostAsync(_Query, content);
                var res = response.Content.ReadAsStringAsync().Result;
                return res;
            }
            catch
            {
                return "NULL";
            }
        }


    }
}
