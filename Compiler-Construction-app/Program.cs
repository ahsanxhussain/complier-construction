using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;

namespace Compiler_Construction_app
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList wordBreaker = new ArrayList();
            string filePath = @"C:\demo\file.txt";

            string input = @File.ReadAllText(filePath);
            //string input1 = File.ReadAllText(filePath);
            //Console.WriteLine(input1);
            //string word = "";

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    //for comments
                    if (input[i] == '/')
                    {
                        if (input[i + 1] == '/')
                        {
                            i += 2;
                            singleLineComments(input, ref i);
                        }
                        if (input[i + 1] == '*')
                        {
                            i += 2;
                            //doubleLineComments(ref input , ref i);
                        }
                    }
                    if(input[i] == '"')
                    {
                        i++;
                        stringAnalyzer(input, ref i);
                    }
                    //for integers
                    if (reNumber.IsMatch(input[i].ToString()))
                    {
                        //either int or float
                        numFunc(input, ref i);
                        //wordBreaker.Add(num);
                    }
                    if (reAlphabat.IsMatch(input[i].ToString()))
                    {

                        alphabet_analyzer(input, ref i);
                        //wordBreaker.Add(keyword);
                    }
                    if (rePunctuators.IsMatch(input[i].ToString()))
                    {

                        specialChar(input, ref i);
                        //wordBreaker.Add(ope);
                    }
                    if (input[i].ToString() == "'")
                    {
                        //Console.WriteLine(input[i + 1]);
                        charAnalyzer(input, ref i);
                    }
                    if(input[i] == '\n')
                    {
                        lineIncrease(ref i);
                    }
                }
                catch(Exception e)
                {

                }
            }
            
            Console.ReadLine();

        }

        //keyWords List
        static IDictionary<string, string> keyWordList = new Dictionary<string, string>()
        {
            {"int", "intDataType"},
            {"float", "floatDataType"},
            {"bool", "dataType"},
            {"string", "dataType"},
            {"char", "dataType"},
            {"List", "List"},
            {"public", "access-modifier"},
            {"private", "access-modifier"},
            {"protected", "access-modifier"},
            {"static", "static"},
            {"abstract", "abstract"},
            {"class", "class"},
            {"void", "void"},
            {"while", "while"},
            {"if", "if"},
            {"else", "else"},
            {"for", "for"},
            {"do", "do"},
            {"break", "break"},
            {"true", "bool-Const"},
            {"false", "bool-Const"},
            {"include", "include"},
        };

        //int a = 12asd;
        //symbols
        static IDictionary<string, string> localSymbol = new Dictionary<string, string>()
        {
            {"{", "{"},
            {"}", "}"},
            {")", ")"},
            {"(", "("},
            {"[", "["},
            {"]", "]"},
            {";", ";"},
            {",", ","},
            {":", ":"},
            {"/", "/"},
            {"*", "*"},
            {"\\", "Lexical Erro"},
            {"?", "Lexical Error"},
        };

        //regex For if/Else Condition
        public static Regex reAlphabat = new Regex(@"^[A-Za-z]$");
        public static Regex reNumber = new Regex(@"^[0-9]$");
        public static Regex rePunctuators = new Regex(@"^,|.|;|{|}|[|]|(|)|:$");
        public static Regex identifier = new Regex(@"^[a-zA-Z_]+[a-zA-Z0-9_]*$");
        public static Regex floating_num = new Regex(@"^[-+]?([0-9]*|\d*\.\d{1}?\d*)$");
        public static Regex integer = new Regex(@"^[-+]?\d*$");
        public static Regex alphaPattern = new Regex(@"^'[\\]?[a-zA-Z0-9_$&+,:;=?@#|'<>.^*()%!-]'");
        //public static Regex reAllPunctuators = new Regex(@"^[\x20-\x2f]|[\x3A-\x40]|[\x5B-\xgE]|[\x7B-\x7E]|'$");


        public static int lineNumber =0;
        //line Increase
        public static bool lineIncrease(ref int index)
        {
            lineNumber++;
            return true;
        }

        //generate Tokens
        public static bool generateToken(string value, string class_ )
        {
            string content = "<"+ value + "," + class_ +","+ lineNumber + ">";
            Console.WriteLine(content);
            return true;
        }

        //lexical Error function
        public static bool generateError(string value, string outPath)
        {
            string content = "<" + value + ", lexical Error" + "," + lineNumber + ">";
            Console.WriteLine(content);
            return true;

        }

        //for string
        public static void stringAnalyzer(string input, ref int index)
        {
            try
            {
                string temp = "";
                while(input[index] != '\n' && input[index] != '"')
                {
                    if(input[index].ToString() == @"\")
                    {
                        if(input[index+1] == '"')
                        {
                            temp += input[index];
                            index++;
                            temp += input[index];
                            index++;
                            continue;
                        }
                        
                    }

                    if(input[index] == '\r')
                    {
                        index++;
                        continue;
                    }
                    temp += input[index];
                    index++;
                }

                if(input[index] == '\n')
                {
                    index++;
                    generateError(temp, "lexical Error");
                }
                else
                {
                    index++;
                    //Console.WriteLine(temp);
                    generateToken(temp, "string_const");
                }

            }
            catch(Exception e)
            {

            }

        }

       

        //Single line comments
        public static void singleLineComments(string input, ref int index)
        {
            try
            {
                string temp = "";

                while (input[index] != '\n')
                {

                    if(input[index] != '\r')
                    {
                        temp += input[index];
                        index++;
                    }
                    else
                    {
                        index++;
                    }
                    
                    
                }
                //Console.WriteLine(temp);
                generateToken(temp, "singleLineComments");
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
            }
        }

        

        //keyWordeChecker
        public static bool keyWordReChecker(ref string temp, out string type)
        {
            if(keyWordList.TryGetValue(temp, out type))
            {
                return true;
            }else
            {
                return false;
            }
        }

        //double char 
        public static void doublevalue(string input, ref int index)
        {
            string temp = "";
            temp += input[index];
            index++;

            while (input[index].ToString() != "'")
            {
                temp += input[index];
                index++;
            }

            if (alphaPattern.IsMatch(temp))
            {
                generateToken(temp, "char");
            }
            else
            {
                generateError(temp, "Lexical Error");
            }
        }

        //charAnalyzer
        public static void charAnalyzer(string input, ref int index)
        {
            string temp = @"";
            

            //got first
            temp += input[index];
            index++;

            if(input[index].ToString() == @"\")
            {

                for (int i = 0; i < 3; i++)
                {
                    temp += input[index];
                    index++;
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    temp += input[index];
                    index++;
                }
            }

            //temp += input[index];
            index--;

            if (alphaPattern.IsMatch(temp))
            {
                generateToken(temp, "char");
            }
            else
            {
                generateError(temp, "lexical Error");
            }
           
        }

        //alphabet
        public static bool alphabet_analyzer( string input, ref int index)
        {
            string type;
            string temp = "";
            temp += input[index];

            while (true)
            {
                if(reAlphabat.IsMatch(input[index + 1].ToString())){
                    index++;
                    temp += input[index];
                }
                else if (reNumber.IsMatch(input[index+1].ToString()))
                {
                    index++;
                    temp += input[index];
                }
                else
                {
                    //if keyWord matches then just generate token
                    if (keyWordReChecker(ref temp, out type))
                    {
                        generateToken(temp, type);
                        //index++;
                        return true;
                    }
                    else
                    {
                        while (true)
                        {
                            if(identifierFunction(temp, ref type))
                            {
                                //index++;
                                generateToken(temp, type);
                                return true;
                            }
                        }
                    }
                    
                }
            }
        }


        //number breaker
        public static void numFunc(string input, ref int index)
        {
            //string type;
            bool flag = false;
            int flagfloat = 0;
            int couter = 0;
            string temp = "";
            try
            {
                if (input[index] == '.')
                {
                    flagfloat += 1;
                    couter++;
                }
                //123.2
                do
                {

                    var j = input[index];
                    temp = temp + j;
                    index++;

                    if (input[index] == '.')
                    {
                        flagfloat += 1;
                        couter++;
                    }

                } while (reNumber.IsMatch(input[index].ToString()) || reAlphabat.IsMatch(input[index].ToString()) || flagfloat == 1 && input[index] != ';');

                if (couter == 2)
                    index--;

                if (integer.IsMatch(temp))
                {
                    //index++;
                    generateToken(temp, "int_const");

                }
                else if (floating_num.IsMatch(temp))
                {
                    //index++;
                    generateToken(temp, "float_const");
                }
                else
                {
                    //index++;
                    generateError(temp, "lexical_Error");
                }
            }
            catch
            {
                generateError(temp, "lexical_Error");
            }
            
            
        }


        //special character
        public static void specialChar(string input, ref int i)
        {
            string result;

            if (input[i] == '+')
            {
                if (input[i + 1] == '+')
                {
                    i += 1;
                    generateToken("++", "inc_op");
                }
                else if (input[i + 1] == '.')
                {
                    numFunc(input, ref i);
                }
                else if (reNumber.IsMatch(input[i + 1].ToString()))
                {
                    numFunc(input, ref i);
                }
                else if (input[i + 1] == '=')
                {
                    i += 1;
                    generateToken("+=", "add-assign");
                }
                else
                {
                    i += 1;
                    generateToken("+", "op");
                }
            }
            else if (input[i] == '-')
            {
                if (input[i + 1] == '-')
                {
                    i += 1;
                    generateToken("--", "dec_op");
                }
                else if (input[i + 1] == '.')
                {
                    numFunc(input, ref i);
                }
                else if (input[i + 1] == '=')
                {
                    i += 1;
                    generateToken("-=", "dec-assign");
                }
                else if (reNumber.IsMatch(input[i + 1].ToString()))
                {
                    numFunc(input, ref i);
                }
                else
                {
                    i += 1;
                    generateToken("-", "op");
                }
            }
            else if (input[i] == '&')
            {
                if (input[i + 1] == '&')
                {
                    i += 1;
                    generateToken("&&", "Lo_op");
                }
                else
                {
                    i++;
                    generateError("&", "Lexical Error");
                }
            }
            else if (input[i] == '|')
            {
                if (input[i + 1] == '|')
                {
                    i += 1;
                    generateToken("||", "Lo_Op");
                }
                else
                {
                    i++;
                    generateError("|", "lexical Error");
                }
            }
            else if (input[i] == ',')
            {
                i++;
                generateToken(",", ",");
            }
            else if (input[i] == '=')
            {
                if (input[i + 1] == '=')
                {
                    i += 1;
                    generateToken("==", "assign_op");
                }
                else
                {
                    //i++;
                    generateToken("=", "equal");
                }
            }
            else if (input[i] == ' ' || input[i] == '\t')
            {
                //i++;
            }
            else if (input[i] == ',')
            {
                i++;
                generateToken(",", ",");
            }
            else if (input[i] == '<')
            {
                if (input[i + 1] == '=')
                {
                    i += 1;
                    generateToken("<=", "cmp_op");
                }
                else
                {
                    i++;
                    generateToken("<", "cmp_op");
                }
            }
            else if (input[i] == '>')
            {
                if (input[i + 1] == '=')
                {
                    i += 1;
                    generateToken(">=", "cmp_op");
                }
                else
                {
                    i++;
                    generateToken(">", "cmp_op");
                }
            }
            else if (input[i] == '!')
            {
                if (input[i + 1] == '=')
                {
                    //i += 1;
                    generateToken("!=", "cmp_op");
                }
                else
                {
                    //i++;
                    generateToken("!", "not_op");
                }
            }
            else if (input[i] == '.')
            {
                if (reNumber.IsMatch(input[i + 1].ToString()))
                {
                    //i += 1;
                    numFunc(input, ref i);
                }
                else
                {
                    //i++;
                    generateToken(".", "dot");
                }
            }
            else if (input[i] == '/')
            {
                //for comments
                if (input[i + 1] == '/')
                {
                    i += 2;
                    singleLineComments(input, ref i);
                }
                if (input[i + 1] == '*')
                {
                    i += 2;
                    //doubleLineComments(ref input , ref i);
                }
            }else if (localSymbol.TryGetValue(input[i].ToString(), out result))
            {
                generateToken(input[i].ToString(), result);
            }
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


        //Regular Function to check syntax
        public static void regularExpression(string name)
        {
            bool integerNum = integerFunction(name);
            bool floatingNum = floatFunction(name);
            //bool identifier = identifierFunction(name);
            bool keyword = CheckKeyword(name);
            bool objAlphaPattern = IsAlpha(name);

            if (integerNum)
                Console.WriteLine(name + "------>: Integer");
            else if (floatingNum)
                Console.WriteLine(name + "------>: Float Number");
            //else if (identifier)
                //Console.WriteLine(name + "------->: Identifier");
            else if (keyword)
                Console.WriteLine(name + "------>: Keyword");
            else if (objAlphaPattern)
                Console.WriteLine(name + "------>: char");
            else
                Console.WriteLine("Invalid Syntax");
        }

        //Function for identifier number
        public static bool identifierFunction(string name, ref string type)
        {
            if (identifier.IsMatch(name))
            {
                type = "ID";
                return true;
            }
            else
            {
                type =  "";
                return false;
            }
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
            Regex objAlphaPattern = new Regex(@"^'[\\]||[a-zA-Z0-9@%$#!^(){}]'");
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
