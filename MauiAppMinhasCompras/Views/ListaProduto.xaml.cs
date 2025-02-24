
using MauiAppMinhasCompras.Modells;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;


public partial class ListaProduto : ContentPage
{
    private readonly ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
    private CancellationTokenSource _searchCancellationTokenSource;

    public ListaProduto()
    {
        InitializeComponent();
        lst_produtos.ItemsSource = lista;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing(); // 🔹 Adicionado para manter o comportamento do ciclo de vida

        try
        {
            var produtos = await App.Db.GetAll();
            AtualizarLista(produtos);

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");

        }

    }
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            DisplayAlert("ops", ex.Message, "OK");

        }
    }


    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            _searchCancellationTokenSource?.Cancel();
            _searchCancellationTokenSource = new CancellationTokenSource();
            await Task.Delay(500, _searchCancellationTokenSource.Token); // 🔹 Debounce para evitar múltiplas chamadas rápidas


            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                var produtos = await App.Db.GetAll();
                AtualizarLista(produtos);
            }
            else
            {
                var produtos = await App.Db.Search(e.NewTextValue);
                AtualizarLista(produtos);
            }

        }
        catch (TaskCanceledException)
        {
            // 🔹 Ignorar erro se a tarefa for cancelada (evita exceções desnecessárias)
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Total);

        string msg = $"O total é {soma:C}";

        DisplayAlert("Total produtos", msg, "OK");
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (sender is MenuItem menuItem && menuItem.BindingContext is Produto produtoSelecionado)
            {
                bool confirm = await DisplayAlert("Tem certeza?", $"Remover {produtoSelecionado.Descricao}?", "Sim", "Não");

                if (confirm)
                {
                    await App.Db.Delete(produtoSelecionado.Id);
                    lista.Remove(produtoSelecionado);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void lst_produtos_ItemTapped(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto p = e.SelectedItem as Produto;

            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p,
            });
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void AtualizarLista(IEnumerable<Produto> produtos)
    {
        lista.Clear(); // 🔹 Evita piscar a tela ao atualizar a lista
        foreach (var produto in produtos)
        {
            lista.Add(produto);
        }
    }
}
