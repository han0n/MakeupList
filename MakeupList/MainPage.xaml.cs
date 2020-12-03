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
using System.Collections.ObjectModel;

namespace MakeupList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://makeup-api.herokuapp.com/api/v1/products.json");
            request.Method = HttpMethod.Get;
            //request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if/*(response.StatusCode == HttpStatusCode.OK)*/(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                ObservableCollection<Product> resultado = JsonConvert.DeserializeObject<ObservableCollection<Product>>(content);

                ProductType mascara = ProductType.Mascara;

                ObservableCollection<Product> _mascara = new ObservableCollection<Product>();

                for (var index = 0; index < resultado.Count; index++)
                {
                    if (resultado[index].ProductType == mascara)
                    {
                        _mascara.Add(resultado[index]);   
                        
                    }
                }

                ListaProductos.ItemsSource = _mascara;//resultado;
            }
        }



    }   
}
