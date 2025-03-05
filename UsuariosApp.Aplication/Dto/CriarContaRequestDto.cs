using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Aplication.Dto
{
    public class CriarContaRequestDto
    {

        [StringLength(100,MinimumLength =8,ErrorMessage ="Campo entre {2} e {1} caracteres.")]
        [Required(ErrorMessage ="Campo nome obrigatório.")]
        public string? Nome { get;set;}

        [Required(ErrorMessage ="Campo email obrigatório.")]
        [EmailAddress(ErrorMessage ="Informe um email obrigatório.")]
        public string? Email { get; set;}

        [Required(ErrorMessage ="Campo senha obrigatório.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=]).{8,}$",
            ErrorMessage ="Informe senha com letras maiúscula, minúscula e simbolos com 8 caracteres.")]
        public string? Senha { get; set;}

        [Compare("Senha", ErrorMessage ="Senhas não conferem.")]
        [Required(ErrorMessage ="Campo obrigatório.")]
        public string? SenhaConfirmacao { get; set;}

    }
}
