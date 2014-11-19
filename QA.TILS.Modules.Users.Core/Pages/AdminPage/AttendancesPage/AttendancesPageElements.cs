using ArtOfTest.WebAii.Controls.HtmlControls;
using QA.Framework.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA.Framework.Core.Extensions;

namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.AttendancesPage
{
    public class AttendancesPageElements : BaseElementsMap
    {
        public HtmlDiv AllAttendancesGrid
        {
            get
            {
                return this.Find.ById<HtmlDiv>("DataGrid");
            }
        }

        public HtmlAnchor AddAttendanceButton
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("tagname=a", "class=k-button k-button-icontext k-grid-add");
            }
        }

        public HtmlAnchor EditAttendance
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("xpath=//*[@id='DataGrid']/table/tbody/tr[1]/td[6]/a");
            }
        }

        public HtmlAnchor DeleteFirstAttendance
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("xpath=//*[@id='DataGrid']/table/tbody/tr[1]/td[7]/a");
            }
        }

        public HtmlAnchor AttendanceWindow
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("tagname=div", "class=k-widget k-window");
            }
        }

        public HtmlSpan DeviceDropDown
        {
            get
            {
                return this.Find.ByExpression<HtmlSpan>("tagname=span", "class=k-dropdown-wrap k-state-default");
            }
        }

        public HtmlListItem AttendanceDevice
        {
            get
            {
                return this.Find.ById<HtmlUnorderedList>("DeviceId_listbox").Find.AllByExpression<HtmlListItem>("k-item".ToClassIsExpression()).LastOrDefault();
            }
        }

        public HtmlInputText User
        {
            get
            {
                return this.Find.ById<HtmlInputText>("Username");
            }
        }

        public HtmlInputText AttendanceDate
        {
            get
            {
                return this.Find.ById<HtmlInputText>("Time");
            }
        }

        public HtmlAnchor UpdateAttendanceButton
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("tagname=a", "class=k-button k-button-icontext k-grid-update");
            }
        }

        public HtmlAnchor CancelAttendanceButton
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("tagname=a", "class=k-button k-button-icontext k-grid-cancel");
            }
        }
    }
}
