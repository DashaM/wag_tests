using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using WAG_tests;


namespace WAG_fast
{
    public class Screenshot : TestBase
    {
        public static void Snap()
        {
            Trace.WriteLine("Create screenshot.", "StateS");
            CreateFileDirectory();
            SaveScreenshot();
        }

        public static void CreateFileDirectory()
        {
            string pathString = @"c:\Program Files (x86)\Jenkins\workspace\WAG_tests";

            bool dirExists = Directory.Exists(pathString);
            if (!dirExists)
                Directory.CreateDirectory(pathString);
        }

        public static void SaveScreenshot()
        {
            String filename = @"c:\Program Files (x86)\Jenkins\workspace\WAG_tests-FAST\" + "snapshot" + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss") + ".png";
            ((ITakesScreenshot)firefox).GetScreenshot().SaveAsFile(filename, ImageFormat.Png);
        }


    }
}
