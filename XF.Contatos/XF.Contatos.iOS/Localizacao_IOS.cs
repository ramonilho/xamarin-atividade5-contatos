using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XF.Contatos.API;
using System.Threading.Tasks;
using XF.Contatos.iOS;
using Xamarin.Geolocation;

[assembly: Dependency(typeof(Localizacao_IOS))]
namespace XF.Contatos.iOS
{
    public class Localizacao_IOS : ILocalizacao
    {
        public void GetCoordenada()
        {
            var locator = new Geolocator { DesiredAccuracy = 50 };
            locator.GetPositionAsync(timeout: 10000).ContinueWith(t => {
                SetCoordenada(t.Result.Latitude, t.Result.Longitude);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        void SetCoordenada(double paramLatitude, double paramLongitude)
        {
            var coordenada = new Coordenada()
            {
                Latitude = paramLatitude.ToString(),
                Longitude = paramLongitude.ToString()
            };

            MessagingCenter.Send<ILocalizacao, Coordenada>(this, "coordenada", coordenada);
        }
    }
}