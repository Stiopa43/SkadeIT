using NetworkUtility.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS dNS;

        public NetworkService(IDNS dNS)
        {
            this.dNS = dNS;
        }
        public string SendPing()
        {
            var dnsSuccess = dNS.SendDNS();
            if (dnsSuccess)
                return "Success: Ping sent!";
            else
                return "Failed: Ping is not sent!";
        }
        public int PingTimeout(int a, int b)
        {
            return a + b;
        }
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }
        public PingOptions GetPingOptions()
        {
            return new PingOptions() 
            {
                DontFragment = true,
                Ttl = 1
            };
        }
        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pings = new[] 
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 2
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 3
                }
            };
            return pings;
        }
    }
}
