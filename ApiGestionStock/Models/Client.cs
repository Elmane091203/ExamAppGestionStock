using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiGestionStock.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [Required, MaxLength(50)]
        public string NomClient { get; set; }

        [Required, MaxLength(80)]
        public string PreomClient { get; set; }

        [Required, MaxLength(20)]
        public string TelephoneClient { get; set; }

        [Required, MaxLength(50)]
        public string AdresseClient { get; set; }

        [Required, MaxLength(50)]
        [Index(IsUnique = true)]
        public string LoginClient { get; set; }

        [Required, MaxLength(255)]
        public string MotDePasseClient { get; set; }

        [Required, MaxLength(20)]
        public string Role { get; set; }

        [InverseProperty("Client")]

        public ICollection<Commande> Commandes { get; set; }

    }
}