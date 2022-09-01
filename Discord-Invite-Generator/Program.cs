using System;
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Discord_Invite_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //for(int i = 0;i <100;i++)
            //{
                string invite = invite_generator();
            Console.WriteLine(invite);
            Console.WriteLine(Invite_tester("aazFggr"));
            System.Threading.Thread.Sleep(1000);
            //}
            //using (dWebHook dcWeb = new dWebHook())
            //{
            //    dcWeb.ProfilePicture = "https://ibb.co/LzTVk3t";
            //    dcWeb.UserName = "Bot";
            //    dcWeb.WebHook = "";
            //    dcWeb.SendMessage("Test");
            //}
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
                WebRequest request = WebRequest.Create("https://discordapp.com/api/invites/"+invite);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("Invite link is valid");
                    return true;
                }
            }
            catch (WebException wex)
            {
                if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Invite link is invalid");
                    return false;
                }
                else throw wex;
            }
            return false;
        }

    }
}
