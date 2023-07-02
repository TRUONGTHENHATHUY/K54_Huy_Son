using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace eShop.Web.Controls
{
    public class ProductExcute : Controller
    {
        Product_DAL product = new Product_DAL();
        
        [Route("/productinsert")]
        public async Task<IActionResult> Insert([FromQuery] int Productid, [FromQuery] string Name, [FromQuery] double Price,
            [FromQuery] string ImageLink, [FromQuery] string Description, [FromQuery] int Rating, [FromQuery] string Date, [FromQuery] string Tier)
        {
            product.Insert(Productid, Name, Price, ImageLink, Description, Rating, Date, Tier);
            var userClaims = new List<Claim>()
                {
                };

            var userIdentity = new ClaimsIdentity(userClaims, "eShop.CookieAuth");
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync("eShop.CookieAuth", userPrincipal);
            return  Redirect("/productrequire");
        }
        [Route("/productupdate")]
        public async Task<IActionResult> Update([FromQuery] int Productid, [FromQuery] string Name, [FromQuery] double Price,
            [FromQuery] string ImageLink, [FromQuery] string Description, [FromQuery] int Rating, [FromQuery] string Date, [FromQuery] string Tier)
        {
            product.Update(Productid, Name, Price, ImageLink, Description, Rating, Date, Tier);
            var userClaims = new List<Claim>()
            {
            };

            var userIdentity = new ClaimsIdentity(userClaims, "eShop.CookieAuth");
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync("eShop.CookieAuth", userPrincipal);
            return Redirect("/productrequire");
        }
        [Route("/productdelete")]
        public async Task<IActionResult> Delete ([FromQuery] int Productid)
        {
            product.Delete(Productid);
            var userClaims = new List<Claim>()
            {
            };

            var userIdentity = new ClaimsIdentity(userClaims, "eShop.CookieAuth");
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync("eShop.CookieAuth", userPrincipal);
            return Redirect("/productrequire");
        }
    }
}
