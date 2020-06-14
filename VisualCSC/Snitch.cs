using System;
using System.Net.Http;
using System.Timers;

namespace VisualCSC
{
    public static class Snitch
    {
        static readonly string url = "https://nosnch.in/11d46fd3a1";
        static System.Timers.Timer aTimer = new System.Timers.Timer(1000 * 60 * 60); //one hour in milliseconds
        
        private static void SendHeartbeat(object source, ElapsedEventArgs e)
        {
            Send("Heartbeat check: Lookin' good!");
        }

        public static void Send(string messageStr)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var message = string.Format("On machine: {0} \n {1} \n", Environment.MachineName, messageStr);
                    var responseString = client.GetStringAsync(url + "?m=" + message).Result;
                }
                catch (Exception e)
                {

                }
            }
        }
        public static void StartHeartbeating()
        {
            aTimer.Elapsed += new ElapsedEventHandler(SendHeartbeat);
            aTimer.Start();
        }
    }
}
