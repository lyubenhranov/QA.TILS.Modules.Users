namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Roles
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.SharedSteps;
    using System.Linq;

    public class RolesPage : BasePage
    {
        public RolesPage()
        {
            this.Validator = new RolesPageValidator();
            this.Elements = new RolesPageElements();
            this.Url = "/Administration_Users/Roles";
        }

        public RolesPageValidator Validator { get; private set; }

        public RolesPageElements Elements { get; private set; }

        public void CreateRole(Role role)
        {
            this.Elements.AnchorAddNewRole.Click();
            this.Elements.Name.Text = role.Name;
            this.Elements.Name.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);
            this.Elements.UpdateButton.MouseClick();
            this.Elements.UpdateButton.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.click);
        }

        public void DeleteRole(Role role)
        {
            var table = this.Elements.TheGrid;
            var row = table.Rows.FirstOrDefault(x => x.InnerText.Contains(role.Name));

            if (row != null)
            {
                var element = row.Cells[5].Find.ByAttributes<HtmlAnchor>("class=k-button k-button-icontext k-grid-delete");
                Manager.Current.DialogMonitor.AddDialog(new AlertDialog(Manager.Current.ActiveBrowser, DialogButton.OK));
                Manager.Current.DialogMonitor.Start();

                element.Click();
            }
        }        
    }
}
