using Microsoft.EntityFrameworkCore;
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
    public class ProdutoRepository : IProdutoRepository
    {
        public void Add(Produto produto)
        {
            using(var dataContext=new DataContext())
            {
                dataContext.Add(produto);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Produto produto)
        {
            using(var dataContext=new DataContext())
            {
                dataContext.Remove(produto);
                dataContext.SaveChanges();
            }
        }

        public List<Produto>? GetAll()
        {
            using(var dataContext=new DataContext())
            {
                return dataContext.Set<Produto>().ToList();
            }
        }

        public Produto? GetById(Guid id)
        {
            using(var dataContext=new DataContext())
            {
                return dataContext.Set<Produto>().FirstOrDefault();
            }
        }

        public Produto? GetByNome(string nome)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Produto>().Where(p => p.Nome == nome).FirstOrDefault();
            }
        }

        public void Update(Produto produto)
        {
            using(var dataContext=new DataContext())
            {
                dataContext.Update(produto);
                dataContext.SaveChanges();  
            }
        }
    }
}
