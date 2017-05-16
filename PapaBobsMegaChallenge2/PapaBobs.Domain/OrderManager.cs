using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class OrderManager
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            // Validation
            if (orderDTO.Name.Trim().Length == 0)
                throw new Exception("Name is required.");
            if (orderDTO.Address.Trim().Length == 0)
                throw new Exception("Address is required.");
            if (orderDTO.Phone.Trim().Length == 0)
                throw new Exception("Phone is required.");
            if (orderDTO.Zip.Trim().Length == 0)
                throw new Exception("Zip is required.");

            Persistence.OrderRepository.CreateOrder(orderDTO);
        }
    }
}
