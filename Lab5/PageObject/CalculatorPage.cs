using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.Network;
using OpenQA.Selenium.Support.UI;

namespace Lab5.PageObject
{
    internal class CalculatorPage
    {
        private readonly IWebDriver _driver;
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(5);

        private readonly By _logotip = By.TagName("h1");
        private readonly By _a = By.XPath("//input[@ng-model='a']");
        private readonly By _aPlus = By.XPath("//button[@ng-click='inca()']");
        private readonly By _aMinus = By.XPath("//button[@ng-click='deca()']");
        private readonly By _b = By.XPath("//input[@ng-model='b']");
        private readonly By _bPlus = By.XPath("//button[@ng-click='incb()']");
        private readonly By _bMinus = By.XPath("//button[@ng-click='decb()']");
        private readonly By _operation = By.TagName("select");
        private readonly By _result = By.TagName("b");

        public CalculatorPage(IWebDriver webDriver)
        {
            _driver = webDriver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                new WebDriverWait(_driver, _timeout).Until(drv => drv.FindElement(_logotip));
            }
            catch
            {
                Console.WriteLine("Не удалось загрузить страницу");
            }
        }
        public CalculatorPage EnterA(string a)
        {
            _driver.FindElement(_a).Clear();
            _driver.FindElement(_a).SendKeys(a);
            return this;
        }
        public CalculatorPage EnterB(string b)
        {
            _driver.FindElement(_b).Clear();
            _driver.FindElement(_b).SendKeys(b);
            return this;
        }
        public CalculatorPage ClickPlusA()
        {
            _driver.FindElement(_aPlus).Click();
            return this;
        }
        public string GetValueA()
        {
            IWebElement element = _driver.FindElement(By.XPath("//input[@ng-model='a']"));
            return element.GetAttribute("value");
        }
        public string GetValueB()
        {
            IWebElement element = _driver.FindElement(By.XPath("//input[@ng-model='b']"));
            return element.GetAttribute("value");
        }
        public CalculatorPage ClickMinusA()
        {
            _driver.FindElement(_aMinus).Click();
            return this;
        }
        public CalculatorPage ClickPlusB()
        {
            _driver.FindElement(_bPlus).Click();
            return this;
        }
        public CalculatorPage ClickMinusB()
        {
            _driver.FindElement(_bMinus).Click();
            return this;
        }
        public CalculatorPage ClickOperation(string operation)
        {
            _driver.FindElement(_operation).Click();
            _driver.FindElement(By.XPath($".//option[@value='{operation}']")).Click();
            return this;
        }
        public string GetResult()
        {
            return _driver.FindElement(_result).Text.Split(' ').Last();
        }
        public string GetResultA()
        {
            return _driver.FindElement(_result).Text.Split(' ')[0];
        }
        public string GetResultB()
        {
            return _driver.FindElement(_result).Text.Split(' ')[2];
        }
    }
}
