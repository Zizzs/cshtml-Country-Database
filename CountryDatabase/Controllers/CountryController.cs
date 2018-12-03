using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CountryDatabase.Models;
using System.Collections.Specialized;

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
            Dictionary<object, object> model = new Dictionary<object, object>();
            List<CountryClass> newList = CountryClass.GetAll();
            List<CityClass> newCityList = CityClass.GetAll();
            
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
                    model.Add("country", currentCountry);
                    
                }
            }

            List<CityClass> totalCityList = new List<CityClass>() {};
            foreach (CityClass city in newCityList)
            {
                if (city.GetCode() == code)
                {
                    string cityName = city.GetName();
                    string cityCode = city.GetCode();
                    string cityDistrict = city.GetDistrict();
                    int cityPopulation =  city.GetPopulation();
                    CityClass currentCity = new CityClass(cityName, cityCode, cityDistrict, cityPopulation);
                    totalCityList.Add(currentCity);
                }
            }

            model.Add("cities", totalCityList);
            return View(model);
        }

        [HttpGet("countries/{code}/{name}")]
        public ActionResult City(string name)
        {
            List<CityClass> newCityList = CityClass.GetAll();
            string cityName = "";
            string cityCode = "";
            string cityDistrict = "";
            int cityPopulation = 0;
            CityClass currentCity = new CityClass(cityName, cityCode, cityDistrict, cityPopulation);
            foreach (CityClass city in newCityList)
            {
                if (city.GetName() == name)
                {
                    currentCity.SetName(city.GetName());
                    currentCity.SetCode(city.GetCode());
                    currentCity.SetDistrict(city.GetDistrict());
                    currentCity.SetPopulation(city.GetPopulation());
                }
            }
            return View(currentCity); 
        }
    }
}
