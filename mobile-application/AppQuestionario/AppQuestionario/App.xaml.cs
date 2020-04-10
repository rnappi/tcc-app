using SQLite;
using System;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppQuestionario
{
    public partial class App : Application
    {
        public static readonly string NOME_DB = "questionarios.db3";

        public App()
        {
            InitializeComponent();

            Util.MockUsuarios();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
