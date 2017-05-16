using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapaBobs.DTO.Enums;

namespace PapaBobs.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            var order = new DTO.OrderDTO();
            order.Size = determineSize();
            order.Crust = determineCrust();
            order.PaymentType = determinePaymentType();
            order.Sausage = sausageCheckBox.Checked;
            order.Pepperoni = pepperoniCheckBox.Checked;
            order.Onions = onionsCheckBox.Checked;
            order.GreenPeppers = greenPeppersCheckBox.Checked;
            order.Name = nameTextBox.Text.Trim();
            order.Address = addressTextBox.Text.Trim();
            order.Zip = zipTextBox.Text.Trim();
            order.Phone = phoneTextBox.Text.Trim();
            order.Complete = false;       
        }

        private SizeType determineSize()
        {
            DTO.Enums.SizeType size;
            if (!Enum.TryParse(sizeDropDownList.SelectedValue, out size))
            {
                //throw new Exception("Size not selected.");
            }
            return size;
        }

        private CrustType determineCrust()
        {
            DTO.Enums.CrustType crust;
            if (!Enum.TryParse(crustDropDownList.SelectedValue, out crust))
            {
                //throw new Exception("Crust not selected.");
            }
            return crust;
        }

        private PaymentType determinePaymentType()
        {
            if (cashRadioButton.Checked)
                return DTO.Enums.PaymentType.Cash;
            else return DTO.Enums.PaymentType.Credit;
        }

        protected void recalculateTotalCost(Object sender, EventArgs e)
        {
            if (sizeDropDownList.SelectedValue == String.Empty)
                return;
            if (crustDropDownList.SelectedValue == String.Empty)
                return;

            var order = buildOrder();
            totalLabel.Text = order.TotalCost.ToString("C");
        }

        private DTO.OrderDTO buildOrder()
        {
            var order = new DTO.OrderDTO();
            order.Size = determineSize();
            order.Crust = determineCrust();
            order.PaymentType = determinePaymentType();
            order.Sausage = sausageCheckBox.Checked;
            order.Pepperoni = pepperoniCheckBox.Checked;
            order.Onions = onionsCheckBox.Checked;
            order.GreenPeppers = greenPeppersCheckBox.Checked;
            order.Name = nameTextBox.Text.Trim();
            order.Address = addressTextBox.Text.Trim();
            order.Zip = zipTextBox.Text.Trim();
            order.Phone = phoneTextBox.Text.Trim();
            order.Complete = false;

            return order;
        }
    }
}