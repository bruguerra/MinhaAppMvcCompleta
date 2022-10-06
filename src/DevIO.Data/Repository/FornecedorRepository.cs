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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores
                           .AsNoTracking() // para melhor desempenho
                           .Include(x => x.Endereco) // para fazer join com endereço
                           .FirstOrDefaultAsync(); // para pegar primeiro ou unico que tiver
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores
                           .AsNoTracking() // para melhor desempenho
                           .Include(x => x.Produtos) // para fazer join com produtos
                           .Include(x => x.Endereco) // para fazer join com endereço
                           .FirstOrDefaultAsync(x => x.Id == id); // para retornar o primeiro ou unico que tiver
        }
    }
}
