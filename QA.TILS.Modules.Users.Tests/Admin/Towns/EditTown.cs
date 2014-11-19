using QA.TILS.Modules.Users.Core.SharedSteps;

namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Towns
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Towns;

    [TestClass]
    public class EditTown : BaseTest
    {
        private TownsPage townsPage;
        private TownFactory factory;

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
        public void EditValidTown_ShouldSucceed()
        {
            LoginSteps.LoginAdmin();
            this.townsPage.NavigateTo();
            Town town = this.factory.GetValidTown();
            Town newTown = this.factory.GetValidTown2();
            this.townsPage.EditTown(town, newTown);
            this.townsPage.Validator.ValidateTownExist(newTown);
        }
    }
}