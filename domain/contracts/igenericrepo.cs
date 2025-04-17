using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;

namespace domain.contracts
{
    public interface igenericrepo<Tentity,Tkey> where Tentity : baseentity<Tkey>
    {
        Task<Tentity?> GetByIdAsync(Tkey id);
        Task<IEnumerable<Tentity>> GetAllAsync(bool isTracking=false );
        Task AddAsync(Tentity entity);
        void update(Tentity entity);
        void delete(Tentity entity);
    }
    
}
