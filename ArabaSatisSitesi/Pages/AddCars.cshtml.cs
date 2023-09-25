using ArabaSatisSitesi.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using static ArabaSatisSitesi.Pages.ListCarsModel;

namespace ArabaSatisSitesi.Pages
{
    public class AddCarsModel : PageModel
    {

        [BindProperty]
        public int SelectedBrand { get; set; }
        [BindProperty]
        public string CarModel { get; set; }
        [BindProperty]
        public string CarPhoto { get; set; }
        [BindProperty]
        public string CarContact { get; set; }
        [BindProperty]
        public string CarFuelType { get; set; }
        [BindProperty]
        public string CarDescription { get; set; }
        [BindProperty]

        public string CarSeller { get; set; }
        [BindProperty]

        public int CarPrice { get; set; }


        // DropDownList i�in SelectListItem listesi
        public List<SelectListItem>? BrandItems { get; set; }

        public void OnGet()
        {
            // SQL sorgusunu olu�turun

            SqlCommand command = new SqlCommand("Select * from TableBrand", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();
            using (SqlDataReader reader = command.ExecuteReader())
            {

                BrandItems = new List<SelectListItem>();

                while (reader.Read())
                {
                    // Her bir veri sat�r� i�in SelectListItem olu�turun ve listeye ekleyin
                    BrandItems.Add(new SelectListItem
                    {
                        Value = reader["BrandID"].ToString(),
                        Text = reader["BrandName"].ToString()
                    });
                }
                reader.Close();
            }

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SqlCommand commandAdd = new SqlCommand("Insert into TableCar (CarModel,CarBrandID,CarFuelType,CarDescription,CarContact,CarSeller,CarPhoto,CarPrice) values (@pmodel,@pbrand,@pfuel,@pdes,@pcontact,@pseller,@pphoto,@pprice)", SqlConnectionClass.connection);

            SqlConnectionClass.CheckConnection();

            commandAdd.Parameters.AddWithValue("@pmodel", CarModel); // CarModel �zelli�ini kullan

            // Di�er parametreleri de ayn� �ekilde ekleyin
            commandAdd.Parameters.AddWithValue("@pbrand", SelectedBrand);
            commandAdd.Parameters.AddWithValue("@pfuel", CarFuelType);
            commandAdd.Parameters.AddWithValue("@pdes", CarDescription);
            commandAdd.Parameters.AddWithValue("@pcontact", CarContact);
            commandAdd.Parameters.AddWithValue("@pseller", CarSeller);
            commandAdd.Parameters.AddWithValue("@pphoto", CarPhoto);
            commandAdd.Parameters.AddWithValue("@pprice", CarPrice);

            commandAdd.ExecuteNonQuery();

            // Ekleme i�lemi ba�ar�yla tamamland�ysa, ba�ka bir sayfaya y�nlendirebilirsiniz
            return RedirectToPage("ListCars");
        }




    }
}
