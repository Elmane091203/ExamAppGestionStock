using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiGestionStock.Models
{
    public class StockProduit
    {
        [Key]
        public int IdStockProduit { get; set; }

        public string CodeBar { get; set; }
        public int IdProduit { get; set; }

        [Required]
        public int QteDispo { get; set; }

        [Required]
        public int QteVendu { get; set; }

        [Required]
        public int MontantVente { get; set; }

        [Required]
        public DateTime DatePeremption { get; set; }

        [ForeignKey("CodeBar,IdProduit")]
        public Produits Produit { get; set; }

        [InverseProperty("StockProduit")]

        public ICollection<Commande> Commandes { get; set; }
    }
}