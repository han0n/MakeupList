using MakeupList.MenuCajon;
using MakeupList.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MakeupList.MenuCajon
{
    class MakeupMasterDetailPage : MasterDetailPage
    {
        public MakeupMasterDetailPage()
        {
            var master = new MakeupMenuPage();
            master.PageSelected += OnPageSelected;

            this.Master = master;

            this.MasterBehavior = MasterBehavior.Popover;

            this.Detail = new MainPage();

            //this.Detail = new NavigationPage(new MainPage());
            /* 
             *  Si MainPage() fuese parámetro de NavigationPage, se nos crearía una
             * barra superior con el icono "hamburguesa" que abre el menú de cajón.
             */

            
        }

        void OnPageSelected(object sender, PageType pageType)
        {
            Page page = new MainPage();// Tiene que estar inicializado

            switch (pageType)
            {
                case PageType.Main: 
                    page = new MainPage();
                    break;
                case PageType.About:
                    page = new NavigationPage(new AboutPage());
                    break;
            }

            //Detail = new NavigationPage(page);
            Detail = page;

            try
            {
                IsPresented = false;// Oculta el cajón cuando es pulsado
            }
            catch { }
        }
    }
}
