namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Towns
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Towns;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    [TestClass]
    public class AddTown : BaseTest
    {
        private TownFactory factory;
        private TownsPage townsPage;

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
            this.townsPage = new TownsPage();
            this.factory = new TownFactory();
        }

        [Priority(3)]
        [TestMethod]
        public void AddValidTown_ShouldShouldSucceed()
        {
            LoginSteps.LoginAdmin();
            this.townsPage.NavigateTo();
            Town town = this.factory.GetValidTown();
            this.townsPage.CreateTown(town);
            this.townsPage.Validator.ValidateTownExist(town);
        }

        [Priority(3)]
        [TestMethod]
        public void AddTownWithEmptyEnglishName_ValidationMessageShouldMatch()
        {
            LoginSteps.LoginAdmin();
            this.townsPage.NavigateTo();
            Town town = this.factory.GetEmptyEnglishName();
            this.townsPage.CreateTown(town);
            this.townsPage.Validator.ValidateRequiredEnglishNameMessage(this.townsPage.Elements.EnglishNameValidationMessage);
        }

        [Priority(3)]
        [TestMethod]
        public void AddTownWithEmptyBulgarianName_ValidationMessageShouldMatch()
        {
            LoginSteps.LoginAdmin();
            this.townsPage.NavigateTo();
            Town town = this.factory.GetEmptyBulgariaName();
            this.townsPage.CreateTown(town);
            this.townsPage.Validator.ValidateRequiredBulgarianhNameMessage(this.townsPage.Elements.BulgarianNameValidationMessage);
        }

        [Priority(3)]
        [TestMethod]
        public void AddTownWithWrongEnglishName_ValidationMessageShouldMatch()
        {
            LoginSteps.LoginAdmin();
            this.townsPage.NavigateTo();
            Town town = this.factory.GetInvalidEnglishName();
            this.townsPage.CreateTown(town);
            this.townsPage.Validator.ValidateInvalidEnglishNameMessage(this.townsPage.Elements.EnglishNameValidationMessage);
        }

        [Priority(3)]
        [TestMethod]
        public void AddTownWithWrongBulgarianName_ValidationMessageShouldMatch()
        {
            LoginSteps.LoginAdmin();
            this.townsPage.NavigateTo();
            Town town = this.factory.GetInvalidBulgarianName();
            this.townsPage.CreateTown(town);
            this.townsPage.Validator.ValidateInvalidBulgarianNameMessage(this.townsPage.Elements.BulgarianNameValidationMessage);
        }
    }
}