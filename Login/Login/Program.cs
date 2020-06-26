using System;
using System.Net.Configuration;
using System.Threading;



namespace Login
{
    class Program
    {

        static void Main(string[] args)
        {
            // Initilization
            Console.Title = "Auxify's MAC Address Spoofer";
            mTasks MAC = new mTasks();

            // Getting Valid Keys
            string dKeys = MAC.GetKeys("https://pastebin.com/raw/EX4zuxJS");

            // Getting User's Key
            Console.Write("Enter Your Key : ", Console.ForegroundColor = ConsoleColor.Blue);
            string uKey = Console.ReadLine();

            // Checking If User's Key Is Valid
            if (dKeys.Contains(uKey))
            {
                Console.Clear();
                Console.WriteLine("[!] Key Valid", Console.ForegroundColor = ConsoleColor.Green);
                Thread.Sleep(1000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("[X] Key Invalid",Console.ForegroundColor = ConsoleColor.Red);
                Thread.Sleep(1000);
                System.Environment.Exit(0);
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            string uMAC = MAC.ReadMAC();
            Console.WriteLine("Current MAC Address : " + uMAC);
            Thread.Sleep(2000);
            Console.Write("Do You Want To Change MAC Address ? {Y / N} : ");
            string ans = Console.ReadLine();
            Console.Clear();
            ans = ans.ToLower();
            if(ans == "y")
            {
                Console.Write("Enter Your New MAC Address : ");
                string nMAC = Console.ReadLine();
                MAC.ChangeMac(nMAC);
                Console.Clear();
                string cMAC = MAC.ReadMAC();
                Console.WriteLine("Current MAC Address : " + cMAC);
                Thread.Sleep(3000);
                System.Environment.Exit(0);
            }
            if(ans == "n")
            {
                Thread.Sleep(1000);
                System.Environment.Exit(0);
            }
        }

    }
}
