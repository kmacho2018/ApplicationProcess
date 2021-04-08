using System;

namespace Hahn.ApplicationProcess.February2021.Data.Models
{
    public enum Department
    { HQ = 1, Store1 = 2, Store2 = 3, Store3 = 4, MaintenanceStation = 5 }

    public class Asset
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public Department Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broken { get; set; }
    }
}