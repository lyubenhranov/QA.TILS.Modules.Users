using System.Linq;
using System.Threading;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Win32.Dialogs;
using QA.Framework.Core.Base;
using QA.Framework.Core.Data.Templates;
using QA.TILS.Modules.Users.Core.SharedSteps;

namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Towns
{
    public class TownsPage : BasePage
    {
        public TownsPage()
        {
            this.Validator = new TownsPageValidator();
            this.Elements = new TownsPageElements();
            this.Url = "/Administration_Users/Provinces";
        }

        public TownsPageValidator Validator { get; private set; }

        public TownsPageElements Elements { get; private set; }

        public void CreateTown(Town town)
        {
            this.Elements.AnchorAddNewTown.Click();
            this.Elements.NameBulgarian.Text = town.BulgarianName;
            this.Elements.NameBulgarian.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);
            this.Elements.NameEnglish.Text = town.EnglishName;
            this.Elements.NameEnglish.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);
            this.Elements.UpdateButton.MouseClick();
            this.Elements.UpdateButton.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.click);
        }

        public void DeleteTown(Town town)
        {
            var table = this.Elements.TheGid;
            var row = table.Rows.FirstOrDefault(x => x.InnerText.Contains(town.BulgarianName));

            if (row != null)
            {
                var element = row.Cells[5].Find.ByAttributes<HtmlAnchor>("class=k-button k-button-icontext k-grid-delete");
                Manager.Current.DialogMonitor.AddDialog(new AlertDialog(Manager.Current.ActiveBrowser, DialogButton.OK));
                Manager.Current.DialogMonitor.Start();
                element.Click();
            }
        }

        public void EditTown(Town town, Town other)
        {
            var table = this.Elements.TheGid;
            var row = table.Rows.FirstOrDefault(x => x.InnerText.Contains(town.BulgarianName));

            if (row != null)
            {
                var element = row.Cells[4].Find.ByAttributes<HtmlAnchor>("class=k-button k-button-icontext k-grid-edit");
                element.Click();

                this.Elements.NameBulgarian.Text = other.BulgarianName;
                this.Elements.NameBulgarian.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);

                this.Elements.NameEnglish.Text = other.EnglishName;
               
                this.Elements.NameEnglish.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);
                Thread.Sleep(5000);
                this.Elements.UpdateButton.MouseClick();
                this.Elements.UpdateButton.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.click);
            }
        }
    }
}
