using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppQuestionario
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void xBtnEntrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var txtUsuario = xTxtUsuario.Text.Trim();
                var txtSenha = xTxtSenha.Text.Trim();

                if(txtUsuario == "root" && txtSenha == "root123")
                {
                    App.Current.MainPage = new AppQuestionario.MenuPage();
                }
                else
                {
                    DisplayAlert("Aviso", "Usuário ou senha incorreta", "Ok");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
