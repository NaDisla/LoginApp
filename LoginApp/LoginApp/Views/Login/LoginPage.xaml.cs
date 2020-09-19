using LoginApp.Models;
using LoginApp.Views.Usuarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private const string url = "http://10.0.0.5:45457/usuarios";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ModelUsuarios> users;
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            string content = await client.GetStringAsync(url);
            List<ModelUsuarios> getUsers = JsonConvert.DeserializeObject<List<ModelUsuarios>>(content);
            users = new ObservableCollection<ModelUsuarios>(getUsers);

            try
            {                         
                var validateUser = getUsers.Where(x => x.UsuNombre == txtUsuario.Text && x.UsuClave == txtClave.Text).Select(y => y).FirstOrDefault();
                if (validateUser != null)
                    await DisplayAlert("Binvenido(a)","¡Hola "+txtUsuario.Text+"!","OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Usuario incorrecto", "No existe usuario.", "OK");
            }

        }

        private void OlvidoClave_Tapped(object sender, EventArgs e)
        {

        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroPage());
        }
    }
}