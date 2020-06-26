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
        private int qtdPerguntas = 0;
        private int idQuestionarioCarregado = 0;
        public static List<Resposta> listaRespostas;

        public QuestionarioPage(int idQuestionario)
        {
            InitializeComponent();

            idQuestionarioCarregado = idQuestionario;

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
            var questionarios = App.ListaQuestionarios.FindAll(f => f.IdQuestionario == idQuestionario);

            //Atualiza quantidade de perguntas do questionario
            qtdPerguntas = questionarios[0].QtdPerguntas;
            Title = questionarios[0].NomeQuestionario;

            var perguntas = questionarios.GroupBy(g => g.IdPergunta)
                                        .Select(s => s.First())
                                        .ToList();
            int i = 1;

            foreach (var p in perguntas)
            {
                var alternativas = questionarios.FindAll(f => f.IdPergunta == p.IdPergunta);

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
                        IdPergunta = p.IdPergunta,
                        IdAlternativa = item.IdAlternativa,
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

        private async void btnConfirmar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(qtdPerguntas == listaRespostas.Count)
                {
                    RespostasQuestionario respostasQuestionario = new RespostasQuestionario()
                    {
                        IdAluno = App.UsuarioLogado.ID_Aluno,
                        IdQuestionario = idQuestionarioCarregado,
                        Respostas = listaRespostas.Select(s => s.IdAlternativa).ToList()
                    };

                    this.IsEnabled = false;
                    var json = await Util.SalvarQuestionariosAluno(respostasQuestionario);

                    if(json == null)
                    {
                        await DisplayAlert("Erro", "Não foi possível acessar o servidor, tente mais tarde", "Ok");
                        return;
                    }

                    var respAPI = JsonConvert.DeserializeObject<RespostaAPI>(json);

                    var listaQuestionarioAtual = App.ListaQuestionarios.FindAll(f => f.IdQuestionario == idQuestionarioCarregado);
                    foreach (var item in listaQuestionarioAtual)
                    {
                        item.QtdAcertos = respAPI.QtdAcertos;
                        item.Tentativa = respAPI.IdTentativa;
                    }

                    var mensagem = $"Você acertou {respAPI.QtdAcertos} de {listaQuestionarioAtual[0].QtdPerguntas} perguntas do questionário {listaQuestionarioAtual[0].NomeQuestionario}.";
                    App.Current.MainPage = new NavigationPage(new AppQuestionario.MenuPage(mensagem) { Title = App.UsuarioLogado.Nome });
                }
                else
                {
                    await DisplayAlert("Erro", "O questionário está incompleto, responda todas as perguntas para finalizar o questionário", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}