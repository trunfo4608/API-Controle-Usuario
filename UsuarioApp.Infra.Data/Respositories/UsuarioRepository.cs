using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Infra.Data.Data;

namespace UsuarioApp.Infra.Data.Respositories
{
    public class UsuarioRepository : BaseRespository<Usuario>, IUsuarioRepository
    {
        public Usuario Find(string email)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Usuarios
                        .FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public Usuario Find(string email, string senha)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Usuarios
                        .FirstOrDefault(u => u.Email.Equals(email)
                                        && 
                                        u.Senha.Equals(senha));
            }
        }
    }
}
