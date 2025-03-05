using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Aplication.Dto
{
    public class AutenticarRequestDto
    {
        [EmailAddress(ErrorMessage ="Informe um email válido.")]
        [Required(ErrorMessage ="Campo email obrigatório.")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Campo senha obrigatório.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=]).{8,}$"
         ,ErrorMessage ="Informe senha pra usuário." )]
        public string? Senha { get; set; }
    }
}
