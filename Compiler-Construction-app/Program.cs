using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Compiler_Construction_app
{
    class Program
    {
        static void Main(string[] args)
        {

            /*string enter = "Enter your name";
            string[] text = enter.Split(' ');

            string[] A = [ "hello", "hi", "bye", "voice" ];
            Console.WriteLine(A);
            foreach (string i in text)
            {
               
                Console.WriteLine(i);
            }
            Console.WriteLine(text);*/

            
            //integer regex
            Regex integer = new Regex(@"^[-+]?\d*$");
            Match result = integer.Match("-24");

            if (result.Success)
            {
                Console.WriteLine("This is an Integer number: " + result.Value);
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }

            Regex floating_num = new Regex(@"^[-+]?([0-9]*|\d*\.\d{1}?\d*)$");
            Match float_output = floating_num.Match("-0.2255");

            if (float_output.Success)
            {
                Console.WriteLine("This is a float number: " + float_output.Value);
            }
            else
            {
                Console.WriteLine("Invalid Float number");
            }



            Console.ReadLine();
        }
    }
}
