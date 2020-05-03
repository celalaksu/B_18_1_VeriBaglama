using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeriBaglama
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DateTimeVerisindenBaglama());
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
