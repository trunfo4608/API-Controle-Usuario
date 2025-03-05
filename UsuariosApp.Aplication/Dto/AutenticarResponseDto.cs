using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Aplication.Dto
{
    public class AutenticarResponseDto
    {
        public int Id { get; set;}
        public string? Nome { get; set;}
        public string? Senha { get; set; }
        public string? Email { get; set;}
        public DateTime? DataHoraAcesso { get; set;}
        public string? AccessToken { get; set;}
        public DateTime? DataHoraExpiracao { get; set; }

    }
}
