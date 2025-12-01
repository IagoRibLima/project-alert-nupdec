using alert_nupdec.Models;
using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class CadastroVoluntario : ContentPage
{
	public CadastroVoluntario()
	{
		InitializeComponent();

        //Opções do picker das unidades
        picker_unidades.ItemsSource = UnidadeRepository.list_unidade;
        picker_unidades.ItemDisplayBinding = new Binding("nome");      
    }

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //Botão com metodo de cadastrar os novos usuarios
    private async void ButtonCadastrar(object sender, EventArgs e)
    {
        try
        {
            string nome = txt_nome_completo.Text?.Trim();
            string email = txt_email.Text?.Trim();
            string cpf = txt_cpf.Text?.Trim();
            string telefone = txt_telefone.Text?.Trim();
            Unidade unidade = picker_unidades.SelectedItem as Unidade;
            string senha = txt_senha.Text?.Trim();
                   
            UsuarioRepository.cadastrarUsuario(nome, email, cpf, telefone, unidade, senha);

            await DisplayAlert("Sucesso", "Voluntário cadastrado com sucesso!", "Fechar");

            txt_nome_completo.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_cpf.Text = string.Empty;
            txt_telefone.Text = string.Empty;
            picker_unidades.SelectedItem = null;
            txt_senha.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }

    //Botão que mostra e esconde a senha
    private void ButtonVerSenha(object sender, EventArgs e)
    {
        txt_senha.IsPassword = !txt_senha.IsPassword;

        var button = (ImageButton)sender;

        if (txt_senha.IsPassword)
        {
            button.Source = "olho_aberto.png";
        }
        else
        {
            button.Source = "olho_fechado.png";
        }
    }

}