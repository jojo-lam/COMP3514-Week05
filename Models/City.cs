using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace LabCodeFirst.Models
{
    public class City
    {
        public int CityId { get; set; }
        [Display (Name = "City") ]
        public string CityName { get; set; }
        public int Population { get; set; }    
        public string ProvinceCode { get; set; }    
        [ForeignKey("ProvinceCode")]
        [Display (Name = "Province") ]
        public Province Provinces { get; set; }
    }
}