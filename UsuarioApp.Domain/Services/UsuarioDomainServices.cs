using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;
using UsuarioApp.Domain.Helpers;
using UsuarioApp.Domain.Interfaces;
using UsuarioApp.Domain.Interfaces.Messages;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Domain.Interfaces.Services;
using UsuarioApp.Domain.Models;

namespace UsuarioApp.Domain.Services
{
    public class UsuarioDomainServices : IUsuarioDomainService
    {
        private readonly IUsuarioRepository? _usuarioRepository;
        private readonly IHistoricoAtividadeRepository? _historicoAtividadeRepository;
        private readonly ITokenSecurity? _tokenSecurity;
        private readonly IEmailMessageProducer? _emailMessageProducer;

        public UsuarioDomainServices(IUsuarioRepository? usuarioRepository, IHistoricoAtividadeRepository? historicoAtividadeRepository, ITokenSecurity? tokenSecurity, IEmailMessageProducer? emailMessageProducer)
        {
            _usuarioRepository = usuarioRepository;
            _historicoAtividadeRepository = historicoAtividadeRepository;
            _tokenSecurity = tokenSecurity;
            _emailMessageProducer = emailMessageProducer;
        }

        public async Task<Usuario> Autentificar(string email, string senha)
        {
            var usuario = await _usuarioRepository?.Find (email, SHA1Helpers.Encrypt(senha));

            if (usuario == null)
            {
                throw new ApplicationException("Usuario não encontrado");
            }

            usuario.AcessToken =  _tokenSecurity?.CreateToken(usuario);

            var historicoAtividade = new HistoricoAtividade
            {
                DataHora = DateTime.Now,
                Descricao = $"Autentificação usuário: {usuario.Nome}, email {usuario.Email}",
                UsuarioId = usuario.Id
            };

            await _historicoAtividadeRepository?.Add(historicoAtividade);

            return usuario;
        }

        public async Task CriarConta(Usuario usuario)
        {
            if (await _usuarioRepository?.Find(SHA1Helpers.Encrypt(usuario.Email)) != null)
                throw new ApplicationException("Email cadastrado, tente outro.");


            usuario.Senha = SHA1Helpers.Encrypt(usuario.Senha);

            await _usuarioRepository?.Add(usuario);

            var historicoAtividade = new HistoricoAtividade
            {
                DataHora = DateTime.Now,
                Descricao = $"Cadastro usuário {usuario.Nome}, email {usuario.Email}",
                UsuarioId = usuario.Id
            };

            await _historicoAtividadeRepository?.Add(historicoAtividade);


            var emailMessage = new EmailMessageModel
            {
                To = usuario.Email,
                Subject = "Conta de usuário criada com sucesso - API Usuários",
                Body = $@"Parabéns {usuario.Nome}, sua conta foi criada com sucesso!
                          
                          Você foi cadastrado em nossa base de dados em {DateTime.Now}
                          Utilize sua conta para acessar os recursos da aplicação.
                          
                          Att, 
                          Renato Vasconcelos.",
                IsHtml = true
            };

            _emailMessageProducer?.Send(emailMessage);
        }
    }
}
