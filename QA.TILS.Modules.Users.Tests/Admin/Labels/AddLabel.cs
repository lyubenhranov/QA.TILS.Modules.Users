namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Labels
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Labels;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    [TestClass]
    public class AddLabel : BaseTest
    {
        private const string ValidName = "Some name here";
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
        [Priority(3)]
        public void AddLabelWithValidName_ShouldCreateLabel()
        {
            this.labelsPage.Elements.AddNewLabelButton.Click();
            this.labelsPage.Elements.TypeNameOfTheLabel.Text = ValidName;
            this.labelsPage.Elements.UpdateNewLabel.Click();

            this.labelsPage.Validator.VerifyLabelIsPresent(ValidName);
        }

        [TestMethod]
        [Priority(4)]
        public void AddNewLabelWithNoInformationFilled_ShouldNotCreateLabel()
        {
            this.labelsPage.Elements.AddNewLabelButton.Click();
            this.labelsPage.Elements.UpdateNewLabel.Click();
        }

        [TestMethod]
        [Priority(4)]
        public void AddNewLabelAndThenClickCancel_ShouldNotCreateLabel()
        {
            this.labelsPage.Elements.AddNewLabelButton.Click();
            this.labelsPage.Elements.CancelCreatingNewLabel.Click();
        }
    }
}
