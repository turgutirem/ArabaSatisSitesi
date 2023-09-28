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
                return NotFound(); // Ge�ersiz bir ID varsa 404 hata sayfas�na y�nlendirin veya ba�ka bir i�lem yap�n
            }
            // Se�ilen arac�n onay�n� yap
            SqlCommand commandApprove = new SqlCommand("UPDATE TableCar SET CarConfirmation = @pcon WHERE CarID = @pid", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();

            commandApprove.Parameters.AddWithValue("@pcon", true);
            commandApprove.Parameters.AddWithValue("@pid", carid);
            var rowsAffected = commandApprove.ExecuteNonQuery();

            if (rowsAffected == 0)
            {
                return NotFound(); // Silme i�lemi ba�ar�s�z olduysa 404 hata sayfas�na y�nlendirin veya ba�ka bir i�lem yap�n
            }
        

            // Onay i�lemi tamamland�ktan sonra ba�ka bir sayfaya y�nlendirme yapabilirsiniz
            return RedirectToPage("AdminAddCars"); // Y�nlendirece�iniz sayfan�n yolunu buraya ekleyin
        }
    }
}
