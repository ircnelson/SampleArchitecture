using System.Data.Entity;
using System.Linq;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Persistencia.EntityFramework.Context;

namespace SampleArchiteture.Persistencia.EntityFramework.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbContext _context;

        public ClienteRepository()
        {
            _context = new SampleContext();
        }

        public ClienteRepository(DbContext context)
        {
            _context = context;
        }
        
        public Cliente Get(int id)
        {
            return _context.Set<Cliente>().Find(id);
        }

        public IQueryable<Cliente> GetAll()
        {
            return _context.Set<Cliente>();
        }

        public void Add(Cliente entity)
        {
            _context.Set<Cliente>().Add(entity);
        }

        public IQueryable<Cliente> GetAtivos()
        {
            return _context.Set<Cliente>().Where(e => e.Ativo);
        }
    }
}
