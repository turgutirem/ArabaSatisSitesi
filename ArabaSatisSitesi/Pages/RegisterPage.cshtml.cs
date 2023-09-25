using ArabaSatisSitesi.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ArabaSatisSitesi.Pages
{

    public class RegisterPageModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Þifre gereklidir.")]
        public string Password { get; set; }

        public void OnGet()
        {
            // Sayfa yüklendiðinde yapýlacak iþlemler
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Þifreyi SHA-256 ile özetle
            string hashedPassword = SHA256Converter.ComputeSha256Hash(Password);

            SqlCommand commandRegister = new SqlCommand("Insert into TableUser (UserMail, UserPassword) values (@pmail, @ppass)", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();

            commandRegister.Parameters.AddWithValue("@pmail", Email);
            commandRegister.Parameters.AddWithValue("@ppass", hashedPassword);

            commandRegister.ExecuteNonQuery();

            // Kayýt baþarýyla tamamlandýysa, baþka bir sayfaya yönlendirin
            return RedirectToPage("LoginPage"); // 'BaskaSayfa' burada hedef sayfa adýnýzý temsil etmelidir.
        }
    }
}
