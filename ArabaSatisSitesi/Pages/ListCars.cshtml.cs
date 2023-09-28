using ArabaSatisSitesi.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static ArabaSatisSitesi.Pages.ListCarsModel;


namespace ArabaSatisSitesi.Pages
{
    public class ListCarsModel : PageModel
    {
       

        public List<CarsModels> Cars { get; set; }

      

        public void OnGet()
        {

            SqlCommand commandList = new SqlCommand("Select CarID, CarModel, CarBrandID, CarFuelType, CarDescription, CarContact, CarSeller, CarPhoto, CarPrice, CarConfirmation, BrandID, BrandName from TableCar inner join TableBrand on TableCar.CarBrandID=TableBrand.BrandID where CarConfirmation=@pcon", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();
            commandList.Parameters.AddWithValue("@pcon", true);

            List<CarsModels> cars = new List<CarsModels>();

            using (SqlDataReader reader = commandList.ExecuteReader())
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
                        BrandName = reader["BrandName"].ToString(),
                        CarPrice = (int)reader["CarPrice"]
                    });
                }
            }

            Cars = cars;
        }
       

    }
}
