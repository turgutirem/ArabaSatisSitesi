using ArabaSatisSitesi.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ArabaSatisSitesi.Pages
{
    public class AdminAddCarsModel : PageModel
    {
        public List<CarsModels> Cars { get; set; }


        public void OnGet()
        {
            string isAdminString = HttpContext.Session.GetString("IsUserAdmin");
            if (!string.IsNullOrEmpty(isAdminString) && isAdminString.ToLower() == "true")
            {

                SqlCommand command = new SqlCommand("SELECT * FROM TableCar WHERE CarConfirmation = @pcon", SqlConnectionClass.connection);

                SqlConnectionClass.CheckConnection();
                command.Parameters.AddWithValue("@pcon", false);

                List<CarsModels> cars = new List<CarsModels>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cars.Add(new CarsModels
                        {
                            CarModel = reader["CarModel"].ToString(),
                            CarFuelType = reader["CarFuelType"].ToString(),
                            CarDescription = reader["CarDescription"].ToString(),
                            CarContact = reader["CarContact"].ToString(),
                            CarSeller = reader["CarSeller"].ToString(),
                            CarPhoto = reader["CarPhoto"].ToString(),
                            CarID = (int)reader["CarID"],
                            CarPrice = (int)reader["CarPrice"]
                        });
                    }
                }


                Cars = cars;

            }
            else
            {
                HttpContext.Response.Redirect("LoginPage");
            }


        }
    }
}
