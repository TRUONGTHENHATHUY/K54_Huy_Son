using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Web.CustomerPortal.ViewModels
{
    public class CustomerViewModel
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string AccountGameName { get; set; }

        [Required]
        public string AccountGameId { get; set; }

        [Required]
        public string Phone { get; set; }


    }
}
