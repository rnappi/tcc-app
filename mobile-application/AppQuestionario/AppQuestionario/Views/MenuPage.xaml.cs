using AppQuestionario.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.Generic;

namespace AppQuestionario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : TabbedPage
    {
        public MenuPage()
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

            Children.Add(
                
                    new ItensAvaliadosPage() 
                    { 
                        Title = "Avaliados" 
                    });

            //TODO: Salvar no BD a localização no Login
            var localizacao = Util.PegarLocalizacao();
            //DisplayAlert("Localização", localizacao.Result, "Ok");
        }

        private async void btnSair_Clicked(object sender, System.EventArgs e)
        {
            bool sair = await DisplayAlert("Alerta", "Finalizar sessão?", "Sim", "Não");

            if (sair) App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}