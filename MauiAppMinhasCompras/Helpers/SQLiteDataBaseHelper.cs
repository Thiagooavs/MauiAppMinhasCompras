﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiAppMinhasCompras.Modells;

namespace MauiAppMinhasCompras.Helpers
{
    internal class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDataBaseHelper (string path)
        {
            _conn = new SQLiteAsyncConnection (path);
            _conn.CreateTableAsync<Produto>().Wait();
            _conn.CreateTableAsync<Vendedores>().Wait();

        }

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produtp SET Descricao=?, Quantidade=?, Preco=?, WHERE id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }



        public  Task<int> Delete(int id)
        {
            
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        public  Task<List<Produto>> GetAll(int id) 
        {
            return _conn.Table<Produto>().ToListAsync();
        }
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * FROM  Produto WHERE Descricao like '% " + q + "%'";

            return _conn.QueryAsync<Produto>(sql);

        }


    }
}