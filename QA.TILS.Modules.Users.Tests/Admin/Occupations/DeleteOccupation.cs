namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Occupations
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.OccupationsPage;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    [TestClass]
    public class DeleteOccupation : BaseTest
    {
        private OccupationsPage occupationsPage;

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
            this.occupationsPage = new OccupationsPage();
            this.occupationsPage.NavigateToAsAdmin();
        }

        [TestMethod]
        [Priority(4)]
        public void DeleteOccupation_ShouldRemoveTheOccupation()
        {
            this.occupationsPage.Elements.DeleteOccupation.Click();
        }
    }
}
