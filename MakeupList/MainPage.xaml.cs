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
        // Como siempre se usará el mismo servicio REST, he cogido la parte de la url 
        //donde no se realiza una consulta para dinamizar y esclarecer el código. 
        private string servicioRest = "https://makeup-api.herokuapp.com/api/v1/products.json";
        public MainPage()
        {
            InitializeComponent();
            BtnClinique.Clicked += BtnClinique_Clicked;
            BtnMaybelline.Clicked += BtnMaybelline_Clicked;
        }

        private void BtnClinique_Clicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            BtnClinique.IsEnabled = false;
            BtnMaybelline.IsEnabled = true;
            Ayuda.Text = "";
        }
        private void BtnMaybelline_Clicked(object sender, EventArgs e)
        {
            BtnClinique.IsEnabled = true;
            BtnMaybelline.IsEnabled = false;
            Ayuda.Text = "";
        }

        private async void TomarDatos(HttpClient cliente, string url)
        {
            HttpResponseMessage respuesta = await cliente.GetAsync(url);
            var json = respuesta.Content.ReadAsStringAsync().Result;
            // Aquí ya deserializa desde el modelo Product
            Product[] producto = Product.FromJson(json);

            ListaProductos.ItemsSource = producto;
            if (producto.Length > 0) { Indicador.IsVisible = false; }
            else 
            { 
                if (Marca() != servicioRest + "?brand=none")
                {
                    DisplayAlert("", "No se ha encontrado ningún producto", "De acuerdo");
                }
                else 
                {
                    DisplayAlert("", "No se ha seleccionado ninguna de las dos marcas", "Vale");
                }

                Indicador.IsVisible = false;

            }
            
        }

        private string Marca()
        {
            string url2 = "";
            // Si se ha presionado BtnMaybelline IsEnabled es false, 
            //este valor lo toma en BtnMaybelline_Clicked(object sender, EventArgs e)
            if (BtnMaybelline.IsEnabled == false) { url2 = servicioRest + "?brand=maybelline"; }

            // Idem pero con BtnClinique y BtnClinique_Clicked(object sender, EventArgs e)
            if (BtnClinique.IsEnabled == false) { url2 = servicioRest + "?brand=clinique"; }

            // Si ninguno se ha presionado, lo avisará la aplicación 
            if (BtnClinique.IsEnabled == true && BtnMaybelline.IsEnabled == true)
            {
                url2 = servicioRest + "?brand=none";
            }
            return url2;
        }

        private void Cargando()
        {
            ExpCara.IsExpanded = false;
            ExpDelin.IsExpanded = false;
            ExpLabios.IsExpanded = false;
            ExpOjos.IsExpanded = false;
            Indicador.IsVisible = true;
        }

        private void BtnLabial_Clicked(object sender, EventArgs e)
        {
            // Justo cuando se le pulsa al botón del tipo de producto, 
            //saltará un ActivityIndicator y se cerrarán los Expanders.
            Cargando();

            HttpClient cliente = new HttpClient();
            // Se añade al valor devuelto de Marca() el tipo de producto que corresponde al botón
            string url = Marca() + "&product_type=lipstick";
            // En este método se pasa el cliente junto a la url de donde se consumen los datos
            TomarDatos(cliente, url);
        }

        private void BtnColorete_Clicked(object sender, EventArgs e)
        {
            Cargando();
            string url = Marca() + "&product_type=blush";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnBronceador_Clicked(object sender, EventArgs e)
        {
            Cargando();
            string url = Marca() + "&product_type=bronzer";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnBase_Clicked(object sender, EventArgs e)
        {
            Cargando();
            string url = Marca() + "&product_type=foundation";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnPerfiladores_Clicked(object sender, EventArgs e)
        {
            Cargando();
            string url = Marca() + "&product_type=lip_liner";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnDelCejas_Clicked(object sender, EventArgs e)
        {
            Cargando();
            string url = Marca() + "&product_type=eyebrow";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnDelOjos_Clicked(object sender, EventArgs e)
        {
            Cargando();
            string url = Marca() + "&product_type=eyeliner";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnSombra_Clicked(object sender, EventArgs e)
        {
            Cargando();
            string url = Marca() + "&product_type=eyeshadow";
            TomarDatos(new HttpClient(), url);
        }

        private void BtnRimel_Clicked(object sender, EventArgs e)
        {
            Cargando();
            string url = Marca() + "&product_type=mascara";
            TomarDatos(new HttpClient(), url);
        }
    }
}
