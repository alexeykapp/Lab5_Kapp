using Lab5.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab5
{
    public class Tests
    {
        public IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/");
        }

        [Test]
        public void EnterValueA()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("1");
            string result = calculator.GetValueA();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void EnterValueB()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterB("2");
            string result = calculator.GetValueB();
            Assert.AreEqual("2", result);
        }
        [Test]
        public void PlusA()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.ClickPlusA();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void PlusB()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.ClickPlusB();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void MinusA()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("2");
            calculator.ClickMinusA();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void MinusB()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterB("2");
            calculator.ClickMinusB();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void DoublePlusA()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("1");
            calculator.ClickPlusA();
            calculator.ClickPlusA();
            string result = calculator.GetResult();
            Assert.AreEqual("3", result);
        }
        [Test]
        public void DoubleMinusA()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("3");
            calculator.ClickMinusA();
            calculator.ClickMinusA();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void OperatorMinus()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("3");
            calculator.EnterB("1");
            calculator.ClickOperation("-");
            string result = calculator.GetResult();
            Assert.AreEqual("2", result);
        }
        [Test]
        public void OperatorUmnogit()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("3");
            calculator.EnterB("1");
            calculator.ClickOperation("*");
            string result = calculator.GetResult();
            Assert.AreEqual("3", result);
        }
        [Test]
        public void OperatorDelit()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("4");
            calculator.EnterB("2");
            calculator.ClickOperation("/");
            string result = calculator.GetResult();
            Assert.AreEqual("2", result);
        }
        [Test]
        public void OperatorPlus()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("4");
            calculator.EnterB("2");
            calculator.ClickOperation("+");
            string result = calculator.GetResult();
            Assert.AreEqual("6", result);
        }
        [Test]
        public void OperatorPlus2()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("4");
            calculator.EnterB("-2");
            calculator.ClickOperation("+");
            string result = calculator.GetResult();
            Assert.AreEqual("2", result);
        }
        [Test]
        public void ResultA()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("4");
            calculator.EnterB("-2");
            string result = calculator.GetResultA();
            Assert.AreEqual("4", result);
        }
        [Test]
        public void ResultB()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("4");
            calculator.EnterB("-2");
            string result = calculator.GetResultB();
            Assert.AreEqual("-2", result);
        }
        [Test]
        public void OperationUmnogit2()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("-4");
            calculator.EnterB("-2");
            calculator.ClickOperation("*");
            string result = calculator.GetResult();
            Assert.AreEqual("8", result);
        }
        [Test]
        public void OperationDelenieNaNol()
        {
            CalculatorPage calculator = new CalculatorPage(_driver);
            calculator.EnterA("4");
            calculator.EnterB("0");
            calculator.ClickOperation("/");
            string result = calculator.GetResult();
            Assert.AreEqual("null", result);
        }
        [TearDown] 
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}