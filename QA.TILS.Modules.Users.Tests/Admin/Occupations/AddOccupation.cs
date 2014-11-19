namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Occupations
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.OccupationsPage;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    [TestClass]
    public class AddOccupation : BaseTest
    {
        private OccupationsPage occupationsPage;
        private const string occupationName = "some name here";

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
        public void AddNewOccupationWithNoNameFilled_ShouldAskForName()
        {
            this.occupationsPage.Elements.AddNewOccupation.Click();
            this.occupationsPage.Elements.UpdateNewOccupation.Click();
        }

        [TestMethod]
        [Priority(4)]
        public void AddNewOccupationAndClickCancel_ShouldNotCreateOccupation()
        {
            this.occupationsPage.Elements.AddNewOccupation.Click();
            this.occupationsPage.Elements.CancelNewOccupation.Click();
        }

        [TestMethod]
        [Priority(3)]
        public void AddNewValidOccupation_ShouldCreateOccupation()
        {
            this.occupationsPage.Elements.AddNewOccupation.Click();
            this.occupationsPage.Elements.TypeNameOfOccupation.Text = occupationName;
            this.occupationsPage.Elements.UpdateNewOccupation.Click();
        }
    }
}
