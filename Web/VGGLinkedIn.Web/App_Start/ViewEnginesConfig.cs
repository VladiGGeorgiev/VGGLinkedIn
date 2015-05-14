namespace VGGLinkedIn.Web
{
    using System.Web.Mvc;

    public static class ViewEnginesConfig
    {
        public static void RegisterEngines(ViewEngineCollection viewEngines)
        {
            viewEngines.Clear();
            viewEngines.Add(new RazorViewEngine());
        }
    }
}