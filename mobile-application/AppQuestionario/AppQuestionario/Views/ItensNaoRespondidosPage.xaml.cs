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
    public partial class ItensNaoRespondidosPage : ContentPage
    {
        public ItensNaoRespondidosPage()
        {
            InitializeComponent();

            try
            {
                MontarItens();
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private void MontarItens()
        {
            var listaQuestionarios = App.ListaQuestionarios
                                        .GroupBy(g => g.IdQuestionario)
                                        .Select(s => s.First())
                                        .ToList()
                                        .FindAll(f => f.Tentativa == 0);

            if (listaQuestionarios.Count == 0)
            {
                var label = new Label()
                {
                    Text = "Não há novos questionários",
                    TextColor = Color.White,
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                slItens.Children.Add(label);
                return;
            }
            else
            {
                foreach (var item in listaQuestionarios)
                {
                    var cardFrame = CriarFrameSelecaoQuestionario(item);
                    slItens.Children.Add(cardFrame);
                }
            }
        }

        private TapGestureRecognizer CriarEventoToque(DescricaoQuestionario questionario)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();

            tapGestureRecognizer.Tapped += (sender, eventArgs) => {

                Navigation.PushAsync(new QuestionarioPage(questionario.IdQuestionario));

                var frameDisparouEvento = (sender as Frame);

                foreach (var item in slItens.Children)
                {
                    if (item is Frame)
                    {
                        (item as Frame).BackgroundColor = Color.White;
                    }
                }

                if (frameDisparouEvento.BackgroundColor == Color.LightGray)
                {
                    frameDisparouEvento.BackgroundColor = Color.White;
                }
                else
                {
                    frameDisparouEvento.BackgroundColor = Color.LightGray;
                }
            };

            return tapGestureRecognizer;
        }

        private Frame CriarFrameSelecaoQuestionario(DescricaoQuestionario questionario)
        {
            Frame cardFrame = new Frame
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.White,
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
                            Text = questionario.NomeQuestionario,
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
                            Text = $"{questionario.QtdPerguntas} perguntas e {questionario.QtdAlternativas} alternativas"
                        }
                    }
                }
            };

            
            var tapGestureRecognizer = CriarEventoToque(questionario);
            cardFrame.GestureRecognizers.Add(tapGestureRecognizer);

            return cardFrame;
        }
    }
}