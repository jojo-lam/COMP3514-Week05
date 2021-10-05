using System.Collections.Generic;
using System.Linq;
using LabCodeFirst.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using LabCodeFirst.Data;

public class SampleData {
  public static void Initialize(IApplicationBuilder app) { 
    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
      var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
      context.Database.EnsureCreated();

      // Look for any Provinces.
      if (context.Provinces.Any()) {
          return;   // DB has already been seeded
      }

      var Provinces = GetProvinces().ToArray();
      context.Provinces.AddRange(Provinces);
      context.SaveChanges();

      var Cities = GetCities(context).ToArray();
      context.Cities.AddRange(Cities);
      context.SaveChanges();
    }
  }

    public static List<Province> GetProvinces() {
        List<Province> Provinces = new List<Province>() {
            new Province() {
                ProvinceName="British Columbia",
                ProvinceCode="BC",
            },
            new Province() {
                ProvinceName="Alberta",
                ProvinceCode="AB",
            },
            new Province() {
                ProvinceName="Ontario",
                ProvinceCode="ON",
            }
        };

        return Provinces;
    }

    public static List<City> GetCities(ApplicationDbContext context) {
        List<City> Cities = new List<City>() {
            new City {
                CityName = "Vancouver",
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                Population = 10000000
            },
            new City {
                CityName = "Burnaby",
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                Population = 1000000
            },
            new City {
                CityName = "Richmond",
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                Population = 10000000
            },
            new City {
                CityName = "Calgary",
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode,
                Population = 10000000
            },
            new City {
                CityName = "Edmonton",
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode,
                Population = 1000000
            },
            new City {
                CityName = "Banff",
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode,
                Population = 10000000
            },
                        new City {
                CityName = "Ottawa",
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode,
                Population = 10000000
            },
            new City {
                CityName = "Toronto",
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode,
                Population = 1000000
            },
            new City {
                CityName = "Richmond Hill",
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode,
                Population = 10000000
            },
        };

        return Cities;
    }
}