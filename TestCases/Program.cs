using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxTechnicalTraining.Bootcamp.DotNet.TestDrivenDevelopment;

namespace TestCases
{
    class Program
    {
        static void Main(string[] args)
        {
            bool allTestsPassed = TestForZeroInputs();
            allTestsPassed &= TestForOneInput();
            allTestsPassed &= TestForValidInputs();
            allTestsPassed &= TestForMoreThanTenInputs();

            if (allTestsPassed)
            {
                Console.WriteLine("All tests passed.");
            }
            else
            {
                Console.WriteLine("Some tests failed");
            }

            Console.ReadKey();
        }

        static bool TestForValidInputs()
        {
            string userInput = "3, 5";
            Calculator calculator = new Calculator();
            int sum = calculator.Add(userInput);
            bool passed = PrintTestResult("3", "Test for two valid inputs", "8", sum.ToString());
            userInput = "9, 21";
            sum = calculator.Add(userInput);
            passed &= PrintTestResult("4", "Test for two valid inputs", "30", sum.ToString());
            // three inputs
            userInput = "9, 21, 30";
            sum = calculator.Add(userInput);
            passed &= PrintTestResult("5", "Test for three valid inputs", "60", sum.ToString());
            // random inputs from random.org
            userInput = "4432, 4217, 4450";
            sum = calculator.Add(userInput);
            passed &= PrintTestResult("6", "Test for three valid inputs", "13099", sum.ToString());        
            // 4  inputs
            userInput = "9, 21, 30, 30";
            sum = calculator.Add(userInput);
            passed &= PrintTestResult("7", "Test for four valid inputs", "90", sum.ToString());
            // 5  inputs
            userInput = "9, 21, 30, 30, 90";
            sum = calculator.Add(userInput);
            passed &= PrintTestResult("8", "Test for five valid inputs", "180", sum.ToString());
            // 6  inputs
            userInput = "9, 21, 30, 30, 90";
            sum = calculator.Add(userInput);
            passed &= PrintTestResult("9", "Test for six valid inputs", "180", sum.ToString());
            // 7  inputs
            userInput = "1, 0, 2, 3, 5, 6, 7";
            sum = calculator.Add(userInput);
            passed &= PrintTestResult("10", "Test for seven valid inputs", "24", sum.ToString());
            // 8  inputs
            userInput = "1, 0, 2, 3, 5, 6, 7, 100";
            sum = calculator.Add(userInput);
            passed &= PrintTestResult("11", "Test for eight valid inputs", "124", sum.ToString());
            // 9  inputs
            userInput = "1, 0, 2, 3, 5, 6, 7, 100, 166";
            sum = calculator.Add(userInput);
            passed &= PrintTestResult("11", "Test for nine valid inputs", "290", sum.ToString());
            // 10 inputs
            userInput = "1, 0, 2, 3, 5, 6, 7, 100, 20, 20";
            sum = calculator.Add(userInput);
            passed &= PrintTestResult("11", "Test for ten valid inputs", "164", sum.ToString());
            return passed;
        }

        static bool TestForMoreThanTenInputs()
        {
            string userInput = "100, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10";
            string ApplicationExceptionThrown = " No Exception";
            Calculator calculator = new Calculator();
            try
            {
                //Should throw an ApplicationException
                calculator.Add(userInput);
            }
            catch (ApplicationException ex)
            {
                ApplicationExceptionThrown = " ApplicationException";
            }
            bool passed = PrintTestResult("15", "Test for more than 10 inputs", " ApplicationException", ApplicationExceptionThrown);
            return passed;
        }

        static bool TestForOneInput()
        {
            string userInput = "100";
            string ApplicationExceptionThrown = " No Exception";
            Calculator calculator = new Calculator();
            try
            {
                //Should throw an ApplicationException
                calculator.Add(userInput);
            }
            catch (ApplicationException ex)
            {
                ApplicationExceptionThrown = " ApplicationException";
            }
            bool passed = PrintTestResult("2", "Test for one input", " ApplicationException", ApplicationExceptionThrown);
            return passed;
        }

        static bool TestForZeroInputs()
        { 
            string userInput = "";
            string ApplicationExceptionThrown = " No Exception";
            Calculator calculator = new Calculator();
            try
            {
                //Should throw an ApplicationException
                calculator.Add(userInput);
            } catch (ApplicationException ex)
            {
                ApplicationExceptionThrown = " ApplicationException";
            }
            bool passed = PrintTestResult("1", "Test for zero inputs", " ApplicationException", ApplicationExceptionThrown);
            return passed;
        }
        static bool PrintTestResult(string Id, string Description, string ExpectedResults, string ActualResults)
        {
            string passfail = ExpectedResults == ActualResults ? " PASS" : " FAIL";
            Console.WriteLine($"{Id} {Description} {ExpectedResults} {ActualResults}{passfail}");
            return (passfail == " PASS");
        }
    }
}
