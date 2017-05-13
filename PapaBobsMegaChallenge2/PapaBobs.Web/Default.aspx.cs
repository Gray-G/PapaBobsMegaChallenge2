using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobs.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var order = new DTO.OrderDTO();

            order.OrderId = Guid.NewGuid();
            order.Size = DTO.Enums.SizeType.Large;
            order.Crust = DTO.Enums.CrustType.Regular;
            order.Sausage = true;
            order.Pepperoni = false;
            order.GreenPeppers = false;
            order.Onions = false;
            order.TotalCost = 14.50M;
            order.Name = "Test";
            order.Address = "Test";
            order.Phone = "1322133";
            order.Zip = "12334";
            order.PaymentType = DTO.Enums.PaymentType.Cash;
            order.Complete = false;

            Domain.OrderManager.CreateOrder(order);
        }
    }
}