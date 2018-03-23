using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading;

namespace Lethia
{
    public class Program
    {
        private static MessageQueue messageQueue;

        public static MessageQueue MessageQueue { get => messageQueue; set => messageQueue = value; }

        public static void Main(string[] args)
        {
            MessageQueue = new MessageQueue();

            var awaiter = BuildWebHost(args).StartAsync();

            while (true)
            {
                ProcessMessageQueue();
                Thread.Sleep(100);
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        private static void ProcessMessageQueue()
        {
            MessageQueue.ProcessUnhandledReadMessages();
            MessageQueue.ProcessUnhandledEditMessages();
        }
    }
}
