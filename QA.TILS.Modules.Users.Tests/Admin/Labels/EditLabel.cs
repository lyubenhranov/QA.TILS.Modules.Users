namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Labels
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.Labels;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    [TestClass]
    public class EditLabel : BaseTest
    {
        private const string EditedName = "Some edited name here";
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
        public void EditNameOfLabel_ShouldChangeName()
        {
            this.labelsPage.Elements.EditExistingLabel.Click();
            this.labelsPage.Elements.TypeNameOfTheLabel.Text = EditedName;
            this.labelsPage.Elements.UpdateNewLabel.Click();

            this.labelsPage.Validator.VerifyLabelIsPresent(EditedName);
        }

        [TestMethod]
        [Priority(4)]
        public void EditNewLabelAndThenClickCancel_ShouldNotChangeLabel()
        {
            this.labelsPage.Elements.EditExistingLabel.Click();
            this.labelsPage.Elements.CancelCreatingNewLabel.Click();
        }
    }
}
