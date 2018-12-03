using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CountryDatabase.Models;

namespace CountryDatabase.Controllers
{
    public class CountryController : Controller
    {
        [HttpGet("countries")]
        public ActionResult Index()
        {
            List<CountryClass> newList = CountryClass.GetAll();
            return View(newList);
        }

        [HttpGet("countries/{code}")]
        public ActionResult Show(string code)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            List<CountryClass> newList = CountryClass.GetAll();
            List<CityClass> newCityList = CityClass.GetAll();

            List<CityClass> totalCities = new List<CityClass> {};
            
            string currentName = "";
            string currentContinent = "";
            int currentPopulation = 0;
            string currentGov = "";
            string currentCode = "";
            CountryClass currentCountry = new CountryClass(currentName, currentContinent, currentPopulation, currentGov, currentCode);
            
            foreach (CountryClass country in newList)
            {
                if (country.GetCode() == code)
                {
                    currentCountry.SetName(country.GetName());
                    currentCountry.SetContinent(country.GetContinent());
                    currentCountry.SetPopulation(country.GetPopulation());
                    currentCountry.SetGovernment(country.GetGovernment());
                    currentCountry.SetCode(country.GetCode());
                    // foreach(CityClass city in newCityList)
                    // {
                    //     if (city.GetCode() == currentCountry.GetCode())
                    //     {
                    //         totalCities.Add(city);
                    //     }
                    // }

                    //currentCountry.SetCities(totalCities);
                }

            }
            return View(currentCountry);
        }



    }
}
