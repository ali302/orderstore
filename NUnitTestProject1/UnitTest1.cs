using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;

namespace Tests
{
    public class Tests
    {
        /// <summary>
        /// Using InMemory Table as Mocks and DI is not required but can be used where required.
        /// In Memory Table is not exactly unit test but almost like that
        /// </summary>
        private  OrderStore.CQRS.Select _selectUnit;
        private OrderStore.CQRS.InsertUpdate _insertUpdate;
        private  OrderStore.Domain.Models.ApplicationDbContext _db;

        [Test]
        public  void Test1Async()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("test");
            _db = new ApplicationDbContext(optionsBuilder.Options);
            var name = "Test";
            var update = "NewTest";
            IProductRepository pr = new OrderStore.Repository.ProductRepository(_db);
            IOrderRepository or = new OrderStore.Repository.OrderRepository(_db);
            _selectUnit = new OrderStore.CQRS.Select(_db, or, pr);
            _insertUpdate = new OrderStore.CQRS.InsertUpdate(_db, or, pr);
            _insertUpdate.AddOrder(name,1,1);
            var result =   _selectUnit.Orders.GetAll();
            var r = result.Result;
            //Get and Add Record Text
            Assert.AreEqual(name,((System.Collections.Generic.List<Orders>)r)[0].OrderName);
            _insertUpdate.Orders.UpdateOrderNameById(1, update);
            result = _selectUnit.Orders.GetAll();
            r = result.Result;
            //Update Record Test
            Assert.AreEqual(update,((System.Collections.Generic.List<Orders>)r)[0].OrderName);
            _insertUpdate.Orders.DeleteOrderById(1);
            result = _selectUnit.Orders.GetAll();
            r = result.Result;
            //Del Record Test
            Assert.AreEqual(0,((System.Collections.Generic.List<Orders>)r).Count);
        }
    }
}