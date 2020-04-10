using AppQuestionario.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        }

        private async void btnSair_Clicked(object sender, System.EventArgs e)
        {
            bool sair = await DisplayAlert("Alerta", "Finalizar sessão?", "Sim", "Não");

            if (sair) App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}