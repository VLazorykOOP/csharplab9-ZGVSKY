using System;
using System.Collections;

namespace Lab9
{
    public class Task1
    {
        public static void Execute()
        {
            Console.WriteLine("--- Postfix to Prefix Converter (Using Stack) ---");
            Console.Write("Enter postfix expression (space separated, e.g., 'A B + C *'): ");
            string postfix = Console.ReadLine()!;

            string prefix = ConvertPostfixToPrefix(postfix);
            Console.WriteLine($"\nPrefix expression: {prefix}");
        }

        private static string ConvertPostfixToPrefix(string postfix)
        {
            Stack stack = new Stack();
            string[] tokens = postfix.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                if (IsOperator(token))
                {
                    if (stack.Count < 2)
                    {
                        return "Invalid postfix expression.";
                    }

                    string op1 = (string)stack.Pop()!;
                    string op2 = (string)stack.Pop()!;

                    string newExpr = $"{token} {op2} {op1}";
                    stack.Push(newExpr);
                }
                else
                {
                    stack.Push(token);
                }
            }

            if (stack.Count == 1)
            {
                return (string)stack.Pop()!;
            }

            return "Invalid postfix expression.";
        }

        private static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }
    }
}