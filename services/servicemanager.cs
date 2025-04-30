using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using domain.contracts;
using services.abstractions;

namespace services
{
    public class servicemanager: Iservicemanagment
    {
        private Lazy<iproductservice> _productservice;
        private Lazy<ibasketservice> _basketservice;
        private Lazy<Iauthenticationservice> _authenticationservice;

        public servicemanager(Iunitofwork unitofwork,IMapper mapper,ibasketrepo ibasketrepo,UserManager<user> usermanager )
        {
            _productservice = new Lazy<iproductservice>(() => new productservice(unitofwork,mapper));
            _basketservice = new Lazy<ibasketservice>(() => new basketservice(ibasketrepo,mapper));
            _authenticationservice = new Lazy<Iauthenticationservice>(() => new authenticationservice(usermanager, mapper));
        }
        public iproductservice iproductservice => _productservice.Value;
        public ibasketservice ibasketservice => _basketservice.Value;

        public Iauthenticationservice iauthenticationservice => _authenticationservice.Value;
    }
}
