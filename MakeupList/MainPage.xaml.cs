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
            //var request = new HttpRequestMessage();
            //request.RequestUri = new Uri("https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=lipstick");
            //request.Method = HttpMethod.Get;

            HttpClient cliente = new HttpClient();
            string url = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=lipstick";

            HttpResponseMessage respuesta = await cliente.GetAsync(url);
            var json = respuesta.Content.ReadAsStringAsync().Result;

            Product[] modelo = Product.FromJson(json);

            //if (respuesta.IsSuccessStatusCode)
            //{
              //  string content = await respuesta.Content.ReadAsStringAsync();
                //ObservableCollection<Product> resultado = JsonConvert.DeserializeObject<ObservableCollection<Product>>(content);

                ListaProductos.ItemsSource = modelo;
            //}
        }

        /*
        private async void MostrarLabiales(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline&product_type=lipstick");
            request.Method = HttpMethod.Get;
            //request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if/*(response.StatusCode == HttpStatusCode.OK)//(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Product>>(content);

                ListaProductos.ItemsSource = resultado;

            }
        }
        */
    }
}
