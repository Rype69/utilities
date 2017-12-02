/*
namespace RyanPenfold.Utilities.Net.NetworkInformation
{
    public class Ping
    {
        public static bool Send(string nameOrAddress)
        {
            var pingable = false;
            var pinger = new System.Net.NetworkInformation.Ping();
            try
            {
                var reply = pinger.Send(nameOrAddress);
                pingable = reply?.Status == System.Net.NetworkInformation.IPStatus.Success;
            }
            catch (System.Net.NetworkInformation.PingException)
            {
                // Discard PingExceptions and return false;
            }

            return pingable;
        }
    }
}
*/