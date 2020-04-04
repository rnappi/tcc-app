using AppQuestionario.Views.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppQuestionario
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
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

        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModalCadastrarPage());
        }

        private void Validar()
        {
            var strUsuario = txtUsuario.Text == null ? "" : txtUsuario.Text.Trim();
            var strSenha = txtSenha.Text == null ? "" : txtSenha.Text.Trim();

            if (strUsuario == "root" && strSenha == "root123")
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    App.Current.MainPage = new AppQuestionario.MenuPage();
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
            await Task.Delay(5000);
        }

        private async void btnLogar_Clicked(object sender, EventArgs e)
        {
            try
            {
                btnLogar.IsVisible = false;
                aiLoad.IsVisible = true;
                gridLogin.IsEnabled = false;

                await delayTeste();
                Validar();
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
