using System.Data;

namespace eShop.Web.Controls
{
    public class Account_DAL
    {
        DataAccess DAC = new DataAccess();

        public DataTable Select()
        {
            return DAC.LayDuLieu("TimkiemAccount");
        }
    }
}
