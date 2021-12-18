using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    public class AccountControllerTestFixture
    {
        [Test]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidateEmail(email);
            NUnit.Framework.Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
