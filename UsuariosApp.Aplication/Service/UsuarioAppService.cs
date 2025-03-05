using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;
using UsuarioApp.Domain.Interfaces.Services;
using UsuariosApp.Aplication.Dto;
using UsuariosApp.Aplication.Interface;

namespace UsuariosApp.Aplication.Service
{
    public class UsuarioAppService : IUsuarioAppService
    {

        private readonly IUsuarioDomainService? _usuarioDomainService;

        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        public AutenticarResponseDto Autentificar(AutenticarRequestDto dto)
        {
            var usuario = _usuarioDomainService?.Autentificar(dto.Email, dto.Senha);

            return new AutenticarResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAcesso = DateTime.Now,
                DataHoraExpiracao = DateTime.Now,
                AccessToken = usuario.AcessToken
            };

        }

        public CriarContaResponseDto CriarConta(CriarContaRequestDto dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };

            _usuarioDomainService?.CriarConta(usuario);

            return new CriarContaResponseDto
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCadastro = DateTime.Now
            };
        }
    }
}
