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

        private async void TomarDatos(HttpClient cliente, string url)
        {
            HttpResponseMessage respuesta = await cliente.GetAsync(url);
            var json = respuesta.Content.ReadAsStringAsync().Result;
            // Aquí ya deserializa desde el modelo Product
            Product[] producto = Product.FromJson(json);

            ListaProductos.ItemsSource = producto;
            indicador.IsVisible = false;
        } 
        private void BtnLabial_Clicked(object sender, EventArgs e)
        {
            ExpCara.IsExpanded = false;
            ExpDelin.IsExpanded = false;
            ExpLabios.IsExpanded = false;
            ExpOjos.IsExpanded = false;
            indicador.IsVisible = true;

            HttpClient cliente = new HttpClient();
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=lipstick";
            // En este método se pasa el cliente junto a la url de donde se consumen los datos
            TomarDatos(cliente, url);
        }

        private void BtnColorete_Clicked(object sender, EventArgs e)
        {
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=blush";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnBronceador_Clicked(object sender, EventArgs e)
        {
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=bronzer";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnBase_Clicked(object sender, EventArgs e)
        {
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=foundation";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnPerfiladores_Clicked(object sender, EventArgs e)
        {
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=lip_liner";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnDelCejas_Clicked(object sender, EventArgs e)
        {
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=clinique&product_type=eyebrow";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnDelOjos_Clicked(object sender, EventArgs e)
        {
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=eyeliner";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnSombra_Clicked(object sender, EventArgs e)
        {
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=eyeshadow";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnRimel_Clicked(object sender, EventArgs e)
        {
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=mascara";
            TomarDatos(new HttpClient(), url);
        }
    }
}
