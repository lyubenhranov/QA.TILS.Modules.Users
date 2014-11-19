using System.Threading;

namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Universities
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.SharedSteps;
    using System.Linq;

    public class UniversitiesPage : BasePage
    {
        public UniversitiesPage()
        {
            this.Validator = new UniversitiesPageValidator();
            this.Elements = new UniversitiesPageElements();
            this.Url = "/Administration_Users/Universities";
        }

        public UniversitiesPageValidator Validator { get; private set; }

        public UniversitiesPageElements Elements { get; private set; }

        public void CreateUniversity(University university)
        {
            this.Elements.AnchorAddNewTown.Click();

            this.Elements.Name.Text = university.Name;
            this.Elements.Name.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);

            this.Elements.Website.Text = university.WebPage;
            this.Elements.Website.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);

            this.Elements.UpdateButton.MouseClick();
            this.Elements.UpdateButton.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.click);
        }

        public void DeleteUniversity(University university)
        {
           
            this.Elements.TheGridLastPAge.Click();
          
            Thread.Sleep(5000);
            var table = this.Elements.TheGrid;
            var row = table.Rows.FirstOrDefault(x => x.InnerText.Contains(university.Name));

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
