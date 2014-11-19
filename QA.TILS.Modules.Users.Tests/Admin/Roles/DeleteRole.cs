using QA.TILS.Modules.Users.Core.SharedSteps;

namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Roles
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Roles;

    [TestClass]
    public class DeleteRole : BaseTest
    {
        private RolesPage rolesPage;
        private RoleFactory factory;

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
        [Priority(3)]
        public void DeletingARole_ShouldRemoveItFromTheDatabase()
        {
            Role role = this.factory.GetValidRole();
            LoginSteps.LoginAdmin();
            this.rolesPage.NavigateTo();
            this.rolesPage.DeleteRole(role);
            this.rolesPage.Validator.ValidateRoleDoesNotExist(role);
        }
    }
}
