using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppQuestionario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : CarouselPage
    {
        public MenuPage()
        {
            InitializeComponent();

            for (int i = 1; i <= 5; i++)
            {
                var lbl = new Label
                {
                    Text = "Pergunta " + i,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = 100

                };

                var page = new ContentPage
                {
                    Content = new StackLayout
                    {
                        Children = {lbl}
                    }
                };

                Children.Add(page);
            }
        }
    }
}