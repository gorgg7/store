using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using domain.contracts;
using domain.orderentities;
using services.abstractions;
using shared.orderdto;
using orderitem = domain.orderentities.orderitem;

namespace services
{
    public class orderservice(Iunitofwork iunitofwork, IMapper mapper, ibasketrepo ibasketrepo) : iorderservice
    {
        public async Task<orderresult> CreateOrder(orderrequest orderrequest)
        {
            var address = mapper.Map<addressdto>(orderrequest.shippingaddres);
            var basket = await ibasketrepo.getbasketasync(orderrequest.basketid);
            if (basket == null)
            {
                throw new ArgumentException(orderrequest.basketid);
            }
            var orderitem = new List<orderitem>();
            foreach (var item in basket.items)
            {
                var product = await iunitofwork.GetRepository<domain.entites.product, int>().GetByIdAsync(item.id);
                if (product == null)
                {
                    throw new ArgumentException(item.id.ToString());
                }
                var productinorderitem = new productinoerderitem(product.Id, product.Name, product.PictureUrl);
                var orderitemm = new orderitem(productinorderitem, item.Quantity, item.Price);
                orderitem.Add(orderitemm);
            }

            var deliverymethodRepo = iunitofwork.GetRepository<delivery, int>();
            var deliverymethod = await deliverymethodRepo.GetByIdAsync(orderrequest.deleverymethodid);
            if (deliverymethod == null)
            {
                throw new ArgumentException(orderrequest.deleverymethodid.ToString());
            }
            var subtotal = orderitem.Sum(x => x.price * x.quantity);
            var order=new orderentity
            {
                buyeremail = orderrequest.buyeremail,
                orderitems = orderitem,
                deliverymethod = deliverymethod,
                subtotal = subtotal
            };
            await iunitofwork.GetRepository<orderentity, Guid>().AddAsync(order);
            await iunitofwork.savechangeasync();
            return mapper.Map<orderresult>(order);
        }

        public Task<IEnumerable<deliverymethod>> GetDeliverymethods()
        {
            throw new NotImplementedException();
        }

        public Task<orderresult> GetOrderresult(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<orderresult>> GetOrdersByBuyerEmail(string buyeremail)
        {
            throw new NotImplementedException();
        }
    }
}
