using System.IO;
using System.Reflection;

namespace DungeonCrawler
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        private static string directory = Directory.GetCurrentDirectory();
        public static readonly string ImagePath = Path.Combine(directory.Substring(0, directory.IndexOf("\\bin")), "GUI\\images");
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new DungeonCrawler());
        }
    }
}