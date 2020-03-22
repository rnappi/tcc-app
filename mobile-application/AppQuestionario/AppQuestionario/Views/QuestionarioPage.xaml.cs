using AppQuestionario.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppQuestionario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionarioPage : CarouselPage
    {
        public QuestionarioPage()
        {
            InitializeComponent();
            string url = "http://127.0.0.1:5000/api/questionarios/1";

            if (Device.RuntimePlatform == Device.Android)
            {
                url = "http://10.0.2.2:5000/api/questionarios/1";
            }

            WebClient wc = new WebClient();
            var json = wc.DownloadString(url);

            List<Questionario> questionario = JsonConvert.DeserializeObject<List<Questionario>>(json);

            var perguntas = questionario.GroupBy(g => g.id_Pergunta)
                                        .Select(s => s.First())
                                        .ToList();
            int i = 1;

            foreach (var p in perguntas)
            {
                var alternativas = questionario.FindAll(f => f.id_Pergunta == p.id_Pergunta);

                var lbl = new Label
                {
                    Text = "Pergunta " + i + ": \n" + p.Pergunta,
                    //HorizontalOptions = LayoutOptions.StartAndExpand,
                    Margin = new Thickness(50, 20, 50, 0)

                };

                var slPergunta = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal
                };

                var slLetra = new StackLayout()
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "Pergunta " + i + ": \n" + p.Pergunta,
                            //HorizontalOptions = LayoutOptions.StartAndExpand,
                            Margin = new Thickness(50, 20, 50, 0)
                        }
                    }
                };

                var sl = new StackLayout
                {
                    Children = { lbl },
                    Orientation = StackOrientation.Vertical
                };

                char numAlternativa = 'A';

                foreach (var item in alternativas)
                {
                    var alternativa = new Label
                    {
                        Text = $"{numAlternativa} - " + item.DescricaoAlternativa,
                        TextColor = Color.Black,
                        Margin = new Thickness(50, 10, 50, 0)
                    };
                    
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) => {
                        //App.Current.MainPage = new QuestionarioPage();
                        var f = (s as Label);

                        var slItens = f.Parent as StackLayout;
                        foreach (var sli in slItens.Children)
                        {
                            if (sli is Label)
                            {
                                (sli as Label).TextColor = Color.Black;
                            }
                        }

                        if (f.TextColor == Color.Yellow)
                        {
                            f.TextColor = Color.Black;
                        }
                        else
                        {
                            f.TextColor = Color.Yellow;
                        }
                    };

                    alternativa.GestureRecognizers.Add(tapGestureRecognizer);

                    sl.Children.Add(alternativa);
                    ++numAlternativa;
                }

                var page = new ContentPage
                {
                    Content = sl
                };

                Children.Add(page);
                i++;
            }
        }
        /*
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
        }*/
    }
}