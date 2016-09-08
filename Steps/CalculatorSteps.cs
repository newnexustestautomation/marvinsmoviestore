using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIT.Tests.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        private Calculator calculator = new Calculator();
        private int result { get; set; }

        [Given]
        public void Given_I_have_entered_P0_into_the_calculator(int number)
        {
            calculator.FirstNumber = number;
        }

        [Given]
        public void Given_I_have_also_entered_P0_into_the_calculator(int number)
        {
            calculator.SecondNumber = number;
        }

        [When]
        public void When_I_press_add()
        {
            result = calculator.Add();
        }
        
        [Then]
        public void Then_the_result_should_be_P0_on_the_screen(int expected)
        {
            Assert.AreEqual(expected, result);
        }
    }
}
