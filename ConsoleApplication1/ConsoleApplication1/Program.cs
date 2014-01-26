using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        enum MathsOperator
        {
            add,
            subtract,
            divide,
            multiply
        }
        static void Main(string[] args)
        {
            
            Double dblA=getNumberInput("Enter Value A");
            Double dblB = getNumberInput("Enter Value B");
            MathsOperator enumOperator = getMathsOperatorInput("Choose maths operator");
            Double dblResult = doMaths(dblA, dblB, enumOperator);
            logOutput(String.Concat("Result ", dblResult.ToString()), ConsoleColor.Green);
            Console.ReadKey();

        }

        static void logOutput(string strOutput, ConsoleColor enumColour) {
            Console.ForegroundColor = enumColour;
            Console.WriteLine(strOutput);
        }

        static MathsOperator getMathsOperatorInput(String strPrompt)
        {

            Boolean isOk = false;
            int intInput;
            MathsOperator returnValue = MathsOperator.add;
            while (!isOk)
            {
                logOutput(strPrompt, ConsoleColor.Yellow);
                logOutput("1 - Add", ConsoleColor.Yellow);
                logOutput("2 - Subtract", ConsoleColor.Yellow);
                logOutput("3 - Multiply", ConsoleColor.Yellow);
                logOutput("4 - Divide", ConsoleColor.Yellow);
                Console.ForegroundColor = ConsoleColor.White;
                if (int.TryParse(Console.ReadLine(), out intInput))
                {
                    switch (intInput)
                    {
                        case 1:
                            returnValue=MathsOperator.add;
                            isOk=true;
                            break;
                        case 2:
                            returnValue=MathsOperator.subtract;
                            isOk=true;
                            break;
                        case 3:
                            returnValue = MathsOperator.multiply;
                            isOk=true;
                            break;
                        case 4:
                            returnValue = MathsOperator.divide;
                            isOk=true;
                            break;
                        default:
                            logOutput("You are  stupid", ConsoleColor.Red);
                            break;
                    }

                }
                else
                {
                    logOutput("You are  stupid", ConsoleColor.Red);
                }
            }
            return (returnValue);
        }

        static Double getNumberInput(String strPrompt)
        {
            Boolean isOk = false;
            Double returnValue=0;
            while (isOk == false)
            {
                logOutput(strPrompt, ConsoleColor.Yellow);
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    returnValue = Convert.ToDouble(Console.ReadLine());
                    isOk = true;
                }
                catch
                {
                    logOutput("You are  stupid", ConsoleColor.Red);
                }
            }
            return (returnValue);
        }

        static double doMaths(double dblOne, double dblTwo, MathsOperator enumOperator)
        {
            switch (enumOperator)
            {
                case MathsOperator.add:
                    return dblOne + dblTwo;
                case MathsOperator.subtract:
                    return dblOne - dblTwo;
                case MathsOperator.divide:
                    return dblOne / dblTwo;
                case MathsOperator.multiply:
                    return dblOne * dblTwo;
                default:
                    return 0;
                   
            }
                

        }

    }
}
