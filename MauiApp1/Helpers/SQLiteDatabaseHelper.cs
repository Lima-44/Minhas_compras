using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiApp1.Models;


namespace MauiApp1.Helpers;


    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper (string path) 
       {
            _conn = new SQLiteAsyncConnection(path);
             _conn.CreateTableAsync<Produto>().Wait();
       }

        public Task<int> Insert(Produto p) 
        {
            return _conn.InsertAsync(p);

        }

        public Task<Lista<Produto>> Update(Produto p) 
        {
            string sql = "Update Produto set Descricao=?, Quantidade =?, Preco where id=?";
            
            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.id
                
                );
        }
        
        public Task<int> Delete(int id) 
        {

           return _conn.Table<Produto>().DeleteAsync(i => i.id == id);

        }

        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();

        }

        public Task<List<Produto>> Search(String q) 
        {
            string sql = "SELECT * Produto WHERE Descricao LIKE '%" + q + "%'";
            
            return _conn.QueryAsync<Produto>(sql);


        }


    }



