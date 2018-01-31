using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using XF.Contatos.API;
using XF.Contatos.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(Ligar_IOS))]
namespace XF.Contatos.iOS
{
    public class Ligar_IOS : ILigar
    {
        public bool Discar(string telefone)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + telefone));
        }
    }
}