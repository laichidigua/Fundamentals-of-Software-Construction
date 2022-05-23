using Microsoft.AspNetCore.Mvc;
using OrderAppClasses;
using System.Data.Entity;

namespace OrderAppWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext orderDb;

        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }
        //GET:  order/{id}
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(long id)
        {
            var orderItem = orderDb.Orders.FirstOrDefault(t => t.Id == id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return orderItem;
        }

        //GET:  order
        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            IQueryable<Order> query = orderDb.Orders;
            return query.ToList();
        }

        //GET: order/detail/{id}
        [HttpGet("detail/{id}")]
        public ActionResult<OrderDetail> GetOrderDetail(long id)
        {
            var OrderDetailItem = orderDb.OrderDetails.FirstOrDefault(t => t.Id == id);
            if (OrderDetailItem == null)
            {
                return NotFound();
            }
            return OrderDetailItem;
        }
        //GET: order/detail
        [HttpGet]
        public ActionResult<List<OrderDetail>> GetOrderDetails()
        {
            IQueryable<OrderDetail> query = orderDb.OrderDetails;
            return query.ToList();
        }


        // POST: order
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }
        // PUT: order/{id}
        [HttpPut("{id}")]
        public ActionResult<Order> PutOrder(long id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        // DELETE: order/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(long id)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(t => t.Id == id);
                if (order != null)
                {
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
    }
}
