namespace University.Manager.Project.Mobile.MauiAppUniversity.Util
{
    public class ConnectionVerify
    {
        public static NetworkAccess GetInternetConnection()
        {
            return Connectivity.Current.NetworkAccess;
        }
    }
}
