using Microsoft.AspNetCore.Mvc;

namespace ArabaSatisSitesi.Classes
{
    public class CarsModels
    {
        public string BrandName { get; set; }
     
        public string CarModel { get; set; }
      
        public string CarPhoto { get; set; }
        public string CarContact { get; set; }
        public string CarFuelType { get; set; }
        public string CarDescription { get; set; }

        public string CarSeller { get; set; }

        public int CarPrice { get; set; }
        // Diğer özellikler burada
    }
    public class BrandModel
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
    }
}
