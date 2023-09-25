using ArabaSatisSitesi.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;

namespace ArabaSatisSitesi.Pages
{
    public class LoginPageModel : PageModel
    {

        [BindProperty]
        public string tboxMail { get; set; }

        [BindProperty]
        public string tboxPassword { get; set; }

        public void OnGet()
        {
            // Sayfa yüklendiðinde yapýlacak iþlemleri burada gerçekleþtirebilirsiniz (eðer gerekiyorsa).
        }

        public IActionResult OnPost()
        {
            SqlCommand commandLogin = new SqlCommand("Select * from TableUser where UserMail=@pmail and UserPassword=@ppass", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();

            string shaPass = SHA256Converter.ComputeSha256Hash(tboxPassword);

            commandLogin.Parameters.AddWithValue("@pmail", tboxMail);
            commandLogin.Parameters.AddWithValue("@ppass", shaPass);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(commandLogin);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                if (tboxMail == "iremt.151@gmail.com")
                {
                 //   HttpContext.Session.SetString("IsUserAdmin", "true");
                //    HttpContext.Session.SetString("UserMail", "iremt.151@gmail.com");
                    return RedirectToPage("AdminDeneme");
                }
                else
                {
                    HttpContext.Session.SetString("IsUserOnline", "true");
                    HttpContext.Session.SetString("UserMail", dt.Rows[0].ToString());
                    return RedirectToPage("ListCars");
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Mail adresi veya þifre hatalý";
                return Page();
            }
        }
    }
}
