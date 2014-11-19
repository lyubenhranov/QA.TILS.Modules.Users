namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Towns
{
    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data.Templates;

    public class TownsPageValidator : BasePageValidator
    {
        private const string EnglishNameIsRequiredMessage = "The Име на областта(Англ) field is required.";
        private const string BulgarianNameIsRequiredMessage = "The Име на областта(Бг) field is required.";
        private const string InvalidEnglishNameMessage = "Полето не може да съдържа кирилица!";
        private const string InvalidBulgarianNameMessage = "Полето съдържа латински символи!";

        public void ValidateTownExist(Town town)
        {
            var text = Manager.Current.ActiveBrowser.ViewSourceString;
            bool result = text.Contains(town.BulgarianName);
            Assert.IsTrue(result);
        }

        public void ValidateRequiredEnglishNameMessage(HtmlDiv htmlDiv)
        {
            var innerText = htmlDiv.InnerText;
            var result = innerText.Contains(EnglishNameIsRequiredMessage);
            Assert.IsTrue(result);
        }

        public void ValidateRequiredBulgarianhNameMessage(HtmlDiv htmlDiv)
        {
            var innerText = htmlDiv.InnerText;
            var result = innerText.Contains(BulgarianNameIsRequiredMessage);
            Assert.IsTrue(result);
        }

        public void ValidateInvalidEnglishNameMessage(HtmlDiv htmlDiv)
        {
            var innerText = htmlDiv.InnerText;
            var result = innerText.Contains(InvalidEnglishNameMessage);
            Assert.IsTrue(result);
        }

        public void ValidateInvalidBulgarianNameMessage(HtmlDiv htmlDiv)
        {
            var innerText = htmlDiv.InnerText;
            var result = innerText.Contains(InvalidBulgarianNameMessage);
            Assert.IsTrue(result);
        }

        public void ValidateTownDoesNotExist(Town town)
        {
            var text = Manager.Current.ActiveBrowser.ViewSourceString;
            bool result = text.Contains(town.BulgarianName);
            Assert.IsFalse(result);
        }
    }
}
