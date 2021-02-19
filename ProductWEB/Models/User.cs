using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWEB.Models
{
    public class User
    {
        [Required(ErrorMessage = "El correo es requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraeña es requerida")]
        public string Password { get; set; }
        public List<Errors> Errors { get; set; }
    }
}
