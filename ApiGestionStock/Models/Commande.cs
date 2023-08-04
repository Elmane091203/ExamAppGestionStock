using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiGestionStock.Models
{
    public class Commande
    {
        [Key]
        public int IdCommande { get; set; }

        [Required]
        public int IdStockProduit { get; set; }

        [Required]
        public int IdClient { get; set; }

        [ForeignKey("IdStockProduit")]
        public StockProduit StockProduit { get; set; }
        [ForeignKey("IdClient")]
        public Client Client { get; set; }
    }
}