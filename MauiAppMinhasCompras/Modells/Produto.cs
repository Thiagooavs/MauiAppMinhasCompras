using SQLite;

namespace MauiAppMinhasCompras.Modells
{
    public class Produto
    {
        // Define a chave primária e a autoincrementação no banco de dados
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Descrição do produto (não pode ser nulo)
        public string Descricao { get; set; }

        // Preço do produto
        public double Preco { get; set; }

        // Quantidade do produto disponível
        public double Quantidade { get; set; }

        // Propriedade somente leitura que calcula o total automaticamente
        public double Total { get => Quantidade * Preco; }





    }
}
