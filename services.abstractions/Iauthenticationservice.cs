using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shared.identitydtos;

namespace services.abstractions
{
    public interface Iauthenticationservice
    {
        Task<userresultdto> login(logindto userlogindto);
        Task<userresultdto> register(registerdto userregisterdto);
    }
}
