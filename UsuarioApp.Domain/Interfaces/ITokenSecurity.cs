using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;

namespace UsuarioApp.Domain.Interfaces
{
    public interface ITokenSecurity
    {
        string CreateToken(Usuario usuario);
    }
}
