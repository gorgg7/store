using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.contracts
{
    public interface idbinitializer
    {
        public Task Initialize();
        public Task Initializeidentity();

    }
}
