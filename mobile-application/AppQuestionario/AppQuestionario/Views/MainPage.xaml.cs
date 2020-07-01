using AppQuestionario.Models;
using AppQuestionario.Views.Login;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppQuestionario
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
            var location = Geolocation.GetLastKnownLocationAsync();
        }

        private void btnConfig_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModalConfigPage());
        }

        private void btnSair_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }

        private void btnEsqueceuSenha_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModalEsqueceuSenhaPage());
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("Sem acesso a internet", "Não é possível realizar cadastro sem acesso a internet", "Ok");
                return;
            }

            Navigation.PushAsync(new ModalCadastrarPage());
        }

        private async void btnLogar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await DisplayAlert("Sem acesso a internet", "Não é possível utilizar o aplicativo sem acesso a internet", "Ok");
                    return;
                }

                btnLogar.IsVisible = false;
                aiLoad.IsVisible = true;
                gridLogin.IsEnabled = false;
                
                var strUsuario = txtUsuario.Text == null ? "" : txtUsuario.Text.Trim();
                var strSenha = txtSenha.Text == null ? "" : txtSenha.Text.Trim();

                UsuarioModel usuarioLogin = new UsuarioModel()
                {
                    Usuario = strUsuario,
                    Senha = strSenha
                };

                var usuarioLogado = await Util.Login(usuarioLogin);
                //Validar(usuarioLogado);

                if(usuarioLogado == null)
                {
                    await DisplayAlert("Aviso", "Usuário ou senha incorreta", "Ok");
                    btnLogar.IsVisible = true;
                    aiLoad.IsVisible = false;
                    gridLogin.IsEnabled = true;
                    return;
                }
                else
                {
                    App.UsuarioLogado = usuarioLogado;

                    var json = Util.PegarQuestionariosAluno().Result;
                    //var json = Util.MockPegarQuestionariosAluno();

                    if (json != null)
                    {
                        App.ListaQuestionarios = JsonConvert.DeserializeObject<List<DescricaoQuestionario>>(json);
                    }
                    else
                    {
                        await DisplayAlert("Erro", "Erro ao buscar dados na API, tente mais tarde.", "Ok");
                        return;
                    }

                    App.Current.MainPage = new NavigationPage(new AppQuestionario.MenuPage() { Title = usuarioLogado.Nome });
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
            finally
            {
                btnLogar.IsVisible = true;
                aiLoad.IsVisible = false;
                gridLogin.IsEnabled = true;
            }
        }
    }
}