using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiGestionStock.Models
{
    public class Produits
    {
        [Key]
        [Column(Order = 2)]
        public int IdProduit { get; set; }

        [Required, MaxLength(80) ]
        public string Libelle { get; set; }

        [Required]
        [Key]
        [Column(Order = 1)]
        public string CodeBar { get; set; }

        [Required]
        public int Quantite { get; set; }

        [Required]
        public DateTime DateAjout { get; set; }

        [Required]
        public DateTime DatePeremption { get;set; }

        [InverseProperty("Produit")]

        public ICollection<StockProduit> StockProduits { get; set; }
    }
}