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


        // DropDownList için SelectListItem listesi
        public List<SelectListItem>? BrandItems { get; set; }

        public void OnGet()
        {
            // SQL sorgusunu oluþturun

            SqlCommand command = new SqlCommand("Select * from TableBrand", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();
            using (SqlDataReader reader = command.ExecuteReader())
            {

                BrandItems = new List<SelectListItem>();

                while (reader.Read())
                {
                    // Her bir veri satýrý için SelectListItem oluþturun ve listeye ekleyin
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

            commandAdd.Parameters.AddWithValue("@pmodel", CarModel); // CarModel özelliðini kullan

            // Diðer parametreleri de ayný þekilde ekleyin
            commandAdd.Parameters.AddWithValue("@pbrand", SelectedBrand);
            commandAdd.Parameters.AddWithValue("@pfuel", CarFuelType);
            commandAdd.Parameters.AddWithValue("@pdes", CarDescription);
            commandAdd.Parameters.AddWithValue("@pcontact", CarContact);
            commandAdd.Parameters.AddWithValue("@pseller", CarSeller);
            commandAdd.Parameters.AddWithValue("@pphoto", CarPhoto);
            commandAdd.Parameters.AddWithValue("@pprice", CarPrice);

            commandAdd.ExecuteNonQuery();

            // Ekleme iþlemi baþarýyla tamamlandýysa, baþka bir sayfaya yönlendirebilirsiniz
            return RedirectToPage("ListCars");
        }




    }
}
