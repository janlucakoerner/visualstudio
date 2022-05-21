using Cashsystem.Forms;
using Cashsystem.Math;

namespace Cashsystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(FormSingleton.GetInstance().FormStart);

            var frac1 = new Fraction("50/10");
            var frac2 = new Fraction("\frac{50}{10}");
            var frac3 = frac1 + frac2;
            var frac4 = frac1 - frac2;
            var frac5 = frac1 * frac2;
            var frac6 = frac1 / frac2;
            Console.WriteLine(frac1);
        }
    }
}