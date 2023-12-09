using Lab5.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V118.Runtime;

namespace Lab5
{
    public class Tests
    {
        public IWebDriver _driver;
        public CalculatorPage calculator;
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options);
            calculator = new CalculatorPage(_driver);
            _driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/");
        }

        [Test]
        public void EnterValueA()
        {
            calculator = new CalculatorPage(_driver);
            calculator.EnterA("1");
            string result = calculator.GetValueA();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void EnterValueB()
        {
            calculator.EnterB("2");
            string result = calculator.GetValueB();
            Assert.AreEqual("2", result);
        }
        [Test]
        public void PlusA()
        {
            calculator.EnterA("0");
            calculator.ClickPlusA();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void PlusB()
        {
            calculator.ClickPlusB();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void MinusA()
        {
            calculator.EnterA("2");
            calculator.ClickMinusA();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void MinusB()
        {
            calculator.EnterB("2");
            calculator.ClickMinusB();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void DoublePlusA()
        {
            calculator.EnterA("1");
            calculator.ClickPlusA();
            calculator.ClickPlusA();
            string result = calculator.GetResult();
            Assert.AreEqual("3", result);
        }
        [Test]
        public void DoubleMinusA()
        {
            calculator.EnterA("3");
            calculator.ClickMinusA();
            calculator.ClickMinusA();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void OperatorMinus()
        {
            calculator.EnterA("3");
            calculator.EnterB("1");
            calculator.ClickOperation("-");
            string result = calculator.GetResult();
            Assert.AreEqual("2", result);
        }
        [Test]
        public void OperatorUmnogit()
        {
            calculator.EnterA("3");
            calculator.EnterB("1");
            calculator.ClickOperation("*");
            string result = calculator.GetResult();
            Assert.AreEqual("3", result);
        }
        [Test]
        public void OperatorDelit()
        {
            calculator.EnterA("4");
            calculator.EnterB("2");
            calculator.ClickOperation("/");
            string result = calculator.GetResult();
            Assert.AreEqual("2", result);
        }
        [Test]
        public void OperatorPlus()
        {
            calculator.EnterA("4");
            calculator.EnterB("2");
            calculator.ClickOperation("+");
            string result = calculator.GetResult();
            Assert.AreEqual("6", result);
        }
        [Test]
        public void OperatorPlus2()
        {
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
            calculator.EnterA("4");
            calculator.EnterB("-2");
            string result = calculator.GetResultB();
            Assert.AreEqual("-2", result);
        }
        [TestCase()]
        public void OperationUmnogit2()
        {
            calculator.EnterA("-4");
            calculator.EnterB("-2");
            calculator.ClickOperation("*");
            string result = calculator.GetResult();
            Assert.AreEqual("8", result);
        }
        [Test]
        public void OperationDelenieNaNol()
        {
            calculator.EnterA("4");
            calculator.EnterB("0");
            calculator.ClickOperation("/");
            string result = calculator.GetResult();
            Assert.AreEqual("null", result);
        }fdfd
        [Test]
        public void OperationUmnogeniaNaStroku()
        {
            calculator.EnterA("4");
            calculator.EnterB("ghhh");
            calculator.ClickOperation("*");
            string result = calculator.GetResult();
            Assert.AreEqual("null", result);
        }
        [TestCase("3.5","2","1.75","/")]
        [TestCase("2.1","3", "6.300000000000001", "*")]
        [TestCase("1","1.25","2.25","+")]
        [TestCase("121.25","1.25","120","-")]
        [TestCase("121.25","1.25","120","-")]
        [TestCase("hh","222","null","+")]
        [TestCase("1212 12","331","null","*")]
        [TestCase("144","44 1","null","+")]
        [TestCase("21 21","63 2","null","-")]
        [TestCase("113333", "3232332322323233232", "3.66329919085859e+23", "*")]
        [TestCase("1,1", "3221", "null", "*")]
        public void Operation(string a, string b, string resultTest, string operation)
        {
            calculator.EnterA(a);
            calculator.EnterB(b);
            calculator.ClickOperation(operation);
            string result = calculator.GetResult();
            Assert.AreEqual(resultTest, result);
        }

        //  вещественные числ, путсеык ,некоррук=тные 10e1
        [TearDown] 
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
