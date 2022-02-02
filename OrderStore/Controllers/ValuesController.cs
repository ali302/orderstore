using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderStore.Domain.Interfaces;
using OrderStore.Repository;

namespace OrderStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository.ApplicationDbContext _db;

        public ValuesController()
        {

            var connectionstring = @"server='visiontv.site\MSSQLSERVER0';";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);


            ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options);


            IProductRepository pr = new Repository.ProductRepository(dbContext);
            IOrderRepository or = new Repository.OrderRepository(dbContext);
            _unitOfWork = new Repository.UnitOfWork(dbContext, or, pr);
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            var d = Ok(await _unitOfWork.Orders.GetAll());
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders() => Ok(await _unitOfWork.Orders.GetAll());

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
