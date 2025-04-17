using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;

namespace domain.contracts
{
    public interface Iunitofwork
    {
        public Task<int> savechangeasync();
        igenericrepo<Tentity, Tkey> GetRepository<Tentity, Tkey>() where Tentity : baseentity<Tkey>;
    }
}
