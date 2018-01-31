using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF.Contatos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeAppCenter();

            MainPage = new NavigationPage(new MainPage());
        }

        private void InitializeAppCenter()
        {
            //AppCenter.Start("android=a43baa71-324b-49e0-968c-acaac1db2faa;" + "uwp={Your UWP App secret here};" +
            //                   "ios={Your iOS App secret here}",
            //                   typeof(Analytics), typeof(Crashes));
        }

        public static async Task Sleep(int ms)
        {
            await Task.Delay(ms);
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
