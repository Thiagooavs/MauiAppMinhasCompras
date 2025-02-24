using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Modells
{
    public enum Sexo
    {
        None = 0,
        Masculino = 1,
        Feminino = 2,
    }
    public class Vendedores // Correção do nome da classe para o singular
    {

        // Define a chave primária com autoincremento no banco de dados
        [PrimaryKey, AutoIncrement]

        public int id { get; set; } // Nome de propriedade ajustado para seguir convenção PascalCase


        // Nome do vendedor
        [NotNull]// Garante que o nome não será nulo no banco de dados
        public string Nome { get; set; } = string.Empty; // Evita valores nulos

        // Quantidade de vendas, clientes atendidos ou outra métrica (precisa de uma melhor definição)
        public int Qtd { get; set; }

        // Representa o sexo do vendedor (pode ser um enum para melhor legibilidade)
        public Sexo sexo { get; set; }
    }
        
}
