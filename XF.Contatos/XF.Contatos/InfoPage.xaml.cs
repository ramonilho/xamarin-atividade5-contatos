using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Contatos.API;

namespace XF.Contatos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        string number = null;

        public InfoPage(string strTelefone, string strNome)
        {
            number = strTelefone;
            AtualizarLocal();
            //6this.imgFoto.Source = ImageSource.FromUri(new Uri("https://image.freepik.com/free-icon/user-image-with-black-background_318-34564.jpg"));
            //var embeddedImage = new Image { Source = ImageSource.FromResource("user.png") };
            InitializeComponent();
        }

        private void btnCamera_Clicked(object sender, EventArgs e)
        {
            ICamera capturar = DependencyService.Get<ICamera>();
            capturar.CapturarFoto();

            MessagingCenter.Subscribe<ICamera, string>(this, "cameraFoto",
                (objeto, image) =>
                {
                    this.imgFoto.Source = ImageSource.FromFile(image);
                });
        }

        private void btnSelecionar_Clicked(object sender, EventArgs e)
        {
            ICamera capturar = DependencyService.Get<ICamera>();
            capturar.SelecionarFoto();

            MessagingCenter.Subscribe<ICamera, string>(this, "cameraFoto",
                (objeto, image) =>
                {
                    this.imgFoto.Source = ImageSource.FromFile(image);
                });
        }

        private void btnLigar_Clicked()
        {
            if (!string.IsNullOrWhiteSpace(number))
            {
                var phone = DependencyService.Get<ILigar>();
                if (phone != null) phone.Discar(number);
            }
        }

        private void AtualizarLocal()
        {
            ILocalizacao geolocation = DependencyService.Get<ILocalizacao>();
            geolocation.GetCoordenada();

            MessagingCenter.Subscribe<ILocalizacao, Coordenada>
                (this, "coordenada", (objeto, geo) =>
                {
                    lblLongitude.Text = geo.Longitude;
                    lblLatitude.Text = geo.Latitude;
                });
        }

        private void btnMapa_Clicked()
        {
            ILocalizacao geolocation = DependencyService.Get<ILocalizacao>();
            geolocation.GetCoordenada();

            MessagingCenter.Subscribe<ILocalizacao, Coordenada>
                (this, "coordenada", (objeto, geo) =>
                {
                    Device.OpenUri(new Uri("geo:" + geo.Latitude + "," + geo.Longitude));
                });
        }

    }
}