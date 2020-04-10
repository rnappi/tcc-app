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
            //var json = Util.PegarQuestionariosAluno();
            var json = Util.MockPegarQuestionariosAluno();

            List<DescricaoQuestionario> listaQuestionarios = JsonConvert.DeserializeObject<List<DescricaoQuestionario>>(json);

            foreach (var item in listaQuestionarios)
            {
                var cardFrame = CriarFrame(item);
                slItens.Children.Add(cardFrame);
            }
        }

        private Frame CriarFrame(DescricaoQuestionario questionario)
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
                            Text = $"{questionario.qtdPerguntas} perguntas e {questionario.qtdAlternativas} alternativas"
                        }
                    }
                }
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Navigation.PushAsync(new QuestionarioPage(questionario.id_Questionario));
                //App.Current.MainPage = new QuestionarioPage();
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
    }
}