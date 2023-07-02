using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.CoreBusiness.Models;
using eShop.CoreBusiness.Services.Interfaces;

namespace eShop.CoreBusiness.Services
{
    public class OrderService : IOrderService
    {
        public bool ValidateCustomerInformation(string name, string accountname, string accountid, string phone)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(accountname) ||
                string.IsNullOrWhiteSpace(accountid) ||
                string.IsNullOrWhiteSpace(phone)
                ) return false;

            return true;
        }
        public bool ValidateCreateOrder(Order order)
        {
            //Phai ton tai 1 order
            if (order == null) return false;

            //order it nhat phai co line items
            if (order.LineItems == null || order.LineItems.Count <= 0) return false;

            //validate line items
            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 ||
                    item.Price < 0 ||
                    item.Quantity <= 0) return false;
            }

            //validate customer info
            if (!ValidateCustomerInformation(order.CustomerName,
                order.AccountGameName,
                order.AccountGameId,
                order.Phone
                )) return false;

            return true;
        }

        public bool ValidateUpdateOrder(Order order)
        {
            if (order == null) return false;
            if (!order.OrderId.HasValue) return false;

            //order it nhat phai co line items
            if (order.LineItems == null || order.LineItems.Count <= 0) return false;

            //Placed Date has to be populated
            if (!order.DatePlaced.HasValue) return false;

            //Other dates
            if (order.DateProcessed.HasValue || order.DateProcessing.HasValue) return false;

            //validate uniqueId
            if (string.IsNullOrWhiteSpace(order.UniqueId)) return false;

            //validate line items
            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 ||
                    item.Price < 0 ||
                    item.Quantity <= 0) return false;
            }

            //validate customer info
            if (!ValidateCustomerInformation(order.CustomerName,
                order.AccountGameName,
                order.AccountGameId,
                order.Phone)) return false;

            return false;
        }

        public bool ValidateProcessOrder(Order order)
        {
            if (!order.DateProcessed.HasValue ||
                string.IsNullOrWhiteSpace(order.AdminUser)) return false;

            return true;
        }
    }
}
