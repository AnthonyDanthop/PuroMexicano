using System;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace PuroMexicano.FormsScreen
{
    public partial class obtenerPuntos : ContentPage
    {
        public obtenerPuntos()
        {
            InitializeComponent();
        }

        private async void HacerFoto(object sender, EventArgs e)
        {
            var opciones_almacenamiento = new StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Name = "MiTicket.jpg"
            };

            var foto = await CrossMedia.Current.TakePhotoAsync(opciones_almacenamiento);
            miImagen.Source = ImageSource.FromStream(() =>
            {
                var stream = foto.GetStream();
                foto.Dispose();
                return stream;
            });
            miImagen.Aspect = Aspect.Fill;
        }

        private async void Elegir_Imagen(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                var imagen = await CrossMedia.Current.PickPhotoAsync();
                if (imagen != null)
                {
                    miImagen.Source = ImageSource.FromStream(()=> 
                    {
                        var stream = imagen.GetStream();
                        imagen.Dispose();
                        return stream;
                    });
                    miImagen.Aspect = Aspect.Fill;
                }
            }
        }﻿
    }
}
