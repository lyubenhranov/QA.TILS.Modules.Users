using QA.TILS.Modules.Users.Core.SharedSteps;

namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Towns
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Towns;

    [TestClass]
    public class DeleteTown :BaseTest
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
        public void DeleteValidTown_ShouldSucceed()
        {
            Town town = this.factory.GetValidTown();
            LoginSteps.LoginAdmin();
            this.townsPage.NavigateTo();
            this.townsPage.DeleteTown(town);
            this.townsPage.Validator.ValidateTownDoesNotExist(town);
        }
    }
}
