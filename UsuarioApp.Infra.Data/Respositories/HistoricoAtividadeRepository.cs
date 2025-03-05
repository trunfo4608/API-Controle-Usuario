using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;
using UsuarioApp.Domain.Interfaces.Repositories;

namespace UsuarioApp.Infra.Data.Respositories
{
    public class HistoricoAtividadeRepository : BaseRespository<HistoricoAtividade>,IHistoricoAtividadeRepository
    {
        
    }
}
