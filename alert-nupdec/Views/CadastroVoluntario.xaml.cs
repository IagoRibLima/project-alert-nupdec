using alert_nupdec.Models;
using System.Collections;

namespace alert_nupdec;

public partial class CadastroVoluntario : ContentPage
{
    ArrayList lista_voluntarios = new ArrayList();

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

            lista_voluntarios.Add(voluntario);

            await DisplayAlert("Sucesso", "Voluntário cadastrado com sucesso!", "Fechar");

            for(int i=0; i<lista_voluntarios.Count; i++)
            {
                Usuario v = (Usuario)lista_voluntarios[i];
                System.Diagnostics.Debug.WriteLine($"Voluntário {i + 1}: {v.NomeCompleto}, {v.Email}, {v.Telefone}, {v.Unidade}");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }
}