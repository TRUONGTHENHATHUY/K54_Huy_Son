using System.Data;
using System.Xml.Linq;
using static MudBlazor.CategoryTypes;

namespace eShop.Web.Controls
{
    public class Product_DAL
    {
        DataAccess DAC = new DataAccess();
        string[] name = { }; //Luu ten cac tham so
        object[] value = { }; //Mang luu gia tri cac tham so
        public int Insert(int Id, string Name, double Price, string ImageLink,string Description, int Rating, string Date, string Tier)
        {
            name = new string[8];
            value = new object[8];
            name[0] = "@productid";
            name[1] = "@name";
            name[2] = "@price";
            name[3] = "@imagelink";
            name[4] = "@description";
            name[5] = "@rating";
            name[6] = "@date";
            name[7] = "@tier";
            value[0] = Id;
            value[1] = Name;
            value[2] = Price;
            value[3] = ImageLink;
            value[5] = Rating;
            value[6] = Date;
            value[7] = Tier;
            value[4] = Description;
            return DAC.Thuchien_HanhDong("InsertProduct", name, value, 8);
        }
        public int Delete(int Id)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@productid";
            value[0] = Id;
            return DAC.Thuchien_HanhDong("DeleteProduct", name, value, 1);
        }
        public int Update(int Id, string Name, double Price, string ImageLink, string Description, int Rating, string Date, string Tier)
        {

            name = new string[8];
            value = new object[8];
            name[0] = "@productid";
            name[1] = "@name";
            name[2] = "@price";
            name[3] = "@imagelink";
            name[4] = "@description";
            name[5] = "@rating";
            name[6] = "@date";
            name[7] = "@tier";
            value[0] = Id;
            value[1] = Name;
            value[2] = Price;
            value[3] = ImageLink;
            value[5] = Rating;
            value[6] = Date;
            value[7] = Tier;
            value[4] = Description;
            return DAC.Thuchien_HanhDong("UpdateProduct", name, value, 8);
            
        }
    }
}
