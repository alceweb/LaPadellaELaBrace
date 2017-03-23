using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LaPadellaELaBeaceMVC.Models
{
    public class FormInfoViewModel
    {
        [Required, Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required, Display(Name = "Cognome")]
        public string Cognome { get; set; }
        [Required, Display(Name = "Tel/cell")]
        public string Telefono { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Messaggio { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "Devi accettare il documento della privacy.")]
        [Display(Name = "Privacy")]
        public bool Privacy { get; set; }
    }
}