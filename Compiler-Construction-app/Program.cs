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
            //Program Start here
            for(int i=0; i<100; i++){
                 Console.Write("Enter Your Valid Syntax: ");
                 string name = Console.ReadLine();
                 regularExpression(name);
            }

            /*string enter = "Enter your name";
            string[] text = enter.Split(' ');

            string[] A = [ "hello", "hi", "bye", "voice" ];
            Console.WriteLine(A);
            foreach (string i in text)
            {
               
                Console.WriteLine(i);
            }
            Console.WriteLine(text);*/

           // Console.ReadLine();
        }

        //Regular Function to check syntax
        public static void regularExpression(string name)
        {
            bool integerNum = integerFunction(name);
            bool floatingNum = floatFunction(name);
            bool identifier = identifierFunction(name);
            bool keyword = CheckKeyword(name);

            if (integerNum)
                Console.WriteLine(name + "------>: Integer");
            else if (floatingNum)
                Console.WriteLine(name + "------>: Float Number");
            else if (identifier)
                Console.WriteLine(name + "------->: Identifier");
            else if (keyword)
                Console.WriteLine(name + "------>: Keyword");
            else
                Console.WriteLine("Invalid Syntax");
        }

        //Function for identifier number
        public static bool identifierFunction(string name)
        {
            Regex indentifier = new Regex(@"^[a-zA-Z_]+[a-zA-Z0-9_]");
            Match check = indentifier.Match(name);

            bool identifier = CheckKeyword(name);

            if (check.Success && !identifier)
                return true;
            else
                return false;
        }

        //Function for Integer number
        public static bool integerFunction(string name)
        {
            Regex integer = new Regex(@"^[-+]?\d*$");
            Match result = integer.Match(name);

            if (result.Success)
                return true;
            else
                return false;
        }
        
        //Function for Floating number
        public static bool floatFunction(string name)
        {
            Regex floating_num = new Regex(@"^[-+]?([0-9]*|\d*\.\d{1}?\d*)$");
            Match float_output = floating_num.Match(name);

            if (float_output.Success)
                return true;
            else
                return false;
        }

        // Function for Keyword Checker
        public static bool CheckKeyword(string name)
        {

            string[] keywords = { "abstract", "as", "base", "bool", "break", "by",
            "byte", "case", "catch", "char", "checked", "class", "const",
            "continue", "decimal", "default", "delegate", "do", "double",
            "descending", "explicit", "event", "extern", "else", "enum",
            "false", "finally", "fixed", "float", "for", "foreach", "from",
            "goto", "group", "if", "implicit", "in", "int", "interface",
            "internal", "into", "is", "lock", "long", "new", "null", "namespace",
            "object", "operator", "out", "override", "orderby",  "params",
            "private", "protected", "public", "readonly", "ref", "return",
            "switch", "struct", "sbyte", "sealed", "short", "sizeof",
            "stackalloc", "static", "string", "select",  "this",
            "throw", "true", "try", "typeof", "uint", "ulong", "unchecked",
            "unsafe", "ushort", "using", "var", "virtual", "volatile",
            "void", "while", "where", "yield" };

            int flag = 0;

            for (int i = 0; i < keywords.Length; i++)
            {
                string name2 = keywords[i];
                if (name2 == name)
                {
                    // Console.WriteLine("It is a Keyword");
                    flag = 1;
                }
            }
            if (flag == 1)
                return true;
            else
                return false;


        }
    }
}
