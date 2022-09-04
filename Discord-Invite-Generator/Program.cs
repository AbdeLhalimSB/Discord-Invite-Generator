using System;
using System.Net;
using DiscordWebhook;

namespace Discord_Invite_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            sendinvitetodiscord("Start");
            Console.Write("Invites Count : ");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count-1; i++)
            {
                string invite = invite_generator();
                Console.WriteLine("discord.gg/"+invite);
                if (Invite_tester(invite) == true)
                {
                    sendinvitetodiscord(invite);
                }
                System.Threading.Thread.Sleep(1000);
            }

        }
        

    public static string invite_generator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[7];
            var random = new Random();

            for (int i = 0; i < 7; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public static bool Invite_tester(string invite)
        {
            try
            {
                WebRequest request = WebRequest.Create("https://discordapp.com/api/invites/" + invite);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Console.WriteLine("Invite link is valid");
                    return true;
                }
            }
            catch (WebException wex)
            {
                if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    //Console.WriteLine("Invite link is invalid");
                    return false;
                }
                else
                {
                    Console.WriteLine(wex.ToString().Substring(':','.'));
                }
            }
            return false;
        }

        static void sendinvitetodiscord(string invite)
        {
            Webhook webhook = new Webhook("https://discord.com/api/webhooks/1016063201235980378/U5sMlLIRIu-DngUqgt54aiKN8u1XZRtWNHISZwKzSXcRYN9xAeT59yMRwBTo8OXQbm-_");
            WebhookObject obj = new WebhookObject()
            {
                username = "AbdeLhalim",
                content = "discord.gg/"+invite
            };
            webhook.PostData(obj);
        }

    }
}
