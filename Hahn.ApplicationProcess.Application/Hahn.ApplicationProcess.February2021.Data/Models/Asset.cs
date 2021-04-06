using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string AssetName  { get; set; }
        //public enum Department { HQ, Store1, Store2, Store3, MaintenanceStation }
        public string CountryOfDepartment { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broken { get; set; }
    }
}
