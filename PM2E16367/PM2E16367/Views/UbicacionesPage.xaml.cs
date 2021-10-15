using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;

namespace PM2E16367.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicacionesPage : ContentPage
    {
        public double latit, longt;
        
        public UbicacionesPage( double lati, double longi)
        {
            InitializeComponent();

           latit = lati;
           longt = longi;
        }

        private async void toolbar01_Clicked(object sender, EventArgs e)
        {
            //regresar
            await Navigation.PushAsync(new MainPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //mostrar la lista
            var listaubicaciones = await App.BaseDatos.ObtenerListaUbicaciones();
            lsubicaciones.ItemsSource = listaubicaciones;
        }

        private async void lsubicaciones_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Ubicaciones item = (Models.Ubicaciones)e.Item;
            await DisplayAlert("Accion ", "Desea ir a la ubicacion indicada?", "SI", "NO");


            MapLaunchOptions options = new MapLaunchOptions { Name = "Posicion indicada" };
            await Map.OpenAsync(latit, longt, options);
            /*var page = new Views.MapPage();
            page.BindingContext = item;
            await Navigation.PushAsync(page);*/
        }

        /*private async void Button_Clicked(object sender, EventArgs e)
        {
            MapLaunchOptions options = new MapLaunchOptions { Name = "Mi posicion actual" };
            await Map.OpenAsync(lat, lon, options);

        }*/
    }
}