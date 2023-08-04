using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiGestionStock.Models
{
    public class BdStockExamContext : DbContext
    {
        public BdStockExamContext() : base("BdStockExam") 
        { }


        public DbSet<Produits> Produits { get; set; }
        public DbSet<StockProduit> StockProduits { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Administrateurs { get; set; }
        public DbSet<Caissier> Caissiers { get; set; }

        public System.Data.Entity.DbSet<ApiGestionStock.Models.Commande> Commandes { get; set; }
    }
}