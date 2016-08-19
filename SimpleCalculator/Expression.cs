﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleCalculator
{
    public class Expression
    {
        // Variables
       
        string pattern = @"^(?<Num1>-?\d+)\s?(?<Oper>[\+\-\*\/%])\s?(?<Num2>-?\d+)"; // Regex pattern for expressions
        public int First;
        public int Second;
        public string Operator = "";  // Parsed elements of the expressions

        public void Slicer(string UserInput)
        {
            // Instantiate Regex
            Regex Regex = new Regex(pattern);
            Match Match = Regex.Match(UserInput);
            // Instantiate Calculator
            Calculator Calculator = new Calculator();

            // Checks the input against the Regular Expression
            if (true == Regex.IsMatch(UserInput))
            {
                First = Convert.ToInt32(Match.Groups["Num1"].Value);
                Second = Convert.ToInt32(Match.Groups["Num2"].Value);
                Operator = Match.Groups["Oper"].Value;
            }
            else  // If it isn't an acceptable expression..
            {
                Console.WriteLine("Your input is invalid, try again.");  //..delivers error message to user
            }

            if (Operator == "+")
            {
                Console.WriteLine("Answer:  " + Calculator.Addition(First, Second));
            }
            else if (Operator == "-")
            {
                Console.WriteLine("Answer:  " + Calculator.Subtraction(First, Second));
            }
            else if (Operator == "*")
            {
                Console.WriteLine("Answer:  " + Calculator.Multiplication(First, Second));
            }
            else if (Operator == "/")
            {
                if (Second == 0)
                {
                    Console.WriteLine("You can't divide by zero, Holmes.");
                }
                else
                {
                    Console.WriteLine("Answer:  " + Calculator.Division(First, Second));
                }
            }
            else if (Operator == "%")
            {
                Console.WriteLine("Answer:  " + Calculator.Modulus(First, Second));
            }
        }
    }
}
