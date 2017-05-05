using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace maps
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }

        public static string PasswordInput()
        {
            string pass = "";
            
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Spacebar)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return pass;
        }

        public static void YesNoSelect()
        {
            Console.WriteLine("Y/N");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar.Equals('y'))
            {
                Console.Write("\b \b");
                Console.WriteLine("you selected Yes");
            }
            else if (key.KeyChar.Equals('n'))
            {
                Console.Write("\b \b");
                Console.WriteLine("you selected No");
            }
            else
            {
                Console.Write("\b \b");
                Console.WriteLine("Select Yes or No");
            }
        }
    }
}
