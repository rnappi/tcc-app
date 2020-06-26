using AppQuestionario.Models;
using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppQuestionario.Views.Login
{
    public class ValidarCadastro : AbstractValidator<CadastroUsuario>
    {
        public ValidarCadastro()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("Informe o nome")
                                .Length(5, 50).WithMessage("O nome deve ter entre 5 e 50 caracteres.");

            RuleFor(x => x.Email).NotNull().WithMessage("Informe o email")
                                 .EmailAddress().WithMessage("Email inválido.");

            RuleFor(x => x.Usuario).NotNull().WithMessage("Informe o usuário")
                                   .Length(5, 50).WithMessage("O usúario deve ter entre 5 e 50 caracteres.");

            RuleFor(x => x.Senha).NotNull().WithMessage("Informe a senha")
                                 .Length(8, 20).WithMessage("Senha deve ter enter 8 e 20 caracteres.");
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalCadastrarPage : ContentPage
    {
        public ModalCadastrarPage()
        {
            InitializeComponent();
        }

        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                txtNome.Text = txtNome.Text?.Trim();
                txtEmail.Text = txtEmail.Text?.Trim();
                txtUsuario.Text = txtUsuario.Text?.Trim();
                txtSenha.Text = txtSenha.Text?.Trim();

                VerificarCampos();

                var valida = new ValidarCadastro();
                var usuario = new CadastroUsuario()
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Usuario = txtUsuario.Text,
                    Senha = txtSenha.Text
                };

                var resultadoValidacoes = valida.Validate(usuario);

                if (resultadoValidacoes.IsValid)
                {
                    btnCadastrar.IsVisible = false;
                    txtNome.IsEnabled = false;
                    txtEmail.IsEnabled = false;
                    txtUsuario.IsEnabled = false;
                    txtSenha.IsEnabled = false;
                    aiLoad.IsVisible = true;

                    var respJSON = await Util.CriarUsuario(usuario);

                    if (respJSON == null)
                    {
                        await DisplayAlert("Erro", "Não foi possível acessar o servidor, tente mais tarde", "Ok");
                        return;
                    }

                    RespostaAPI respostaAPI = JsonConvert.DeserializeObject<RespostaAPI>(respJSON);

                    await App.Current.MainPage.DisplayAlert("Cadastro", respostaAPI.Msg, "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Erro no cadastro", resultadoValidacoes.Errors[0].ErrorMessage, "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
            finally
            {
                btnCadastrar.IsVisible = true;
                txtNome.IsEnabled = true;
                txtEmail.IsEnabled = true;
                txtUsuario.IsEnabled = true;
                txtSenha.IsEnabled = true;
                aiLoad.IsVisible = false;
            }
        }

        private void VerificarCampos()
        {
            string padrao = "^[a-zA-Z0-9]{6,20}$";
            Regex re = new Regex(padrao);

            if (!re.IsMatch(txtUsuario.Text) || !re.IsMatch(txtSenha.Text))
                throw new Exception("Usuário e senha não pode conter caracteres especiais.");

            //if (txtEmail.Text.Contains(" ") || txtUsuario.Text.Contains(" ")|| txtSenha.Text.Contains(" "))
            //    throw new Exception("Email, usuário e senha não pode conter espaço.");
        }
    }
}