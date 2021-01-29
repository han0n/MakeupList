using MakeupList.MenuCajon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakeupList.MenuCajon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeupMenuPage : ContentPage
    {
        public event EventHandler<PageType> PageSelected;
        public MakeupMenuPage()
        {
            InitializeComponent();
            btnMain.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Main);// El signo de interrogación creo que indica si puede dar valor nulo
            btnAbout.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.About);
        }
    }
}