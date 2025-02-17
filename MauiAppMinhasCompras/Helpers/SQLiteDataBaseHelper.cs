using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiAppMinhasCompras.Modells;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDataBaseHelper
    {
        // Conexão assíncrona com o banco de dados SQLite
        readonly SQLiteAsyncConnection _conn;

        // Construtor recebe o caminho do banco de dados e inicializa as tabelas
        public SQLiteDataBaseHelper (string path)
        {
            _conn = new SQLiteAsyncConnection (path);

            // Criação assíncrona das tabelas Produto e Vendedores
            _conn.CreateTableAsync<Produto>().Wait(); // O uso de .Wait() pode causar deadlocks em chamadas assíncronas
            _conn.CreateTableAsync<Vendedores>().Wait();

        }

        // Método para inserir um novo produto no banco de dados
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto p SET Descricao=?, Quantidade=?, Preco=? WHERE id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }


        // Método para deletar um produto com base no ID
        public Task<int> Delete(int id)
        {
            
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        // Método para recuperar todos os produtos cadastrados no banco de dados
        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        // Utilize parâmetros para evitar falhas de segurança
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * FROM  Produto WHERE Descricao like ?";

            return _conn.QueryAsync<Produto>(sql, "%" + q + "%");

        }


    }
}
