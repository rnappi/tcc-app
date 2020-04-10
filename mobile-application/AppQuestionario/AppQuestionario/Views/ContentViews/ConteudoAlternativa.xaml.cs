using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppQuestionario.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConteudoAlternativa : ContentView
    {
        public ConteudoAlternativa()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public static readonly BindableProperty LetraProperty = BindableProperty.Create(
            "Letra",        // the name of the bindable property
            typeof(string),     // the bindable property type
            typeof(ConteudoAlternativa),   // the parent object type
            string.Empty);      // the default value for the property

        public string Letra
        {
            get => (string)GetValue(ConteudoAlternativa.LetraProperty);
            set => SetValue(ConteudoAlternativa.LetraProperty, value);
        }

        public static readonly BindableProperty DesricaoProperty = BindableProperty.Create(
            "Descricao",        // the name of the bindable property
            typeof(string),     // the bindable property type
            typeof(ConteudoAlternativa),   // the parent object type
            string.Empty);      // the default value for the property
        public string Descricao
        {
            get => (string)GetValue(ConteudoAlternativa.DesricaoProperty);
            set => SetValue(ConteudoAlternativa.DesricaoProperty, value);
        }


        public static readonly BindableProperty IdPerguntaProperty = BindableProperty.Create(
            "IdPergunta",        // the name of the bindable property
            typeof(int),     // the bindable property type
            typeof(ConteudoPergunta),   // the parent object type
            0);      // the default value for the property
        public int IdPergunta
        {
            get
            {
                var id = Convert.ToString(GetValue(ConteudoAlternativa.IdPerguntaProperty));
                if (int.TryParse(id, out int valor)) return valor;
                return 0;
            }
            set => SetValue(ConteudoAlternativa.IdPerguntaProperty, value);
        }

        public static readonly BindableProperty IdAlternativaProperty = BindableProperty.Create(
            "IdAlternativa",        // the name of the bindable property
            typeof(int),     // the bindable property type
            typeof(ConteudoPergunta),   // the parent object type
            0);      // the default value for the property
        public int IdAlternativa
        {
            get 
            {
                var id = Convert.ToString(GetValue(ConteudoAlternativa.IdAlternativaProperty));
                if (int.TryParse(id, out int valor)) return valor;
                return 0;
            }

            set => SetValue(ConteudoAlternativa.IdAlternativaProperty, value);
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var frame = sender as Frame;

            var slItens = frame.Parent.Parent as StackLayout;
            foreach (var sli in slItens.Children)
            {
                if (sli is ConteudoAlternativa)
                {
                    var f = (sli as ConteudoAlternativa).Content as Frame;

                    //Muda o fundo para branco de todos os frames, menos o que disparou o evento
                    if (f != frame) f.BackgroundColor = Color.White;
                }
            }

            var stack = frame.Content as StackLayout;
            var lblP = stack.FindByName("idPergunta") as Label;
            var lblA = stack.FindByName("idAlternativa") as Label;
            var IdPergunta = int.Parse(lblP.Text);
            var idAlternativa = int.Parse(lblA.Text);

            var resp = QuestionarioPage.listaRespostas.Find(f => f.IdPergunta == IdPergunta);
            if(resp != null) QuestionarioPage.listaRespostas.Remove(resp);

            if (frame.BackgroundColor == Color.LightGray)
            {
                frame.BackgroundColor = Color.White;
            }
            else
            {
                frame.BackgroundColor = Color.LightGray;
                var resposta = new Resposta()
                {
                    IdPergunta = IdPergunta,
                    IdAlternativa = idAlternativa
                };
                QuestionarioPage.listaRespostas.Add(resposta);
            }
        }
    }
}