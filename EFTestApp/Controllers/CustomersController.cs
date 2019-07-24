using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Web.Http.Description;
using Z.EntityFramework.Plus;

namespace EFTestApp.Controllers
{
    public class CustomersController : ApiController
    {
        public CustomersController()
        {
        }

        public CustomersController(CustomerModel context)
        {
            db = context;
        }

        private CustomerModel db = new CustomerModel();

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(HttpRequestMessage context)
        {
            var contentResult = context.Content.ReadAsStringAsync();
            if (contentResult == null)
            {
                return BadRequest();
            }
            string result = contentResult.Result;
            if (result == null || result.Length == 0)
            {
                return BadRequest();
            }

            Customer inCustomer = null;
            try
            {
                inCustomer = JsonConvert.DeserializeObject<Customer>(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            Expression<Func<Customer, bool>> searchCriteria = null;
            if (inCustomer.ID != 0 && inCustomer.Email != null)
            {
                searchCriteria = c => c.ID == inCustomer.ID && c.Email == inCustomer.Email;
            }
            else if (inCustomer.ID != 0)
            {
                searchCriteria = c => c.ID == inCustomer.ID;
            }
            else if (inCustomer.Email != null)
            {
                searchCriteria = c => c.Email == inCustomer.Email;
            }
            else
            {
                return BadRequest("No inquery criteria");
            }

            var customer = db.Customers
                       .Where(searchCriteria)
                       .IncludeFilter(c => c.Transactions.OrderByDescending(t => t.Datetime).Take(5))
                       .FirstOrDefault();

            if (customer == null)
            {
                if (db.Customers.Find(inCustomer.ID) == null)
                {
                    return BadRequest("Invalid Customer ID");
                }
                else if (db.Customers.Where(c => c.Email == inCustomer.Email).FirstOrDefault() == null)
                {
                    return BadRequest("Invalid Email");
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(decimal id)
        {
            return db.Customers.Count(e => e.ID == id) > 0;
        }
    }
}

