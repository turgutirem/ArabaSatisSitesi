using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArabaSatisSitesi.Pages
{
    public class AdminDenemeModel : PageModel
    {
        public void OnGet()
        {
            string isAdminString = HttpContext.Session.GetString("IsUserAdmin");
            if (!string.IsNullOrEmpty(isAdminString) && isAdminString.ToLower() == "true")
            {
                // Kullan�c� y�netici ise buraya girecek kodlar� ekleyin
            }
        }

    }
}
