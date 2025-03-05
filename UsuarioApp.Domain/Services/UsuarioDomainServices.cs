using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;
using UsuarioApp.Domain.Helpers;
using UsuarioApp.Domain.Interfaces;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Domain.Interfaces.Services;

namespace UsuarioApp.Domain.Services
{
    public class UsuarioDomainServices : IUsuarioDomainService
    {
        private readonly IUsuarioRepository? _usuarioRepository;
        private readonly IHistoricoAtividadeRepository? _historicoAtividadeRepository;
        private readonly ITokenSecurity? _tokenSecurity;

        public UsuarioDomainServices(IUsuarioRepository? usuarioRepository, IHistoricoAtividadeRepository? historicoAtividadeRepository, ITokenSecurity? tokenSecurity)
        {
            _usuarioRepository = usuarioRepository;
            _historicoAtividadeRepository = historicoAtividadeRepository;
            _tokenSecurity = tokenSecurity;
        }

        public Usuario Autentificar(string email, string senha)
        {
            var usuario = _usuarioRepository?.Find(email, SHA1Helpers.Encrypt(senha));

            if (usuario == null)
            {
                throw new ApplicationException("Usuario não encontrado");
            }

            usuario.AcessToken = _tokenSecurity?.CreateToken(usuario);

            var historicoAtividade = new HistoricoAtividade
            {
                DataHora = DateTime.Now,
                Descricao = $"Autentificação usuário: {usuario.Nome}, email {usuario.Email}",
                UsuarioId = usuario.Id
            };

            _historicoAtividadeRepository?.Add(historicoAtividade);

            return usuario;
        }

        public void CriarConta(Usuario usuario)
        {
            if (_usuarioRepository?.Find(SHA1Helpers.Encrypt(usuario.Email)) != null)
                throw new ApplicationException("Email cadastrado, tente outro.");


            usuario.Senha = SHA1Helpers.Encrypt(usuario.Senha);

            _usuarioRepository?.Add(usuario);

            var historicoAtividade = new HistoricoAtividade
            {
                DataHora = DateTime.Now,
                Descricao = $"Cadastro usuário {usuario.Nome}, email {usuario.Email}",
                UsuarioId = usuario.Id
            };

            _historicoAtividadeRepository?.Add(historicoAtividade);
        }
    }
}
