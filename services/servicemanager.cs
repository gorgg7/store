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
        public servicemanager(Iunitofwork unitofwork,IMapper mapper)
        {
            _productservice = new Lazy<iproductservice>(() => new productservice(unitofwork,mapper));
        }
        public iproductservice iproductservice => _productservice.Value;
    }
}
