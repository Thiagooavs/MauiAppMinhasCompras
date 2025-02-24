using MauiAppMinhasCompras.Modells;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Verifica se o BindingContext é um Produto válido
            if (BindingContext is not Produto produto_anexado)
            {
                await DisplayAlert("Erro", "Erro ao carregar os dados do produto.", "OK");
                return;
            }

            // Validação de entrada para evitar exceções ao converter valores
            if (string.IsNullOrWhiteSpace(txt_descricao.Text) ||
                string.IsNullOrWhiteSpace(txt_quantidade.Text) ||
                string.IsNullOrWhiteSpace(txt_preco.Text))
            {
                await DisplayAlert("Erro", "Preencha todos os campos.", "OK");
                return;
            }

            // Converte valores com TryParse para evitar exceções
            if (!double.TryParse(txt_quantidade.Text, out double quantidade) ||
                !double.TryParse(txt_preco.Text, out double preco))
            {
                await DisplayAlert("Erro", "Valores inválidos para quantidade ou preço.", "OK");
                return;
            }


            //Produto produto_anexado = BindingContext as Produto;

            // Atualiza o produto com os novos valores
            produto_anexado.Descricao = txt_descricao.Text;
            produto_anexado.Quantidade = quantidade;
            produto_anexado.Preco = preco;

            // Salva no banco de dados
            await App.Db.Update(produto_anexado);

            // Confirmação para o usuário
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");

            // Volta para a tela anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", $"Erro ao atualizar produto: {ex.Message}", "OK");
        }
    }
}
