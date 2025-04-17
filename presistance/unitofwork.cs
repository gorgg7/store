using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.contracts;
using domain.entites;
using presistance.data;
using presistance.repos;

namespace presistance
{
    public class unitofwork : Iunitofwork
    {
        private readonly storedbcontext _context;
        private ConcurrentDictionary<Type, object> _repositories;
        public unitofwork(storedbcontext context)
        {
            _context = context;
            _repositories = new ();
        }
        public async Task<int> savechangeasync()
        {
            return await _context.SaveChangesAsync();
        }
        public igenericrepo<Tentity, Tkey> GetRepository<Tentity, Tkey>() where Tentity : baseentity<Tkey>
       => (igenericrepo<Tentity, Tkey>)_repositories.GetOrAdd(typeof(Tentity), _ => new genericrepo<Tentity, Tkey>(_context));
    }



}
