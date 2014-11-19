namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Roles
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Roles;

    [TestClass]
    public class EditRole : BaseTest
    {
        private RolesPage rolesPage;

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
            this.rolesPage = new RolesPage();
        }
    }
}
