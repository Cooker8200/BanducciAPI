using AutoFixture;
using BanducciAPI.Controllers;
using BanducciAPI.Data;
using BanducciAPI.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BanducciEmployeeGetTest()
        {
            var fixture = new Fixture();
            var employees = new List<BanducciEmployee>
            {
                fixture.Build<BanducciEmployee>().Create(),
                fixture.Build<BanducciEmployee>().Create()
            }.AsQueryable();

            var employeeMock = new Mock<DbSet<BanducciEmployee>>();
            employeeMock.As<IQueryable<BanducciEmployee>>().Setup(x => x.GetEnumerator()).Returns(employees.GetEnumerator());

            var employeeContextMock = new Mock<BanducciDataContext>();
            //employeeContextMock.Setup(x => x.BanducciEmployee).Returns(employeeMock.Object);

            var employeeController = new BanducciEmployeesController(employeeContextMock.Object);

            var result = employeeController.GetBanducciEmployee();

            Assert.AreEqual(result, employees);
        }

        [Test]
        public void TestTest()
        {
            var a = "apple";
            Assert.AreEqual(a, "apple");
        }
    }
}