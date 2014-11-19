using QA.TILS.Modules.Users.Core.SharedSteps;

namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Universities
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Universities;

    [TestClass]
    public class DeleteUniversity : BaseTest
    {
        private UniversitiesPage universitiesPage;
        private UniversityFactory factory;

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
            this.factory = new UniversityFactory();
            this.universitiesPage = new UniversitiesPage();
        }

        [Priority(3)]
        [TestMethod]
        public void DeleteExistingUniversity_ShouldSuccceed()
        {
            LoginSteps.LoginAdmin();
            this.universitiesPage.NavigateTo();
            University university = this.factory.GetValidUniversity();
            this.universitiesPage.DeleteUniversity(university);
            this.universitiesPage.Validator.ValidateUniversityDoesNotExist(university);
        }
    }
}
