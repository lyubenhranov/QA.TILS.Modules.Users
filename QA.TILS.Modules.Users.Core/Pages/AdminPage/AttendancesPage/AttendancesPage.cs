using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Win32.Dialogs;
using QA.Framework.Core.Base;
using QA.Framework.Core.Data.Templates;
using QA.TILS.Modules.Users.Core.SharedSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.AttendancesPage
{
    public class AttendancesPage : BasePage
    {
        private const string PageUrl = @"/Administration_Users/AttendanceLogs";

        public AttendancesPage()
        {
            this.Elements = new AttendancesPageElements();
            this.Validator = new AttendancesPageValidator(this);
            this.Url = PageUrl;
        }

        public AttendancesPageElements Elements { get; private set; }

        public AttendancesPageValidator Validator { get; private set; }

        public void NavigateToPageAsAdmin()
        {
            LoginSteps.LoginAdmin();
            this.NavigateTo();
        }

        public void AddAttendance(User user, string dateAndTimeOfAttendance)
        {
            this.Elements.AddAttendanceButton.Wait.ForExists();
            this.Elements.AddAttendanceButton.Click();

            this.Elements.DeviceDropDown.Wait.ForExists();
            this.Elements.DeviceDropDown.Click();

            this.Elements.AttendanceDevice.MouseClick();

            this.Elements.User.Text = user.Username;
            this.Elements.User.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);
            this.Elements.User.MouseClick();
            this.Elements.User.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.keyup);

            this.Elements.AttendanceDate.MouseClick();
            this.Elements.AttendanceDate.Text = "10/10/2014 10:00:00";

            this.Elements.UpdateAttendanceButton.Click();
        }

        public void DeleteMostRecentAttendance(bool confirmDeletion)
        {
            Manager.Current.ActiveBrowser.Refresh();
            AlertDialog alert;
            if (confirmDeletion)
            {
                alert = AlertDialog.CreateAlertDialog(Manager.Current.ActiveBrowser, DialogButton.OK);
            }
            else
            {
                alert = AlertDialog.CreateAlertDialog(Manager.Current.ActiveBrowser, DialogButton.CANCEL);
            }
            Manager.Current.DialogMonitor.AddDialog(alert);
            Manager.Current.DialogMonitor.Start();
            this.Elements.DeleteFirstAttendance.MouseClick();
            alert.WaitUntilHandled();
            Manager.Current.DialogMonitor.RemoveDialog(alert);
            Manager.Current.DialogMonitor.Stop();
        }
    }
}
