using Plugin.Geolocator;
using PM2E16367.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace PM2E16367
{
    public partial class MainPage : ContentPage
    {
        public double lati;
        public double longi;
        public MainPage()
        {
            InitializeComponent();

            //recuperar posicion
            Localizar();

        }

        private async void Localizar()
        {
            var locator = CrossGeolocator.Current; //acceso a la API
            locator.DesiredAccuracy = 50; //precision en metros
            if(locator.IsGeolocationAvailable) //servicio existente en el dispositivo
            {
                if(locator.IsGeolocationEnabled) //GPS activo en el dispositivo
                {
                    if(!locator.IsListening) //comprobando que el dispositivo escucha el servicio
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(100), 10); //inicia la escucha
                        await DisplayAlert("nota ", " GPS activo, escuchando", "OK");
                    }
                    
                    locator.PositionChanged += (cambio, args) =>
                    {
                        
                        var loc = args.Position;
                        txtlon.Text = loc.Longitude.ToString();
                        longi = double.Parse(txtlon.Text);
                        txtlat.Text = loc.Latitude.ToString();
                        lati = double.Parse(txtlat.Text);

                    };
                    await DisplayAlert("nota ", "cambiando pisicion", "OK");
                }
                else { await DisplayAlert("Error ", "El GPS no esta activo en el dispositivo", "OK"); }
            }
        }
       

        private async void toolbar01_Clicked_1(object sender, EventArgs e)
        {
            //llamar pantalla ubicaciones guardadas
            await Navigation.PushAsync(new UbicacionesPage(lati, longi));
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ubicaciones = new Models.Ubicaciones
                {
                    latitud = this.txtlat.Text,
                    longitud = this.txtlon.Text,
                    descripcionl = this.txtdescripcionl.Text,
                    descripcionc = this.txtdescripcionc.Text
                };

                var resultado = await App.BaseDatos.GrabarUbicacion(ubicaciones);
                if (resultado == 1)
                {
                    if(this.txtdescripcionl.Text != null && this.txtdescripcionc != null)
                    {
                        await DisplayAlert("Agregado", "Ubicacion guardada exitosamente", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Error", "Debe describir la ubicacion", "Ok");
                    }
                   
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar la ubicacion", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

        private void ClearScreen()
        {
            this.txtlat.Text = String.Empty;
            this.txtlon.Text = String.Empty;
            this.txtdescripcionl.Text = String.Empty;
            this.txtdescripcionc.Text = String.Empty;
        }

       
    }
}
