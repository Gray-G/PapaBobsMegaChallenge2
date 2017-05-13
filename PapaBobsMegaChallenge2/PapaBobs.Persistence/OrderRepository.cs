using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Persistence
{
    public class OrderRepository
    {
        public static void CreateOrder()
        {
            var db = new PapaBobsDbEntities();
            var order = convertToEntity();
            db.Orders.Add(order);
            db.SaveChanges();
        }

        private static Order convertToEntity()
        {
            var order = new Order();
            order.OrderId = Guid.NewGuid();
            order.Size = DTO.Enums.SizeType.Large;
            order.Crust = DTO.Enums.CrustType.Regular;
            order.Name = "Test";
            order.Address = "Test Address";
            order.Phone = "Test Phone";
            order.Zip = "Test zip";
            order.PaymentType = DTO.Enums.PaymentType.Cash;
            order.Complete = false;

            return order;
        }
    }
}
