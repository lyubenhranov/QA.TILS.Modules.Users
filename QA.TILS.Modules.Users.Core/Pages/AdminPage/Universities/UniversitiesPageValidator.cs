namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Universities
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data.Templates;

    public class UniversitiesPageValidator : BasePageValidator
    {
        public void ValidateUniversityExist(University university)
        {
            var text = Manager.Current.ActiveBrowser.ViewSourceString;
            bool result = text.Contains(university.Name);
            Assert.IsTrue(result);
        }

        public void ValidateUniversityDoesNotExist(University university)
        {
            var text = Manager.Current.ActiveBrowser.ViewSourceString;
            bool result = text.Contains(university.Name);
            Assert.IsFalse(result);
        }
    }
}
