using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Android.Provider;
using System.Collections.Generic;
using Xamarin.Media;
using Android.Content;
using XF.Contatos.API;

[assembly: Dependency(typeof(XF.Contatos.Droid.MainActivity))]
namespace XF.Contatos.Droid
{
    [Activity(Label = "XF.Contatos", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            var uri = ContactsContract.Contacts.ContentUri;
            string[] projection = {
               ContactsContract.Contacts.InterfaceConsts.Id,
               ContactsContract.Contacts.InterfaceConsts.DisplayName,
               ContactsContract.Contacts.InterfaceConsts.PhotoId,
            };

            new ContactService_Android().GetAllContacts();

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

        }

        public void CapturarFoto()
        {
            var context = Forms.Context as Activity;
            var captura = new MediaPicker(context);

            var intent = captura.GetTakePhotoUI(new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Rear,
                Name = string.Format("foto_{0}.jpg", DateTime.Now.ToString()),
                Directory = "Fiap"
            });
            context.StartActivityForResult(intent, 1);
        }

        public void SelecionarFoto()
        {
            var context = Forms.Context as Activity;
            var captura = new MediaPicker(context);

            var intent = captura.GetPickPhotoUI();
            context.StartActivityForResult(intent, 1);
        }

        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Canceled) return;

            var mediaPath = await data.GetMediaFileExtraAsync(Forms.Context);
            MessagingCenter.Send<ICamera, string>(this, "cameraFoto", mediaPath.Path);
        }


    }

}

