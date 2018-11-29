using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public static class RPC
    {
        private static DiscordRpcClient client;

        public static void Initialize()
        {
            client = new DiscordRpcClient("517622150618677248");

            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning, Colored = true, Coloured = true };

            client.OnReady += (sender, e) =>
            {
                Console.WriteLine($"Recieved Ready from user {e.User.Username}");
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine($"Recieved update! {e.Presence}");
            };

            client.Initialize();
            
        }

        public static void Dispose()
        {
            client.Dispose();
        }

        public static void ForceUpdate()
        {
            client.Invoke();
        }

        public static void SetPresence(string detail, string state, string largeImageKey = "", string largeImageText = "")
        {

            if(largeImageKey != "")
            {

                client.SetPresence(new RichPresence()
                {
                    Details = detail,
                    State = state,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeImageKey,
                        LargeImageText = largeImageText
                    }
                });
            }
            else
            {
                client.SetPresence(new RichPresence()
                {
                    Details = detail,
                    State = state
                });
            }

        }
    }
}
