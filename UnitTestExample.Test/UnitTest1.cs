using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{

    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidateEmail(email);
            NUnit.Framework.Assert.AreEqual(expectedResult, actualResult);
        }

        [
            Test,
            TestCase("ASDasd", false),
            TestCase("ASDASD123", false),
            TestCase("asdasd123", false),
            TestCase("a", false),
            TestCase("Asd123", false),
            TestCase("ASDasd123", true)
        ]
        public void TestValidatePassword(string password, bool expextedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidatePassword(password);
            NUnit.Framework.Assert.AreEqual(expextedResult, actualResult);
        }
    }
}
