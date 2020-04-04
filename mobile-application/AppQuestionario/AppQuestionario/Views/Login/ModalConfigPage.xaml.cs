using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppQuestionario.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalConfigPage : ContentPage
    {
        public ModalConfigPage()
        {
            InitializeComponent();
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var frame = sender as Frame;

            var slItens = frame.Parent as StackLayout;
            foreach (var sli in slItens.Children)
            {
                if (sli is Frame && sli != frame)
                {
                    (sli as Frame).BackgroundColor = Color.White;
                }
            }

            if (frame.BackgroundColor == Color.LightGray)
            {
                frame.BackgroundColor = Color.White;
            }
            else
            {
                frame.BackgroundColor = Color.LightGray;
            }
        }
    }
}