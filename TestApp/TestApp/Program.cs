using System.Net;

class Program
{
    static void Main()
    {
        var site = "https://dzen.ru/?clid=2255624&from=dist_bookmark&win=279&yredirect=true";
        var available = SiteAvailability(site);
        Console.Write($"Site {site}: {(available ? "OK" : "Not available")}");
    }

    private static bool SiteAvailability(string uri)
    {
        bool available;
        try
        {
            var request = WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            var response = (HttpWebResponse)request.GetResponse();
            available = response.StatusCode == HttpStatusCode.OK;
        }
        catch
        {
            available = false;
        }
        return available;
    }
}
