using AppQuestionario.Models;
using AppQuestionario.Views.ContentViews;
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
    public class Resposta
    {
        public int IdPergunta { get; set; }
        public int IdAlternativa { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionarioPage : CarouselPage
    {
        public static List<Resposta> listaRespostas;

        public QuestionarioPage(int idQuestionario)
        {
            InitializeComponent();

            try
            {
                MontarPaginas(idQuestionario);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private void MontarPaginas(int idQuestionario)
        {
            listaRespostas = new List<Resposta>();

            //var json = Util.PegarQuestionario(idQuestionario);
            var json = Util.MockPegarQuestionario(idQuestionario);

            List<Questionario> questionarios = JsonConvert.DeserializeObject<List<Questionario>>(json);

            var perguntas = questionarios.GroupBy(g => g.id_Pergunta)
                                        .Select(s => s.First())
                                        .ToList();
            
            //TODO: Salvar BD Local
            //Util.SalvarQuestionariosAluno(questionarios, idQuestionario);

            int i = 1;

            foreach (var p in perguntas)
            {
                var alternativas = questionarios.FindAll(f => f.id_Pergunta == p.id_Pergunta);

                var slPergunta = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.DeepSkyBlue,
                    Spacing = 10,
                    Padding = 10
                };

                var pergunta = new ConteudoPergunta()
                {
                    Pergunta = "Pergunta " + i + ": " + p.Pergunta
                };

                slPergunta.Children.Add(pergunta);

                var slAlternativas = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                char numAlternativa = 'A';

                foreach (var item in alternativas)
                {
                    var alternativa = new ConteudoAlternativa()
                    {
                        IdPergunta = p.id_Pergunta,
                        IdAlternativa = item.id_Alternativa,
                        Letra = Convert.ToString(numAlternativa),
                        Descricao = item.DescricaoAlternativa
                    };

                    slAlternativas.Children.Add(alternativa);
                    ++numAlternativa;
                }

                var scroll = new ScrollView()
                {
                    Content = slAlternativas
                };

                slPergunta.Children.Add(scroll);

                var page = new ContentPage
                {
                    Content = slPergunta
                };

                Children.Add(page);
                i++;
            }
        }
    }
}