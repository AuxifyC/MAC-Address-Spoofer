using Microsoft.Win32;
using System;
using System.Net;

using System.Threading;

namespace Login
{
    public class mTasks
    {

        public string ReadMAC()
        {
            RegistryKey rkey;
            string MAC;
            try
            {
                rkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\0012", true); //--->this is the string to change 
                MAC = (string)rkey.GetValue("NetworkAddress");
                rkey.Close();
                return MAC;
            }
            catch
            {
                Console.WriteLine("[X] Run As Admin",Console.ForegroundColor = ConsoleColor.Red);
                Thread.Sleep(2000);
                System.Environment.Exit(0);
                return "";
            }
        }
        public string GetKeys(string url)
        {
            WebClient wc = new WebClient();
            try
            {
                string dKeys = wc.DownloadString(url);
                return dKeys;
            }
            catch
            {
                Thread.Sleep(1000);
                System.Environment.Exit(0);
                return "";

            }
        }
        public void ChangeMac(string newMAC)
        {
            RegistryKey rkey;
            try
            {
                rkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\0012", true);
                rkey.SetValue("NetworkAddress", newMAC);
                rkey.Close();
            }
            catch
            {
                Console.WriteLine("[X] Run As Admin", Console.ForegroundColor = ConsoleColor.Red);
                Thread.Sleep(2000);
                System.Environment.Exit(0);
            }
        }
    }
}