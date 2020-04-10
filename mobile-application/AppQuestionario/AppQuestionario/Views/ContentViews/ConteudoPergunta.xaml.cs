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
    public partial class ConteudoPergunta : ContentView
    {
        public ConteudoPergunta()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public static readonly BindableProperty PerguntaProperty = BindableProperty.Create(
            "Pergunta",        // the name of the bindable property
            typeof(string),     // the bindable property type
            typeof(ConteudoPergunta),   // the parent object type
            string.Empty);      // the default value for the property
        public string Pergunta
        {
            get => (string)GetValue(ConteudoPergunta.PerguntaProperty);
            set => SetValue(ConteudoPergunta.PerguntaProperty, value);
        }
    }
}