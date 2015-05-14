namespace VGGLinkedIn.Web.Areas.Administration.ViewModels.Dashboard
{
    public class DashboardItemViewModel
    {
        public DashboardItemViewModel(string title, string link)
        {
            this.Title = title;
            this.Link = link;
        }

        public string Title { get; set; }

        public string Link { get; set; }
    }
}