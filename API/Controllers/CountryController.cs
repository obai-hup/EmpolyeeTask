using API.Data;
using EmpolyeeTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApiContext context;

        public CountryController(ApiContext context)
        {
            this.context = context;
        }
        // GET: CountryController

        [HttpGet]
        public List<Country> GetCountries()
        {
            return context.countries.ToList();
        }


    }
}
