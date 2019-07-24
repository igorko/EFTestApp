using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Effort;

namespace EFTestApp.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            DbConnection effortConnection = DbConnectionFactory.CreatePersistent("MyInstanceName");
            var context = new CustomerModel(effortConnection);

            Transaction tr = new Transaction { ID = 200, Amount = 200, Currency = "USD", Datetime = new DateTime(), Status = "Success" };
            var transactionsList = new LinkedList<Transaction>();
            transactionsList.AddFirst(tr);
            Customer user = new Customer { ID = 41, Name = "us1", Email = "example@ex.com", MobileNo = 345346364346, Transactions = transactionsList };

            context.Customers.Add(user);
            context.SaveChanges();
        }
    }
}
