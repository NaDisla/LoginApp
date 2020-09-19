using LoginApp.Models;
using LoginApp.Views.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginApp.Views.Usuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        private const string url = "http://10.0.0.5:45457/usuarios";
        
        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void btnRegistroUser_Clicked(object sender, EventArgs e)
        {
            ModelUsuarios user = new ModelUsuarios()
            {
                RolId = 102,
                UsuNombre = txtNombreUsuario.Text,
                UsuNombreReal = txtNombreReal.Text,
                UsuClave = txtClaveRegistro.Text
            };
            try
            {
                HttpClient client = new HttpClient();
                var jsonPost = JsonConvert.SerializeObject(user);
                HttpContent contentModel = new StringContent(jsonPost);
                contentModel.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync(url, contentModel);

                if (result.IsSuccessStatusCode)
                    await DisplayAlert("Registro correcto", "Se ha registrado correctamente", "OK");
                await Navigation.PushAsync(new LoginPage());
            }
            catch (Exception)
            {
                await DisplayAlert("Registro incorrecto", "Ha ocurrido un error durante el registro", "OK");
            }
            

        }
    }
}