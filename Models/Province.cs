using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace LabCodeFirst.Models
{
  public class Province
  {
    [Key]
    [Display(Name = "Province Code")]
    public string ProvinceCode { get; set; }
    [Display(Name = "Province")]

    public string ProvinceName { get; set; }
    public Collection<City> Cities { get; set; }
  }
}