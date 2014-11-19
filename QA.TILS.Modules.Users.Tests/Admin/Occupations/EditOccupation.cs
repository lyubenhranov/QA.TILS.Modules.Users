namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Occupations
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.OccupationsPage;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    [TestClass]
    public class EditOccupation : BaseTest
    {
        private OccupationsPage occupationsPage;
        private const string occupationName = "Changed occupation name";

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
        public void EditOccupationAndClickCancel_ShouldNotChangeOccupation()
        {
            this.occupationsPage.Elements.EditOccupation.Click();
            this.occupationsPage.Elements.CancelNewOccupation.Click();
        }

        [TestMethod]
        [Priority(3)]
        public void EditNewOccupationWithValidData_ShouldChangeTheOccupation()
        {
            this.occupationsPage.Elements.EditOccupation.Click();
            this.occupationsPage.Elements.TypeNameOfOccupation.Text =occupationName;
            this.occupationsPage.Elements.UpdateNewOccupation.Click();
        }
    }
}
