using AppQuestionario.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.Generic;
using AppQuestionario.Models;

namespace AppQuestionario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : TabbedPage
    {
        public MenuPage(string mensagem = "")
        {
            InitializeComponent();

            Children.Add(
                
                    new ItensNaoRespondidosPage()
                    { 
                        Title = "Não respondidos" 
                    });

            Children.Add(
                
                    new ItensRespondidosPage() 
                    { 
                        Title = "Respondidos" 
                    });

            string localizacao = "";
            try
            {
                localizacao = Util.PegarLocalizacao().Result;
            }
            catch (Exception)
            {
                localizacao = "Latitude: 0, Longitude: 0, Altitude: 0";
            }

            var log = new LogSistema()
            {
                Id_Aluno = App.UsuarioLogado.ID_Aluno,
                Id_TipoLogSistema = TipoLog.Login,
                Descricao = $"{App.UsuarioLogado.Nome} logou no sistema",
                Localizacao = localizacao
            };

            GerarLog(log);

            if (!string.IsNullOrEmpty(mensagem))
            {
                DisplayAlert("Questionario respondido com sucesso", mensagem, "OK");
            }
        }

        private async void GerarLog(LogSistema log)
        {
            await Util.SalvarLog(log);
        }

        private async void btnSair_Clicked(object sender, System.EventArgs e)
        {
            bool sair = await DisplayAlert("Alerta", "Finalizar sessão?", "Sim", "Não");

            if (sair)
            {
                App.Current.MainPage = new NavigationPage(new MainPage());

                string localizacao = "";
                try
                {
                    localizacao = Util.PegarLocalizacao().Result;
                }
                catch (Exception)
                {
                    localizacao = "Latitude: 0, Longitude: 0, Altitude: 0";
                }

                var log = new LogSistema()
                {
                    Id_Aluno = App.UsuarioLogado.ID_Aluno,
                    Id_TipoLogSistema = TipoLog.Logout,
                    Descricao = $"{App.UsuarioLogado.Nome} saiu do sistema",
                    Localizacao = localizacao
                };

                await Util.SalvarLog(log);
            }
        }
    }
}