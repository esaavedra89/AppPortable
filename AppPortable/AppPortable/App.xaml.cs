using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppPortable
{
    //Clase que hereda de Application
    public partial class App : Application
    {
        //constructor
        public App()
        {
            InitializeComponent();

            //Asiga el contenido a la pantalla de dispositovo
            //recordar que esto es una instancia de una clase
            //Aqui agregamos la instancia de la clase que queremos que se 
            //inicie 
            MainPage = new Camara();
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
