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

namespace AppQuestionario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : CarouselPage
    {
        public MenuPage()
        {
            InitializeComponent();

            string url = "http://127.0.0.1:5000/api/questionarios/2";

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
                        Margin = new Thickness(50, 10, 50, 0)
                    };

                    sl.Children.Add(alternativa);
                    ++ numAlternativa;
                }

                var page = new ContentPage
                {
                    Content = sl
                };

                Children.Add(page);
                i++;
            }
        }
    }
}