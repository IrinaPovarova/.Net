using OrderManager.DAL.Entities;
using System;
using System.Collections.Generic;

namespace OrderManager.Tests.Fake
{
    public class FakeContext
    {
        public List<Order> Orders = new List<Order>()
        {
            new Order()
            {
                OrderID = 1,
                RequiredDate = DateTime.Now.AddMonths(9),
                OrderDate =null,
                ShippedDate =  null,
                ShipName = "Sherlock Holms",
                ShipAddress = "22, Baker Str",
                ShipCity = "London",
                ShipCountry = "UK",
                ShipPostalCode = "OX15 4NB",
                Freight = 1,
                CustomerID = "KING",
                EmployeeID = 4,
                ShipVia = 2,
                },
            new Order() {
                OrderID = 2,
                RequiredDate = DateTime.Now.AddMonths(9),
                OrderDate = DateTime.Now,
                ShippedDate =  null,
                ShipName = "Mathew Crawly",
                ShipAddress = "2 Downton Abbey",
                ShipCity = "York",
                ShipCountry = "UK",
                ShipPostalCode = "YO02",
                Freight = 2,
                CustomerID = "PRINI",
                EmployeeID = 2,
                ShipVia = 2,
                },
            new Order() {OrderID = 3,
                OrderDate = new DateTime(2021,1,1),
                ShippedDate =  DateTime.Now,
                RequiredDate = DateTime.Now.AddMonths(9),
                ShipName = "Henry Talbot",
                ShipAddress = "2 Abbey Ave",
                ShipCity = "Rome",
                ShipCountry = "IT",
                ShipPostalCode = "YO02",
                Freight = 3,
                CustomerID = "LORD",
                EmployeeID = 3,
                ShipVia = 3,
            }
        };
        public List<OrderDetail> OrderDetails = new List<OrderDetail>()
        {
            new OrderDetail()
            {
                OrderID =1,
                ProductID = 1,
                Product = new Product(){ProductID = 1, ProductName ="Bread"},
                Quantity = 1,
                Discount = 0.5f,
                UnitPrice = 10,},
            new OrderDetail()
            {
                OrderID =1,
                ProductID = 3,
                Product = new Product(){ProductID = 3, ProductName ="Butter"},
                Quantity = 1,
                Discount = 0.5f,
                UnitPrice = 10,},
            new OrderDetail()
            {
                OrderID =2,
                ProductID = 1,
                Product = new Product(){ProductID = 1, ProductName ="Bread"},
                Quantity = 1,
                Discount = 0.5f,
                UnitPrice = 10,},
            new OrderDetail()
            {
                OrderID = 2,
                ProductID = 1,
                Product = new Product(){ProductID = 2, ProductName ="Fish"},
                Quantity = 1,
                Discount = 0.5f,
                UnitPrice = 10,},
            new OrderDetail()
            {
                OrderID = 3,
                ProductID = 4,
                Product = new Product(){ProductID = 4, ProductName ="Milk"},
                Quantity = 1,
                Discount = 0.5f,
                UnitPrice = 10,}

        };
    }
}
