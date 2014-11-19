namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Roles
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data.Templates;

    public class RolesPageValidator : BasePageValidator
    {
        public void ValidateRoleExist(Role role)
        {
            var text = Manager.Current.ActiveBrowser.ViewSourceString;
            bool result = text.Contains(role.Name);
            Assert.IsTrue(result);
        }

        public void ValidateRoleDoesNotExist(Role role)
        {
            var text = Manager.Current.ActiveBrowser.ViewSourceString;
            bool result = text.Contains(role.Name);
            Assert.IsFalse(result);
        }
    }
}
