using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XF.Contatos.iOS;
using Xamarin.Media;
using XF.Contatos.API;

[assembly: Dependency(typeof(Camera_IOS))]
namespace XF.Contatos.iOS
{
    public class Camera_IOS : ICamera
    {
        public async void CapturarFoto()
        {
            var capturar = new MediaPicker();

            MediaFile mediaPath;
            if (capturar.IsCameraAvailable)
            {
                mediaPath = await capturar.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    DefaultCamera = CameraDevice.Rear,
                    Name = string.Format("foto_{0}.jpg", DateTime.Now.ToString()),
                    Directory = "Fiap"
                });
            }
        }

        public async void SelecionarFoto()
        {
            var capturar = new MediaPicker();

            MediaFile mediaPath;
            if (capturar.IsCameraAvailable)
                mediaPath = await capturar.PickPhotoAsync();
        }
    }
}