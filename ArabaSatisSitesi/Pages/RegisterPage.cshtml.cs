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
        [EmailAddress(ErrorMessage = "Ge�erli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "�ifre gereklidir.")]
        public string Password { get; set; }

        public void OnGet()
        {
            // Sayfa y�klendi�inde yap�lacak i�lemler
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // �ifreyi SHA-256 ile �zetle
            string hashedPassword = SHA256Converter.ComputeSha256Hash(Password);

            SqlCommand commandRegister = new SqlCommand("Insert into TableUser (UserMail, UserPassword) values (@pmail, @ppass)", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();

            commandRegister.Parameters.AddWithValue("@pmail", Email);
            commandRegister.Parameters.AddWithValue("@ppass", hashedPassword);

            commandRegister.ExecuteNonQuery();

            // Kay�t ba�ar�yla tamamland�ysa, ba�ka bir sayfaya y�nlendirin
            return RedirectToPage("LoginPage"); // 'BaskaSayfa' burada hedef sayfa ad�n�z� temsil etmelidir.
        }
    }
}
