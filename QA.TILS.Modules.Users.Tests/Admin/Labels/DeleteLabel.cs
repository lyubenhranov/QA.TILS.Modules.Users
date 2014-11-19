namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Labels
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Labels;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    [TestClass]
    public class DeleteLabel : BaseTest
    {
        private LabelsPage labelsPage;

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
            this.labelsPage = new LabelsPage();
            this.labelsPage.NavigateToAsAdmin();
        }

        [TestMethod]
        [Priority(4)]
        public void DeleteExistingLabel_ShouldDeleteLabel()
        {
            this.labelsPage.Elements.DeleteExistingLabel.Click();
        }
    }
}
