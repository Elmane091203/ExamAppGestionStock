using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiGestionStock.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAdmin { get; set; }

        [Index(IsUnique = true)]
        [Required, MaxLength(50)]
        public string LoginAdmin { get; set; }

        [Required, MaxLength(255)]
        public string MotDePasse { get; set; }

        [Required, MaxLength(30)]
        public string Role { get; set;}
    }
}