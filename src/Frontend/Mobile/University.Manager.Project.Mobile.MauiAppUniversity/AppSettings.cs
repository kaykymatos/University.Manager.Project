namespace University.Manager.Project.Mobile.MauiAppUniversity
{
    public class AppSettings
    {
        private static string DatabaseName = "database.db";
        private static string DatabaseDirectory = FileSystem.AppDataDirectory;
        public static string DatabasePath = Path.Combine(DatabaseDirectory, DatabaseName);
        public static bool OfflineTest = true;
    }
}
