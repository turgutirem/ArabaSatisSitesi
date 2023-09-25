using ArabaSatisSitesi.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ArabaSatisSitesi.Pages
{
    public class ContactPageModel : PageModel
    {
        [BindProperty]
        public string tboxName { get; set; }

        [BindProperty]
        public string tboxMail { get; set; }

        [BindProperty]
        public string tboxMessage { get; set; }

        public void OnGet()
        {
            // Sayfa yüklenirken yapýlacak iþlemleri buraya ekleyebilirsiniz.
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SqlCommand commandAdd = new SqlCommand("Insert into TableContact (ContactMessage, ContactMail, ContactName) values (@pmsg, @pmail, @pname)", SqlConnectionClass.connection);

            SqlConnectionClass.CheckConnection();

            commandAdd.Parameters.AddWithValue("@pmsg", tboxMessage);
            commandAdd.Parameters.AddWithValue("@pmail", tboxMail);
            commandAdd.Parameters.AddWithValue("@pname", tboxName);

            commandAdd.ExecuteNonQuery();

            // Ekleme iþlemi baþarýyla tamamlandýysa baþka bir sayfaya yönlendirebilirsiniz.
            return RedirectToPage("ContactPage");
        }
    }
}
