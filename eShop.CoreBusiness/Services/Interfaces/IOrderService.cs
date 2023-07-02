using eShop.CoreBusiness.Models;

namespace eShop.CoreBusiness.Services.Interfaces
{
    public interface IOrderService
    {
        bool ValidateCreateOrder(Order order);
        bool ValidateCustomerInformation(string name, string accountname, string accountid, string phone);
        bool ValidateProcessOrder(Order order);
        bool ValidateUpdateOrder(Order order);
    }
}