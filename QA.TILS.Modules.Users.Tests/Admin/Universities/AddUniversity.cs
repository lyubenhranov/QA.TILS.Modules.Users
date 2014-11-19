using QA.TILS.Modules.Users.Core.SharedSteps;

namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Universities
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Universities;

    [TestClass]
    public class AddUniversity : BaseTest
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
            this.universitiesPage = new UniversitiesPage();
            this.factory = new UniversityFactory();
        }

        [Priority(3)]
        [TestMethod]
        public void AddNewUniversityWithValidData_ShouldSucceed()
        {
            LoginSteps.LoginAdmin();
            this.universitiesPage.NavigateTo();
            University university = this.factory.GetValidUniversity();
            this.universitiesPage.CreateUniversity(university);
            this.universitiesPage.Validator.ValidateUniversityExist(university);
        }
    }
}
