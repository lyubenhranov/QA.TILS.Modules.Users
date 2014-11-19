namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Labels
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class LabelsPageValidator
    {
        public LabelsPageValidator(LabelsPage page)
        {
            this.Page = page;
        }

        public LabelsPage Page { get; private set; }

        public void VerifyLabelIsPresent(string labelName)
        {
            var text = Manager.Current.ActiveBrowser.ViewSourceString;
            bool result = text.Contains(labelName);
            Assert.IsTrue(result);
        }
    }
}
