using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Activities;
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

        [
            Test,
            TestCase("a@a.hu", "ASDasd123"),
            TestCase("z@z.hu", "ASD123asd"),
        ]
        public void TestRegisterHappyPath(string email, string password)
        {
            var accountController = new AccountController();
            var actualResult = accountController.Register(email, password);
            NUnit.Framework.Assert.AreEqual(email, actualResult.Email);
            NUnit.Framework.Assert.AreEqual(password, actualResult.Password);
            NUnit.Framework.Assert.AreEqual(Guid.Empty, actualResult.ID);

        }

        [
            Test,
            //TestCase("a.a.hu", "ASDasd123"),
            //TestCase("zz.hu", "ASD123asd"),
            //TestCase("zz.hu", "a"),
            //TestCase("z@z.hu", "b"),
            //TestCase("huhu.com", "123"),
            //TestCase("zz.hu", "AAAAAAAAA"),
            //TestCase("asd@asd.hu", "ASDasd123")
            TestCase("irf@uni-corvinus", "Abcd1234"),
            TestCase("irf.uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "abcd1234"),
            TestCase("irf@uni-corvinus.hu", "ABCD1234"),
            TestCase("irf@uni-corvinus.hu", "abcdABCD"),
            TestCase("irf@uni-corvinus.hu", "Ab1234"),
        ]
        public void TestRegisterValidateException(string email, string password)
        {
            var accountController = new AccountController();
            try
            {
                var actualResult = accountController.Register(email, password);
                NUnit.Framework.Assert.Fail();
            }
            catch (Exception ex)
            {
                NUnit.Framework.Assert.IsInstanceOf<ValidationException>(ex);
                throw;
            }

        }
    }
}
