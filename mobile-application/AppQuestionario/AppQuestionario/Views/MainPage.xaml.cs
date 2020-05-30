using AppQuestionario.Models;
using AppQuestionario.Views.Login;
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
            Navigation.PushAsync(new ModalCadastrarPage());
        }

        private void Validar(UsuarioModel usuario)
        {
            string dbPath = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                            App.NOME_DB);

            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Models.UsuarioModel>();

            var strUsuario = txtUsuario.Text == null ? "" : txtUsuario.Text.Trim();
            var strSenha = txtSenha.Text == null ? "" : txtSenha.Text.Trim();

            UsuarioModel usuarioLogin = new UsuarioModel()
            {
                Usuario = strUsuario,
                Senha = strSenha
            };

            var usuarioDB = db.Query<UsuarioModel>($"SELECT * FROM Usuario WHERE Login = '{strUsuario}'").FirstOrDefault();

            if (strUsuario == usuario?.Usuario && strSenha == usuario?.Senha)
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    App.Current.MainPage = new NavigationPage(new AppQuestionario.MenuPage() { Title = "Aluno 1" });
                }
                else
                {
                    DisplayAlert("Aviso", "Sem acesso a internet", "Ok");
                }
            }
            else
            {
                DisplayAlert("Aviso", "Usuário ou senha incorreta", "Ok");
            }

            btnLogar.IsVisible = true;
            aiLoad.IsVisible = false;
            gridLogin.IsEnabled = true;
        }

        private async Task delayTeste()
        {
            await Task.Delay(1000);
        }

        private async void btnLogar_Clicked(object sender, EventArgs e)
        {
            try
            {
                btnLogar.IsVisible = false;
                aiLoad.IsVisible = true;
                gridLogin.IsEnabled = false;

                //await delayTeste();
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
            }
        }
    }
}