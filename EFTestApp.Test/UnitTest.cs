using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Http;
using System.Web.Http.Results;
using Effort;
using EFTestApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EFTestApp.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestController()
        {
            DbConnection effortConnection = DbConnectionFactory.CreatePersistent("MyInstanceName");
            var context = new CustomerModel(effortConnection);

            Transaction tr = new Transaction { ID = 200, Amount = 200, Currency = "USD", Datetime = new DateTime(), Status = "Success" };
            var transactionsList = new LinkedList<Transaction>();
            transactionsList.AddFirst(tr);
            Customer user = new Customer { ID = 41, Name = "us1", Email = "example@ex.com", MobileNo = 345346364346, Transactions = transactionsList };

            var mockHttpContext = new Mock<HttpRequestMessage>();
            var mockRequest = new Mock<HttpRequestMessage>();

            mockRequest.Object.Content = new StringContent("{ \"ID\" : 41 }");

            context.Customers.Add(user);
            context.SaveChanges();

            var ctrl = new CustomersController(context);
            var contentResult = ctrl.GetCustomer(mockRequest.Object) as OkNegotiatedContentResult<Customer>;

            var returnedCustomer = contentResult.Content;
            var returnedTransactions = returnedCustomer.Transactions;
            Assert.AreEqual(returnedCustomer, user);
            Assert.AreEqual(returnedTransactions, transactionsList);
        }
    }
}
