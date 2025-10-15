namespace PROG7312_WFP
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Load sample issues on startup
            IssueSampleData.InitializeSampleIssueData();

            Application.Run(new Form1());
        }
    }
}