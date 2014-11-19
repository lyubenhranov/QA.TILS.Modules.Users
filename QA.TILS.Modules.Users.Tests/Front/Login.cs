namespace QA.TILS.Modules.Users.Tests.Functional.Front
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.ForgottenPasswordPage;
    using QA.TILS.Modules.Users.Core.Pages.LoginPage;

    [TestClass]
    public class Login : BaseTest
    {
        private LoginPage loginPage;
        private ForgottenPasswordPage forgottenPasswordPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            BaseClassInitialize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            BaseClassCleanup();
        }

        public override void TestInitialize()
        {
            this.loginPage = new LoginPage();
            this.forgottenPasswordPage = new ForgottenPasswordPage();
        }

        [TestMethod]
        [Priority(1)]
        public void LoginWithBlankCredentials_ShouldFail()
        {
            this.loginPage.Login("", "");

            this.loginPage.Validator.VerifyErrorMessageOnInvalidLogin();
        }

        [TestMethod]
        [Priority(1)]
        public void LoginWithValidUsernameAndInvalidPassword_ShouldFail()
        {
            this.loginPage.Login(TestUsers.TestUser1.Username, "invalidPassword");

            this.loginPage.Validator.VerifyErrorMessageOnInvalidLogin();
        }

        [TestMethod]
        [Priority(1)]
        public void LoginWithValidCredentials_ShouldBeSuccessfull()
        {
            this.loginPage.Login(TestUsers.TestUser1);

            this.loginPage.Validator.VerifySuccessfullLogin(TestUsers.TestUser1.Username);
        }

        [TestMethod]
        [Priority(3)]
        public void ForgottenPasswordLink_ShouldNavigateToTheCorrectPage()
        {
            this.loginPage.NavigateTo();

            this.loginPage.Elements.ForgottenPasswordLink.Click();
            this.Browser.WaitUntilReady();

            this.forgottenPasswordPage.Validator.VerifyUrl();
        }
    }
}
