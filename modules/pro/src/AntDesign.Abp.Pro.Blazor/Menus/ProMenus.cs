namespace AntDesign.Abp.Pro.Blazor.Menus
{
    public class ProMenus
    {
        private const string Prefix = "Template";
        public const string Dashboard = Prefix + ".Dashboard";
        public const string DashboardAnalysis = Dashboard + ".Analysis";
        public const string DashboardMonitor = Dashboard + ".Monitor";
        public const string DashboardWorkplace = Dashboard + ".Workplace";

        public const string Form = Prefix + ".Form";
        public const string FormBasic = Form + ".Basic";
        public const string FormStep = Form + ".Step";
        public const string FormAdvanced = Form + ".Advanced";

        public const string List = Prefix + ".List";
        public const string ListSearch = List + ".Search";
        public const string ListSearchArticles = ListSearch + ".Articles";
        public const string ListSearchProjects = ListSearch + ".Projects";
        public const string ListSearchApplications = ListSearch + ".Applications";
        public const string ListTable = List + ".Table";
        public const string ListBasic = List + ".Basic";
        public const string ListCard = List + ".Card";

        public const string Profile = Prefix + ".Profile";
        public const string ProfileBasic = Profile + ".Basic";
        public const string ProfileAdvanced = Profile + ".Advanced";

        public const string Result = Prefix + ".Result";
        public const string ResultSuccess = Result + ".Success";
        public const string ResultFail = Result + ".Fail";

        public const string Exception = Prefix + ".Exception";
        public const string Exception403 = Exception + ".403";
        public const string Exception404 = Exception + ".404";
        public const string Exception500 = Exception + ".500";

        public const string Account = Prefix + ".Account";
        public const string AccountCenter = Prefix + ".Center";
        public const string AccountSettings = Prefix + ".Settings";
        //Add your menu items here...

    }
}