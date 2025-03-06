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
        Task<AutenticarResponseDto> Autentificar(AutenticarRequestDto dto);
        Task<CriarContaResponseDto> CriarConta(CriarContaRequestDto dto);
    }
}
