using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CountryDatabase;

namespace CountryDatabase.Models
{
    public class CountryClass
    {
        private string _name;
        private string _continent;
        private int _population;
        private string _gov;
        private string _code;
        

        

        public CountryClass(string name, string continent, int population, string gov, string code)
        {
            _name = name;
            _continent = continent;
            _population = population;
            _gov = gov;
            _code = code;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetContinent()
        {
            return _continent;
        }

        public int GetPopulation()
        {
            return _population;
        }

        public string GetGovernment()
        {
            return _gov;
        }

        public string GetCode()
        {
            return _code;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetContinent(string continent)
        {
            _continent = continent;
        }

        public void SetPopulation(int population)
        {
            _population = population;
        }

        public void SetGovernment(string gov)
        {
            _gov = gov;
        }

        public void SetCode(string code)
        {
            _code = code;
        }

        public static List<CountryClass> GetAll()
        {
            List<CountryClass> allCountries = new List<CountryClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {
                string countryName = rdr.GetString(1);
                string countryContinent = rdr.GetString(2);
                int countryPopulation = rdr.GetInt32(6);
                string countryGovernment = rdr.GetString(11);
                string countryCode = rdr.GetString(0);
                CountryClass newCountry = new CountryClass(countryName, countryContinent, countryPopulation, countryGovernment, countryCode);
                allCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allCountries;
        }
    }

    public class CityClass
    {
        private string _name;
        private string _code;
        private string _district;
        private int _population;

        public CityClass(string name, string code, string district, int population)
        {
            _name = name;
            _code = code;
            _district = district;
            _population = population;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetCode()
        {
            return _code;
        }

        public string GetDistrict()
        {
            return _district;
        }


        public int GetPopulation()
        {
            return _population;
        }

    
        public void SetName(string name)
        {
            _name = name;
        }

        public void SetCode(string code)
        {
            _code = code;
        }

        public void SetPopulation(int population)
        {
            _population = population;
        }

        public void SetDistrict(string district)
        {
            _district = district;
        }

        public static List<CityClass> GetAll()
        {
            List<CityClass> allCities = new List<CityClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {
                string cityName = rdr.GetString(1);
                string cityCode = rdr.GetString(2);
                string cityDistrict = rdr.GetString(3);
                int cityPopulation = rdr.GetInt32(4);
             
                CityClass newCity = new CityClass(cityName, cityCode, cityDistrict, cityPopulation);
                allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allCities;
        }
    }
}
