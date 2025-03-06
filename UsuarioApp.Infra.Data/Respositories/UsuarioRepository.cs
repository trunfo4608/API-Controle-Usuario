using Microsoft.EntityFrameworkCore;
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
        public virtual async Task<Usuario> Find(string email)
        {
            using(var dataContext = new DataContext())
            {
                return await dataContext.Usuarios
                        .FirstOrDefaultAsync(u => u.Email.Equals(email));
            }
        }

        public virtual async Task<Usuario> Find(string email, string senha)
        {
            using(var dataContext = new DataContext())
            {
                return await dataContext.Usuarios
                        .FirstOrDefaultAsync(u => u.Email.Equals(email)
                                        && 
                                        u.Senha.Equals(senha));
            }
        }
    }
}
