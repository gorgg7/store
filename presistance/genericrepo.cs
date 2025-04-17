using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.contracts;
using domain.entites;
using Microsoft.EntityFrameworkCore;
using presistance.data;

namespace presistance.repos
{
    public class genericrepo<Tentity, Tkey> : igenericrepo<Tentity, Tkey> where Tentity : baseentity<Tkey>
    {
        private readonly storedbcontext _context;
        private Type context;

        public genericrepo(storedbcontext context)
        {
            _context = context;
        }

        public genericrepo(Type context)
        {
            this.context = context;
        }

        public async Task AddAsync(Tentity entity)
       => await _context.Set<Tentity>().AddAsync(entity);

        public void delete(Tentity entity)
        => _context.Set<Tentity>().Remove(entity);

        public async Task<IEnumerable<Tentity>> GetAllAsync(bool isTracking = false)
        {
            if (isTracking)
                return await _context.Set<Tentity>().ToListAsync();
            return await _context.Set<Tentity>().AsNoTracking().ToListAsync();


        }

        public async Task<Tentity?> GetByIdAsync(Tkey id)
        => await _context.Set<Tentity>().FindAsync(id);

        public void update(Tentity entity)
        => _context.Set<Tentity>().Update(entity);
    }
}