﻿using System;
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
            if (nameTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter a name.";
                validationLabel.Visible = true;
                return;
            }
            if (addressTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter an address.";
                validationLabel.Visible = true;
                return;
            }
            if (zipTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter a zip code.";
                validationLabel.Visible = true;
                return;
            }
            if (phoneTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter a phone number.";
                validationLabel.Visible = true;
                return;
            }

            try
            {
                var order = buildOrder();
                Domain.OrderManager.CreateOrder(order);
                Response.Redirect("success.aspx");
            }
            catch (Exception ex)
            {
                validationLabel.Text = ex.Message;
                validationLabel.Visible = true;
                return;
            }
        }

        private SizeType determineSize()
        {
            DTO.Enums.SizeType size;
            if (!Enum.TryParse(sizeDropDownList.SelectedValue, out size))
            {
                throw new Exception("You must choose a size.");
            }
            return size;
        }

        private CrustType determineCrust()
        {
            DTO.Enums.CrustType crust;
            if (!Enum.TryParse(crustDropDownList.SelectedValue, out crust))
            {
                throw new Exception("You must choose a crust.");
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
            if (sizeDropDownList.SelectedValue == String.Empty) return;
            if (crustDropDownList.SelectedValue == String.Empty) return;

            var order = buildOrder();

            try
            {
                totalLabel.Text = Domain.PizzaPriceManager.CalculateCost(order).ToString("C");
            }
            catch
            {
                // Swallow exception
            }
        }

        private DTO.OrderDTO buildOrder()
        {
            var order = new DTO.OrderDTO();
            order.Size = determineSize();
            order.Crust = determineCrust();
            order.Sausage = sausageCheckBox.Checked;
            order.Pepperoni = pepperoniCheckBox.Checked;
            order.Onions = onionsCheckBox.Checked;
            order.GreenPeppers = greenPeppersCheckBox.Checked;
            order.Name = nameTextBox.Text.Trim();
            order.Address = addressTextBox.Text.Trim();
            order.Zip = zipTextBox.Text.Trim();
            order.Phone = phoneTextBox.Text.Trim();
            order.PaymentType = determinePaymentType();

            return order;
        }
    }
}