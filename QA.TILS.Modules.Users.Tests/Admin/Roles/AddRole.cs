using QA.TILS.Modules.Users.Core.SharedSteps;

namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Roles
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Roles;

    [TestClass]
    public class AddRole : BaseTest
    {
        private RoleFactory factory;
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
            this.factory = new RoleFactory();
        }

        [TestMethod]
        [Priority(2)]
        public void AddingNewRoleWithValidData_ShouldBeSavedToTheDatabase()
        {
            Role role = this.factory.GetValidRole();
            LoginSteps.LoginAdmin();
            this.rolesPage.NavigateTo();
            this.rolesPage.CreateRole(role);
            this.rolesPage.Validator.ValidateRoleExist(role);
        }
    }
}
