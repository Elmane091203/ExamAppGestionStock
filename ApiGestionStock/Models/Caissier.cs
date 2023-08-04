using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiGestionStock.Models
{
    public class Caissier
    {
        [Key]
        public int IdCaissier { get; set; }

        [Required, MaxLength(50)]
        public string NomCaissier { get; set; }

        [Required, MaxLength(80)]
        public string PreomCaissier { get; set; }

        [Required, MaxLength(20)]
        public string TelephoneCaissier { get; set; }

        [Required, MaxLength(50)]
        public string AdresseCaissier { get; set; }

        [Required, MaxLength(50)]
        [Index(IsUnique = true)]
        public string LoginCaissier { get; set; }

        [Required, MaxLength(255)]
        public string MotDePasseCaissier { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool PremierCon { get; set; }

        [Required, MaxLength(20)]
        public string Role { get; set; }

    }
}