using System;
using System.Diagnostics;

namespace svn
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"F:\资料\yiliaojigou";

            string username = "lichen";

            string password = "lc123";



            Process p = new Process();
            ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = @"cmd.exe ";
            //startInfo.Arguments = " /c svn update " + path + " --username mashenghao --password mashenghao ";
            p.StartInfo = startInfo;
            p.Start();
            p.StandardInput.WriteLine("svn update " + path + " --username " + username + " --password " + password + " &exit ");
            p.StandardInput.AutoFlush = true;
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
        }
    }
}
