using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAB_Autosave
{
    class Program
    {
        static string _TAB_SAVE = @"C:\Users\Matthew\Documents\my games\They Are Billions\Saves";
        static void Main(string[] args)
        {
            if(Directory.Exists(_TAB_SAVE))
            {
                Console.WriteLine("Directory exists!");
                while(true)
                {
                    CopyFolder();
                }

            }
            Console.WriteLine("Exiting program");
            Console.ReadLine();
        }

        private static void CopyFolder()
        {
            try
            {
                Console.WriteLine("Copying saves");
                string destLoc = string.Format("{0}_{1}", _TAB_SAVE, DateTime.Now.ToString("yyyyMMdd_hhmmss"));
                Directory.CreateDirectory(destLoc);
                Console.WriteLine("Created directory: " + destLoc);
                string[] files = Directory.GetFiles(_TAB_SAVE);
                foreach (string s in files)
                {
                    File.Copy(s, Path.Combine(destLoc, Path.GetFileName(s)));
                }
                Console.WriteLine("Copy complete");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to complete copy operation");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);
            }
            Console.WriteLine("Sleeping for 5 minutes");
            System.Threading.Thread.Sleep(300000);
        }
    }
}
