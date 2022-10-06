using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext db) : base(db) { }

        public Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return Db.Enderecos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.FornecedorId == fornecedorId);
        }
    }
}
