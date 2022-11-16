using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoGet
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://localhost/cliente/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ProyectoGet.Ws.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
        }

        public async void get()
        {
            var content = await client.GetStringAsync(Url);
            List<ProyectoGet.Ws.Datos> posts = JsonConvert.DeserializeObject<List<ProyectoGet.Ws.Datos>>(content);
            _post = new ObservableCollection<ProyectoGet.Ws.Datos>(posts);

            MyListView.ItemsSource = _post;
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VentanaIngreso());

        }
    }
}
