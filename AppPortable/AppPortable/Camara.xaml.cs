/*
En el AssemblyInfo.cs
Se le agrega estos assembly

[assembly: UsesPermission(Android.Manifest.Permission.Camera)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]

Y el plugin Xam.Plugin.Media Version 2.3.0
 */

using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPortable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Camara : ContentPage
    {
        public Camara()
        {
            InitializeComponent();
        }

        private async void HacerFoto(object sender, EventArgs e)
        {
            var opciones_almacenamiento = new StoreCameraMediaOptions()//establecemos opciones de almacenameinto
            {
                SaveToAlbum = true,//guardamos en al galeria del dispositivo
                Name = "MiFoto.jpg"//asignamos nombre
            };
            //creamos variable 
            var foto = await CrossMedia.Current.TakePhotoAsync(opciones_almacenamiento);//ejecutamos metodo para tomar la foto y almacenamos en galeria
            MiImagen.Source = ImageSource.FromStream(() =>//asigamos a la pantalla principal, la imagen que acabamos de tomar
            {
                var stream = foto.GetStream();  
                foto.Dispose();//cerramos conexion
                return stream;//retornamos la variable
            });
        }

        private async void Elegir_Imagen(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsTakePhotoSupported)//comprobamos la accion de la galeria este disponible
            {
                var imagen = await CrossMedia.Current.PickPhotoAsync();//seleccionamos foto de galeria
                if (imagen != null)
                {
                    MiImagen.Source = ImageSource.FromStream(()=> //asignamos la foto a la imagen en el Xaml
                    {
                        var stream = imagen.GetStream();
                        imagen.Dispose();
                        return stream;
                    });
                }
            }
        }
    }
}
