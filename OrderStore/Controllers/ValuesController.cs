using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;
using OrderStore.Repository;

namespace OrderStore.Controllers
{
    /// <summary>
    /// Controller for Connectivity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly OrderStore.CQRS.Select _selectUnit;
        private readonly OrderStore.CQRS.InsertUpdate _insertUpdate;
        private readonly Domain.Models.ApplicationDbContext _db;

        public ValuesController()
        {

            var connectionstring = @"server='visiontv.site\MSSQLSERVER0';uid='atv';pwd='123';database='atv';";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);


            _db = new ApplicationDbContext(optionsBuilder.Options);


            IProductRepository pr = new Repository.ProductRepository(_db);
            IOrderRepository or = new Repository.OrderRepository(_db);
            _selectUnit = new OrderStore.CQRS.Select(_db, or, pr);
            _insertUpdate = new OrderStore.CQRS.InsertUpdate(_db, or, pr);
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return Ok(await _selectUnit.Orders.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(string id)
        {
            return Ok(await _selectUnit.Orders.GetOrdersByOrderName(id));
        }
        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders() => Ok(await _selectUnit.Orders.GetAll());

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
