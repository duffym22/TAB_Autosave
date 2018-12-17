using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TAB_Autosave
{
    class Program
    {
        static string _TAB_SAVE; // = @"C:\Users\Matthew\Documents\my games\They Are Billions\Saves";
        static int _DELAY_TIME; // = 5";
        static void Main(string[] args)
        {
            if (args == null || args.Length.Equals(0))
            {
                Console.WriteLine("NO ARGS SPECIFIED");
                Console.WriteLine("Program needs Path and Delay time specified. Program will now terminate");
            }
            else if ( args.Length < 2)
            {
                Console.WriteLine("MISSING ARGS");
                Console.WriteLine("Program needs both Path and Delay time specified. Program will now terminate");
            }
            else
            {
                Console.WriteLine(string.Format("Args specified: {0}", args.Length));
                for (int i = 0; i < args.Length; i++)
                {
                    string[] argument = args[i].ToUpper().Split('=');

                    switch(argument[0])
                    {
                        case "PATH":
                            _TAB_SAVE = argument[1];
                            break;
                        case "DELAY":
                            _DELAY_TIME = Convert.ToInt32(argument[1]);
                            break;
                    }
                }

                if (Directory.Exists(_TAB_SAVE))
                {
                    Console.WriteLine("Save directory exists!");
                    while (true)
                    {
                        CopyFolder();
                    }

                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static void CopyFolder()
        {
            string destLoc = string.Empty;
            try
            {
                destLoc = string.Format("{0}_{1}", _TAB_SAVE, DateTime.Now.ToString("yyyyMMdd_hhmmss"));
                Directory.CreateDirectory(destLoc);
                string[] files = Directory.GetFiles(_TAB_SAVE);
                foreach (string s in files)
                {
                    File.Copy(s, Path.Combine(destLoc, Path.GetFileName(s)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to complete copy operation");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);
                return;
            }
            Console.WriteLine(string.Format("Save copy complete - {0} | Sleeping for {1} minutes", destLoc, _DELAY_TIME));
            Thread.Sleep(_DELAY_TIME * 60000);
        }
    }
}
