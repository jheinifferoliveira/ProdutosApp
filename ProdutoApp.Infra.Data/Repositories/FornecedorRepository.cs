using ProdutoApp.Infra.Data.Contexts;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoApp.Infra.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public void Add(Fornecedor fornecedor)
        {
            using(var dataContext=new DataContext())
            {
                dataContext.Add(fornecedor);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Fornecedor fornecedor)
        {
           using(var dataContext=new DataContext())
            {
                dataContext.Remove(fornecedor);
                dataContext.SaveChanges();
            }
        }

        public List<Fornecedor>? GetAll()
        {
            using( var dataContext=new DataContext())
            {
                return dataContext.Set<Fornecedor>().ToList();
            }
        }

        public Fornecedor? GetById(Guid id)
        {
           using(var dataContext=new DataContext())
            {
                return dataContext.Set<Fornecedor>().Where(f=>f.Id == id).FirstOrDefault();
            }
        }

        public Fornecedor GetByNome(string nome)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Fornecedor>().Where(f => f.Nome == nome).FirstOrDefault();
            }
        }

        public void Update(Fornecedor fornecedor)
        {
            using(var dataContext=new DataContext())
            {
                dataContext.Update(fornecedor);
                dataContext.SaveChanges();
            }
        }
    }
}
