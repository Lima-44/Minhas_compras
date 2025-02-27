using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiApp1.Models;
namespace MauiApp1.Models;


    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int id {get; set;}
        public string Descricao {get; set;}
        public double Quantidade {get; set;}
        public double Preco {get; set;}
    }

