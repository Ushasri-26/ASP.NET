using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Country.Models;

namespace WebAPI_Country.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> countryList = new List<Country>()
        {
            new Country{ Id=1, CountryName="India", Capital="Delhi"},
            new Country{ Id=2, CountryName="USA", Capital="Washington"}
        };
        [HttpPost]
        [Route("AddCountry")]
        public IHttpActionResult AddCountry(Country country)
        {
            countryList.Add(country);
            return Ok(countryList);
        }
        [HttpGet]
        [Route("GetCountries")]
        public IHttpActionResult GetCountries()
        {
            return Ok(countryList);
        }
        [HttpPut]
        [Route("UpdateCountry/{id}")]
        public IHttpActionResult UpdateCountry(int id, Country country)
        {
            var existing = countryList.FirstOrDefault(c => c.Id == id);

            if (existing == null)
            {
                return NotFound();   
            }

            existing.CountryName = country.CountryName;
            existing.Capital = country.Capital;

            return Ok(countryList);
        }
        [HttpDelete]
        [Route("DeleteCountry/{id}")]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countryList.FirstOrDefault(c => c.Id == id);

            if (country == null)
            {
                return NotFound();   
            }

            countryList.Remove(country);
            return Ok(countryList);
        }
    }
}
