﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UBSafeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanionSessionsController : ControllerBase
    {
        // GET: api/CompanionSessions
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CompanionSessions/5
        [HttpGet("{id}", Name = "GetCompanionSession")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CompanionSessions
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CompanionSessions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
