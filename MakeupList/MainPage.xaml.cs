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
                var resultado = JsonConvert.DeserializeObject<List<Product>>(content);

                ListaProductos.ItemsSource = resultado;
            }
        }


        public partial class Product
        {
            public long Id { get; set; }
            public string Brand { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
            public PriceSign? PriceSign { get; set; }
            public Currency? Currency { get; set; }
            public Uri ImageLink { get; set; }
            public Uri ProductLink { get; set; }
            public Uri WebsiteLink { get; set; }
            public string Description { get; set; }
            public double? Rating { get; set; }
            public Category? Category { get; set; }
            public ProductType ProductType { get; set; }
            public string[] TagList { get; set; }
            public DateTimeOffset CreatedAt { get; set; }
            public DateTimeOffset UpdatedAt { get; set; }
            public Uri ProductApiUrl { get; set; }
            public string ApiFeaturedImage { get; set; }
            public ProductColor[] ProductColors { get; set; }
        }

        public partial class ProductColor
        {
            public string HexValue { get; set; }
            public string ColourName { get; set; }
        }

        public enum Category { BbCc, Concealer, Contour, Cream, Empty, Gel, Highlighter, LipGloss, LipStain, Lipstick, Liquid, Mineral, Palette, Pencil, Powder };

        public enum Currency { Cad, Gbp, Usd };

        public enum PriceSign { Empty, PriceSign };

        public enum ProductType { Blush, Bronzer, Eyebrow, Eyeliner, Eyeshadow, Foundation, LipLiner, Lipstick, Mascara, NailPolish };
    }
    
}
