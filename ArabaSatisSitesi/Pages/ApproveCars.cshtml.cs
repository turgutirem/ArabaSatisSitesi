using ArabaSatisSitesi.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ArabaSatisSitesi.Pages
{
    public class ApproveCarsModel : PageModel
    {

        public IActionResult OnGet(int? carid)
        {
            if (!carid.HasValue || carid <= 0)
            {
                return NotFound(); // Geçersiz bir ID varsa 404 hata sayfasýna yönlendirin veya baþka bir iþlem yapýn
            }
            // Seçilen aracýn onayýný yap
            SqlCommand commandApprove = new SqlCommand("UPDATE TableCar SET CarConfirmation = @pcon WHERE CarID = @pid", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();

            commandApprove.Parameters.AddWithValue("@pcon", true);
            commandApprove.Parameters.AddWithValue("@pid", carid);
            var rowsAffected = commandApprove.ExecuteNonQuery();

            if (rowsAffected == 0)
            {
                return NotFound(); // Silme iþlemi baþarýsýz olduysa 404 hata sayfasýna yönlendirin veya baþka bir iþlem yapýn
            }
        

            // Onay iþlemi tamamlandýktan sonra baþka bir sayfaya yönlendirme yapabilirsiniz
            return RedirectToPage("AdminAddCars"); // Yönlendireceðiniz sayfanýn yolunu buraya ekleyin
        }
    }
}
