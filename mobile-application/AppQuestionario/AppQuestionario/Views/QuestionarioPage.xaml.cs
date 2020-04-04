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

            /*string url = "http://127.0.0.1:8080/api/questionarios/1";

            if (Device.RuntimePlatform == Device.Android)
            {
                url = "http://10.0.2.2:8080/api/questionarios/1";
            }

            WebClient wc = new WebClient();
            var json = wc.DownloadString(url);*/

            var json = MocJSON();

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

        private string MocJSON()
        {
            return "[{ \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Vossa Excelência Reverendíssima.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"O pronome de tratamento que melhor completa a oração a seguir é: __________________, cardeal Dom Sérgio da Rocha, acompanhará o Papa em sua visita ao Brasil.\", \"id_Alternativa\":1, \"id_Pergunta\":1, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Vossa Santidade.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"O pronome de tratamento que melhor completa a oração a seguir é: __________________, cardeal Dom Sérgio da Rocha, acompanhará o Papa em sua visita ao Brasil.\", \"id_Alternativa\":2, \"id_Pergunta\":1, \"id_Questionario\":1   },   { \"Alternativa_Correta\":1, \"DescricaoAlternativa\":\"Vossa Eminência.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"O pronome de tratamento que melhor completa a oração a seguir é: __________________, cardeal Dom Sérgio da Rocha, acompanhará o Papa em sua visita ao Brasil.\", \"id_Alternativa\":3, \"id_Pergunta\":1, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Vossa Magnificência.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"O pronome de tratamento que melhor completa a oração a seguir é: __________________, cardeal Dom Sérgio da Rocha, acompanhará o Papa em sua visita ao Brasil.\", \"id_Alternativa\":4, \"id_Pergunta\":1, \"id_Questionario\":1   },   { \"Alternativa_Correta\":1, \"DescricaoAlternativa\":\"Espera-se que, no Brasil, Sua Santidade, o Papa Francisco, seja recebido, com o devido respeito, pelos jovens.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(FCC- modificada) Os pronomes de tratamento estão empregados corretamente em:\", \"id_Alternativa\":5, \"id_Pergunta\":2, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"O advogado assim se pronunciou perante o juiz: - Peço a Vossa Senhoria que ouça o depoimento desta nova testemunha.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(FCC- modificada) Os pronomes de tratamento estão empregados corretamente em:\", \"id_Alternativa\":6, \"id_Pergunta\":2, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Vossa Majestade, a princesa da Inglaterra, foi homenageada por ocasião do seu aniversário.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(FCC- modificada) Os pronomes de tratamento estão empregados corretamente em:\", \"id_Alternativa\":7, \"id_Pergunta\":2, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Refiro-me ao Ilustríssimo Senhor, Cardeal de Brasília, ao enviar-lhe as notícias do Conclave.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(FCC- modificada) Os pronomes de tratamento estão empregados corretamente em:\", \"id_Alternativa\":8, \"id_Pergunta\":2, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Reitores de universidades.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(Prime Concursos) O pronome de tratamento Vossa Reverendíssima é usado para:\", \"id_Alternativa\":9, \"id_Pergunta\":3, \"id_Questionario\":1   },   { \"Alternativa_Correta\":1, \"DescricaoAlternativa\":\"Sacerdotes em geral.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(Prime Concursos) O pronome de tratamento Vossa Reverendíssima é usado para:\", \"id_Alternativa\":10, \"id_Pergunta\":3, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Papas.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(Prime Concursos) O pronome de tratamento Vossa Reverendíssima é usado para:\", \"id_Alternativa\":11, \"id_Pergunta\":3, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Altas autoridades.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(Prime Concursos) O pronome de tratamento Vossa Reverendíssima é usado para:\", \"id_Alternativa\":12, \"id_Pergunta\":3, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Príncipes.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(Crescer Consultoria) Vossa Eminência é o pronome de tratamento utilizado para:\", \"id_Alternativa\":13, \"id_Pergunta\":4, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Imperadores.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(Crescer Consultoria) Vossa Eminência é o pronome de tratamento utilizado para:\", \"id_Alternativa\":14, \"id_Pergunta\":4, \"id_Questionario\":1   },   { \"Alternativa_Correta\":1, \"DescricaoAlternativa\":\"Cardeais.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(Crescer Consultoria) Vossa Eminência é o pronome de tratamento utilizado para:\", \"id_Alternativa\":15, \"id_Pergunta\":4, \"id_Questionario\":1   },   { \"Alternativa_Correta\":0, \"DescricaoAlternativa\":\"Reitores de universidades.\", \"NomeQuestionario\":\"Português - Gramática\", \"Pergunta\":\"(Crescer Consultoria) Vossa Eminência é o pronome de tratamento utilizado para:\", \"id_Alternativa\":16, \"id_Pergunta\":4, \"id_Questionario\":1 }]";
        }
    }
}