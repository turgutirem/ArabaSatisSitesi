using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArabaSatisSitesi.Pages
{
    public class LogoutPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Kullan�c� oturumunu sonland�r
            HttpContext.Session.Clear(); // Session'� temizle
            HttpContext.SignOutAsync(); // Oturumu sonland�r
            HttpContext.Response.Cookies.Delete(".AspNetCore.Session"); // Session �erezini sil

            // Forms Authentication ile oturumu sonland�r (kulland���n�za ba�l� olarak)
            // FormsAuthentication.SignOut();

            return RedirectToPage("LoginPage"); // Kullan�c�y� giri� sayfas�na y�nlendir
        }
    }
}
