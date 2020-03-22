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
                new NavigationPage
                (
                    new ItensNaoRespondidosPage()
                    { 
                        Title = "Aluno 1" 
                    }
                ) { Title= "Não respondidos" });

            Children.Add(
                new NavigationPage
                (
                    new ItensRespondidosPage() 
                    { 
                        Title = "Aluno 1" 
                    }
                ) { Title = "Respondidos" });

            Children.Add(
                new NavigationPage
                (
                    new ItensAvaliadosPage() 
                    { 
                        Title = "Aluno 1" 
                    }
                ) { Title = "Avaliados" });
        }
    }
}