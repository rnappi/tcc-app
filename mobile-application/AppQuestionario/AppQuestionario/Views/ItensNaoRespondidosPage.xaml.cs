using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppQuestionario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItensNaoRespondidosPage : ContentPage
    {
        public ItensNaoRespondidosPage()
        {
            InitializeComponent();

            for (int i = 1; i <= 10; i++)
            {
                var cardFrame = CriarFrame(i);
                slItens.Children.Add(cardFrame);
            }
        }

        private Frame CriarFrame(int i)
        {
            Frame cardFrame = new Frame
            {
                BorderColor = Color.Gray,
                CornerRadius = 5,
                Padding = 8,
                HasShadow = true,
                Content = new StackLayout
                {
                    Padding = 10,
                    Children =
                    {
                        new Label
                        {
                            Text = "Questionário "+i,
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            FontAttributes = FontAttributes.Bold,
                            MinimumWidthRequest = 100
                        },
                        new BoxView
                        {
                            Color = Color.Gray,
                            HeightRequest = 2,
                            HorizontalOptions = LayoutOptions.Fill
                        },
                        new Label
                        {
                            Text = "10 perguntas e 4 alternativas"
                        }
                    }
                }
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Navigation.PushAsync(new QuestionarioPage());
                var f = (s as Frame);

                foreach (var item in slItens.Children)
                {
                    if(item is Frame)
                    {
                        (item as Frame).BackgroundColor = Color.White;
                    }
                }
                
                if (f.BackgroundColor == Color.LightGray)
                {
                    f.BackgroundColor = Color.White;
                }
                else
                {
                    f.BackgroundColor = Color.LightGray;
                }
            };

            cardFrame.GestureRecognizers.Add(tapGestureRecognizer);

            return cardFrame;
        }

        private Frame CriarFrame(char letraAlternativa)
        {
            var g = new Grid
            {
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(0.35, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(0.65, GridUnitType.Star)},
                },
                ColumnSpacing = 0,
                RowSpacing = 0
            };

            Frame cardFrame = new Frame
            {
                BorderColor = Color.Gray,
                CornerRadius = 5,
                Padding = 8,
                HasShadow = true,
                Content = new StackLayout
                {
                    Padding = 10,
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        new Label
                        {
                            Text = letraAlternativa.ToString(),
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                            FontAttributes = FontAttributes.Bold
                        },
                        new BoxView
                        {
                            Color = Color.Gray,
                            WidthRequest = 2,
                            VerticalOptions = LayoutOptions.Fill
                        },
                        new Label
                        {
                            Text = "10 perguntas e 4 alternativas"
                        }
                    }
                }
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                //App.Current.MainPage = new QuestionarioPage();
                var f = (s as Frame);

                foreach (var item in slItens.Children)
                {
                    if (item is Frame)
                    {
                        (item as Frame).BackgroundColor = Color.White;
                    }
                }

                if (f.BackgroundColor == Color.LightGray)
                {
                    f.BackgroundColor = Color.White;
                }
                else
                {
                    f.BackgroundColor = Color.LightGray;
                }
            };

            cardFrame.GestureRecognizers.Add(tapGestureRecognizer);

            return cardFrame;
        }
    }
}