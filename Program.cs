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
            sourceProgram spr = new sourceProgram();
            spr.RE(122);
            
            /**
            
            //integer regex
            Regex integer = new Regex(@"^[-+]?\d*$");
            Match result = integer.Match("-255");

            if (result.Success)
            {
                Console.WriteLine("This is an Integer number: " + result.Value);
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
            
            //floating point
            Regex floating_num = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            Match float_output = floating_num.Match("223");

            if (float_output.Success)
            {
                Console.WriteLine("This is a float number: " + float_output.Value);
            }
            else
            {
                Console.WriteLine("Invalid Float number");
            }

            //char regex
            String originalData = "a";
            foreach (Match m in Regex.Matches(originalData, @"[a-zA-Z]{1}")) 
            Console.WriteLine("This a char: '{0}' ", m.Value, m.Index);

            //id regex
            
            
            
            **/
            
        }
    }
    public class sourceProgram{

         public void RE(var input){
            Regex integer = new Regex(@"^[-+]?\d*$");
            Match result = integer.Match(input);

            if (result.Success)
            {
                Console.WriteLine("This is an Integer number: " + result.Value);
            }
            else if (result.Success != true){

                Regex floating_num = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
                Match float_output = floating_num.Match(input);

                if (float_output.Success)
                {
                Console.WriteLine("This is a float number: " + float_output.Value);
                } 
                else{
                    String originalData = input;
                    foreach (Match m in Regex.Matches(originalData, @"[a-zA-Z]{1}")) 
                    Console.WriteLine("This a char: '{0}' ", m.Value, m.Index);
                }
            }
        }

    }
}
