namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.AttendancesPage
{
    using ArtOfTest.WebAii.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using QA.Framework.Core.Extensions;

    public class AttendancesPageValidator
    {
        public AttendancesPageValidator(AttendancesPage initialAttendancesPage)
        {
            this.AttendancesPage = initialAttendancesPage;
        }

        public AttendancesPage AttendancesPage { get; set; }

        public void VerifyIfDateExists(string dateAndTime)
        {
            Manager.Current.ActiveBrowser.Refresh();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            this.AttendancesPage.Elements.AllAttendancesGrid.AssertTextIsContained(dateAndTime);
        }
    }
}
