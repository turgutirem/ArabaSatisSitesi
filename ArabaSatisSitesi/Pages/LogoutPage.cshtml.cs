using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArabaSatisSitesi.Pages
{
    public class LogoutPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Kullanýcý oturumunu sonlandýr
            HttpContext.Session.Clear(); // Session'ý temizle
            HttpContext.SignOutAsync(); // Oturumu sonlandýr
            HttpContext.Response.Cookies.Delete(".AspNetCore.Session"); // Session çerezini sil

            // Forms Authentication ile oturumu sonlandýr (kullandýðýnýza baðlý olarak)
            // FormsAuthentication.SignOut();

            return RedirectToPage("LoginPage"); // Kullanýcýyý giriþ sayfasýna yönlendir
        }
    }
}
