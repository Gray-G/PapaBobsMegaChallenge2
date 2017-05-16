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
            Persistence.OrderRepository.CreateOrder(orderDTO);
            orderDTO.TotalCost = Domain.PizzaPriceManager.CalculateCost(orderDTO);
        }
    }
}
