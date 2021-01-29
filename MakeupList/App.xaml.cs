using MakeupList.MenuCajon;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakeupList
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "Expander_Experimental" });
            InitializeComponent();

            MainPage = new MakeupMasterDetailPage();
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
