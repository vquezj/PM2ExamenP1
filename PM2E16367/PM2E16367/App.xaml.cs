using PM2E16367.Controller;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E16367
{
    public partial class App : Application
    {

        //Instanciar la base de datos
        static DataBaseSQLite basedatos;

        //CREAR una conexion a la base de datos
        public static DataBaseSQLite BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    //pasamos el parametro donde va a estar ubicada la base de datos, y el nombre de la base de datos con la extension
                    //con el path combine combinamos string para hacer un solo url dentro de la clase
                    basedatos = new DataBaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02ExamenP1.db3"));
                }
                return basedatos;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
