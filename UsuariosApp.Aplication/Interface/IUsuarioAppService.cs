using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Aplication.Dto;

namespace UsuariosApp.Aplication.Interface
{
    public interface IUsuarioAppService
    {
        AutenticarResponseDto Autentificar(AutenticarRequestDto dto);
        CriarContaResponseDto CriarConta(CriarContaRequestDto dto);
    }
}
