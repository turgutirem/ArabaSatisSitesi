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
                return NotFound(); // Geçersiz bir ID varsa 404 hata sayfasýna yönlendirin veya baþka bir iþlem yapýn
            }

          
                using (var command = new SqlCommand("DELETE FROM TableContact WHERE ContactID = @pid", SqlConnectionClass.connection))
                {
                SqlConnectionClass.CheckConnection();
                command.Parameters.AddWithValue("@pid", id);

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return NotFound(); // Silme iþlemi baþarýsýz olduysa 404 hata sayfasýna yönlendirin veya baþka bir iþlem yapýn
                    }
                }
           

            return RedirectToPage("Messages"); // Silme iþlemi baþarýlýysa "Messages" sayfasýna yönlendirin
        }
    }
}
