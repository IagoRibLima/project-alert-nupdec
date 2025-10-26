using alert_nupdec.Models;
using alert_nupdec.Repository;
using System.Collections;

namespace alert_nupdec;

public partial class CadastroVoluntario : ContentPage
{
    public CadastroVoluntario()
	{
		InitializeComponent();
	}

    private async void VoltarButton_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new Home();
    }

    private async void CadastrarOKButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            Usuario voluntario = new Usuario()
            {
                NomeCompleto = txt_nome_completo.Text,
                Email = txt_email.Text,
                Telefone = txt_telefone.Text,
                Unidade = txt_unidade.Text,
                Senha = txt_senha.Text
            };

            UsuarioRepository.cadastrarUsuario(voluntario);

            await DisplayAlert("Sucesso", "Voluntário cadastrado com sucesso!", "Fechar");

            txt_nome_completo.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_telefone.Text = string.Empty;
            txt_unidade.Text = string.Empty;
            txt_senha.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }
}