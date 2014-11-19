namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Labels
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;

    public class LabelsPageElements : BaseElementsMap
    {
        public HtmlAnchor AddNewLabelButton
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='LabelsGrid']/div[1]/a[1]");
            }
        }

        public HtmlAnchor EditExistingLabel
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='LabelsGrid'/table/tbody/tr[1]/td[6]/a[1]");
            }
        }

        public HtmlAnchor DeleteExistingLabel
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='LabelsGrid'/table/tbody/tr[1]/td[6]/a[2]");
            }
        }

        public HtmlAnchor SearchByLabel
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='LabelsGrid'/div[1]/a[3]");
            }
        }

        public HtmlInputText TypeNameOfTheLabel
        {
            get
            {
                return this.Find.ById<HtmlInputText>("Name");
            }
        }

        public HtmlInputRange PickLetteresColor
        {
            get
            {
                return this.Find.ByXPath<HtmlInputRange>("html/body/div[3]/div[2]/div/div[1]/div[4]/input");
            }
        }

        public HtmlInputRange PickBackgroundColor
        {
            get
            {
                return this.Find.ByXPath<HtmlInputRange>("html/body/div[3]/div[2]/div/div[1]/div[6]/input");
            }
        }

        public HtmlAnchor UpdateNewLabel
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("html/body/div[3]/div[2]/div/div[2]/a[1]");
            }
        }

        public HtmlAnchor CancelCreatingNewLabel
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("html/body/div[3]/div[2]/div/div[2]/a[2]");
            }
        }

        public HtmlDiv NewLabelValidationNameMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("Name_validationMessage");
            }
        }
    }
}
