using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace Compiler_Construction_app
{
    class Program
    {
        static void Main(string[] args)
        {



            //Program Start here
            /*Console.WriteLine("Enter 1 to continue or Enter 0 to leave: ");
            int inputCheck = Convert.ToInt32(Console.ReadLine());
            
            if(inputCheck==1){
               loop:
               for(int i=0; i<5; i++){
                     Console.Write("Enter Your Valid Syntax: ");
                     string name = Console.ReadLine();
                     regularExpression(name);
                     Console.WriteLine("Enter 0 to leave or Enter 1 to continue:");
                     
                      inputCheck = Convert.ToInt32(Console.ReadLine());
                      if(inputCheck==0){
                            Environment.Exit(0);
                      } else if(inputCheck==1){
                            goto loop;
                      } else{
                            Console.WriteLine("Enter a valid command: unkown command");
                      }                             
               } 
               
            } 
            else if(inputCheck==0){
                 Environment.Exit(0);
            } else{
                 Console.WriteLine("Enter a valid command: unkown command");
                  }      
             Console.WriteLine("Enter 1 to continue or Enter 0 to leave: ");
            int inputCheck = Convert.ToInt32(Console.ReadLine());
            
            if(inputCheck==1){
               loop:
               for(int i=0; i<5; i++){
                     Console.Write("Enter Your Valid Syntax: ");
                     string name = Console.ReadLine();
                     regularExpression(name);
                     Console.WriteLine("Enter 0 to leave or Enter 1 to continue:");
                     
                      inputCheck = Convert.ToInt32(Console.ReadLine());
                      if(inputCheck==0){
                            Environment.Exit(0);
                      } else if(inputCheck==1){
                            goto loop;
                      } else{
                            Console.WriteLine("Enter a valid command: unkown command");
                      }                             
               } 
               
            } 
            else if(inputCheck==0){
                 Environment.Exit(0);
            } else{
                 Console.WriteLine("Enter a valid command: unkown command");
                  } 
            */


            ArrayList wordBreaker = new ArrayList();
            string input = "iff(a>=5) { console.log(hunaid) ; }";
            string word = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    var num = numFunc(input, ref i);
                    wordBreaker.Add(num);
                }

                if (input[i] >= 'a' && input[i] <= 'z')
                {
                    var keyword = keyWordFun(input, ref i);
                    wordBreaker.Add(keyword);
                }

                if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/' || input[i] == '%' )
                {
                    var ope =  operatorFun(input, ref i);
                    wordBreaker.Add(ope);
                }
                
                if(input[i] == ';' || input[i] == '}' || input[i] == '{' || input[i] == '(' || input[i] == ')' || input[i] == ',' || input[i] == '$' || input[i] == '@')
                {
                    var ope = specialChar(input, ref i);
                    wordBreaker.Add(ope);
                }

                if (input[i] == '=' || input[i] == '<' || input[i] == '>')
                {
                    var assign = assignmentOperator(input, ref i);
                    wordBreaker.Add(assign);
                }

            }
            
            foreach(var item in wordBreaker)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }


        //assignmentOperator
        public static string assignmentOperator(string input, ref int i)
        {
            string assign = "";

            while(input[i] == '=' || input[i] == '<' || input[i] == '>')
            {
                if (input[i] == '=')
                {
                    var j = input[i];
                    assign = assign + j;
                    if (input[i + 1] == '=')
                    {
                        j = input[i];
                        assign = assign + j;
                        i++;
                        return assign;
                    }
                    else
                    {
                        return assign;
                    }
                }

                if (input[i] == '<')
                {
                    var j = input[i];
                    assign = assign + j;
                    if (input[i + 1] == '=')
                    {
                        j = input[i];
                        assign = assign + j;
                        i++;
                        return assign;
                    }
                    else
                    {
                        return assign;
                    }
                }

                if (input[i] == '>')
                {
                    var j = input[i];
                    assign = assign + j;
                    if (input[i + 1] == '=')
                    {
                        j = input[i];
                        assign = assign + j;
                        i++;
                        return assign;
                    }
                    else
                    {
                        return assign;
                    }
                }
            }

            i--;
            return assign;
            
        }


        //special character
        public static string specialChar(string input, ref int i)
        {
            string ope = "";
            while (input[i] == ';' || input[i] == '{' || input[i] == '}' || input[i] == '(' || input[i] == ')' || input[i] == ',' || input[i] == '$' || input[i] == '@')
            {
                
                var j = input[i];
                ope = ope + j;
                i++;

                

                if (i < input.Length)
                {
                    continue;
                }else
                {
                    break;
                }
                
            }
            i--;
            return ope;
        }

        //operator 
        public static string operatorFun(string input, ref int i)
        {
            string ope = "";
            while(input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/' || input[i] == '%')
            {
                if(input[i] == '+')
                {
                    var j = input[i];
                    ope = ope + j;
                    if (input[i+1] == '+')
                    {
                         j = input[i];
                        ope = ope + j;
                        i++;
                        return ope;
                    }
                    else
                    {
                        return ope;
                    }
                }
                if (input[i] == '-')
                {
                    var j = input[i];
                    ope = ope + j;
                    if (input[i + 1] == '-')
                    {
                        j = input[i];
                        ope = ope + j;
                        i++;
                        return ope;
                    }
                    else
                    {
                        return ope;
                    }
                }
                if(input[i] == '*')
                {
                    var j = input[i];
                    ope = ope + j;
                    return ope;
                }
                if (input[i] == '/')
                {
                    var j = input[i];
                    ope = ope + j;
                    return ope;
                }
                if (input[i] == '%')
                {
                    var j = input[i];
                    ope = ope + j;
                    return ope;
                }

            }
            i--;
            return ope;
        }



        //for keyword
        public static string keyWordFun(string input, ref int i)
        {
            string word = "";
            while (input[i] >= 'a' && input[i] <= 'z' || input[i] >= '0' && input[i] <= '9')
            {
                var j = input[i];
                word = word + j;
                i++;
                if (i < input.Length)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            return word;
        }

        //number breaker
        public static string numFunc(string input, ref int i)
        {
            string num = "";
            while (input[i] >= '0' && input[i] <= '9' || input[i] == '.' || input[i] == ',')
            {
                var j = input[i];
                num = num + j;
                i++;
                if (i < input.Length)
                {
                    continue;
                }
                else
                {
                    break;
                }
                
            }
            return num;
        }

        //Regular Function to check syntax
        public static void regularExpression(string name)
        {
            bool integerNum = integerFunction(name);
            bool floatingNum = floatFunction(name);
            bool identifier = identifierFunction(name);
            bool keyword = CheckKeyword(name);
            bool objAlphaPattern = IsAlpha(name);

            if (integerNum)
                Console.WriteLine(name + "------>: Integer");
            else if (floatingNum)
                Console.WriteLine(name + "------>: Float Number");
            else if (identifier)
                Console.WriteLine(name + "------->: Identifier");
            else if (keyword)
                Console.WriteLine(name + "------>: Keyword");
            else if (objAlphaPattern)
                Console.WriteLine(name + "------>: char");
            else
                Console.WriteLine("Invalid Syntax");
        }

        //Function for identifier number
        public static bool identifierFunction(string name)
        {
            Regex indentifier = new Regex(@"^[a-zA-Z_]+[a-zA-Z0-9_]*$");
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


        // Function To test for char constant
        public static bool IsAlpha(string name)  
        {  
            Regex objAlphaPattern = new Regex(@"^'[/]?[a-zA-Z0-9@%$#!^(){}]'");  
         // return !objAlphaPattern.IsMatch(name);  
            Match result = objAlphaPattern.Match(name);
             
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
