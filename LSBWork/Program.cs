using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSBWork
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Controler controler = new Controler();
            controler.Start();
            Console.WriteLine("\nNhan Enter de tiep tuc");
            Console.ReadKey();

        }
    }
}
