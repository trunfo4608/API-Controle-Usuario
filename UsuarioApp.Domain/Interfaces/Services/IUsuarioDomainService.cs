using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;

namespace UsuarioApp.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        Usuario Autentificar(string email, string senha);
        void CriarConta(Usuario usuario);
    }
}
