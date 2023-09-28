using ArabaSatisSitesi.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ArabaSatisSitesi.Pages
{
    public class MessageDeleteModel : PageModel
    {
       

        public IActionResult OnGet(int? id)
        {
          
            if (!id.HasValue || id <= 0)
            {
                return NotFound(); // Ge�ersiz bir ID varsa 404 hata sayfas�na y�nlendirin veya ba�ka bir i�lem yap�n
            }

          
                using (var command = new SqlCommand("DELETE FROM TableContact WHERE ContactID = @pid", SqlConnectionClass.connection))
                {
                SqlConnectionClass.CheckConnection();
                command.Parameters.AddWithValue("@pid", id);

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return NotFound(); // Silme i�lemi ba�ar�s�z olduysa 404 hata sayfas�na y�nlendirin veya ba�ka bir i�lem yap�n
                    }
                }
           

            return RedirectToPage("Messages"); // Silme i�lemi ba�ar�l�ysa "Messages" sayfas�na y�nlendirin
        }
    }
}
