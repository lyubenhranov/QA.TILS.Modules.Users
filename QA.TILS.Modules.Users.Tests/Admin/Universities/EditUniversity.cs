namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Universities
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Universities;

    [TestClass]
    public class EditUniversity : BaseTest
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
    }
}
