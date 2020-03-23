namespace RyanPenfold.Utilities.Net
{
    using System.IO;
    using System.Net;

    public class IpAddress
    {
        public static string GetLocalIpAddress()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new System.Exception("Local IP Address Not Found!");
        }

        public static string GetPublicIpAddress()
        {
            var url = "http://checkip.dyndns.org";
            var req = WebRequest.Create(url);
            var resp = req.GetResponse();
            var sr = new StreamReader(resp.GetResponseStream());
            var response = sr.ReadToEnd().Trim();
            var a = response.Split(':');
            var a2 = a[1].Substring(1);
            var a3 = a2.Split('<');
            return a3[0];
        }
    }
}
