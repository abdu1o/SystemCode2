using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCode2
{
    public class Program
    {
        static Process subProcess;

        public static void OpenTask(string path)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    Console.WriteLine("Enter to close");
                    Console.ReadKey();

                    process.Kill();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public static void StartSubProcess(string path)
        {
            subProcess = new Process();
            subProcess.StartInfo.FileName = path;
            subProcess.Start();
            Console.WriteLine("Sub process started");
        }

        static void WaitForSubProcess()
        {
            subProcess.WaitForExit();
            Console.WriteLine($"Sub process ended: {subProcess.ExitCode}");
        }

        static void KillSubProcess()
        {
            subProcess.Kill();
            Console.WriteLine("Sub process killed");
        }

        static void Main(string[] args)
        {
            OpenTask("notepad.exe");

            StartSubProcess("notepad.exe");

            Console.WriteLine("[1] Wait for sub code ending ");
            Console.WriteLine("[2] Permanently end sub code ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WaitForSubProcess();
                    break;
                case "2":
                    KillSubProcess();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

        }
    }
}
