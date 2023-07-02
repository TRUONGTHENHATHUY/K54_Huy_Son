using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Security.Claims;

namespace eShop.Web.Controls
{
    public class AuthenticationController: Controller
    {
        Account_DAL Acc = new Account_DAL();
        public static string users;
        DataTable dt;
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery]string user, [FromQuery]string pwd)
        {
            dt = new DataTable();
            dt = Acc.Select();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                if (user == dt.Rows[i][0].ToString() && pwd == dt.Rows[i][1].ToString())
                {
                    users = user;
                    var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user),
                    new Claim(ClaimTypes.Email, "admin@eshop.com"),
                    new Claim(ClaimTypes.HomePhone, "12345678")
                };

                    var userIdentity = new ClaimsIdentity(userClaims, "eShop.CookieAuth");
                    var userPrincipal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync("eShop.CookieAuth", userPrincipal);
                } 
            }
                return Redirect("/home");
            
        }
        [Route("/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/admin");
        }
    }
}
