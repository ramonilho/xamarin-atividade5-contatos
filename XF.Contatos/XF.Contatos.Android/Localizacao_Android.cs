using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Xamarin.Forms;
using XF.Contatos.API;
using System.Threading.Tasks;
using Xamarin.Geolocation;
using XF.Contatos.Droid;
using Plugin.Geolocator;

[assembly: Dependency(typeof(Localizacao_Android))]
namespace XF.Contatos.Droid
{
    public class Localizacao_Android : ILocalizacao
    {
        public async void GetCoordenada()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(timeout: TimeSpan.FromSeconds(1));

            SetCoordenada(position.Latitude, position.Longitude);
        }

        public void SetCoordenada(double paramLatitude, double paramLongitude)
        {
            var coordenada = new Coordenada()
            {
                Latitude = paramLatitude.ToString(),
                Longitude = paramLongitude.ToString()
            };

            MessagingCenter.Send<ILocalizacao, Coordenada>
                (this, "coordenada", coordenada);
        }
    }
}