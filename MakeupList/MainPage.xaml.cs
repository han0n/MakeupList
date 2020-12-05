using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.ObjectModel;

namespace MakeupList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnLabial_Clicked(object sender, EventArgs e)
        {
            HttpClient cliente = new HttpClient();
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=lipstick";

            HttpResponseMessage respuesta = await cliente.GetAsync(url);
            var json = respuesta.Content.ReadAsStringAsync().Result;

            Product[] pintalabios = Product.FromJson(json);

            ListaProductos.ItemsSource = pintalabios;
        }

    }
}
