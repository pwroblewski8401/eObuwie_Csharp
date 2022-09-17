using System;
namespace eObuwie.Pages
{
    public class ProductPage
    {
        IWebDriver driver;


        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;

            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//body[1]/div[3]/div[2]/div[2]/section[2]/div[1]/div[1]/ul[1]/li[4]/ul[1]/li[5]/div[1]/div[1]")]
        private IWebElement sku;

        [FindsBy(How = How.ClassName, Using = "product-right__size-select")]
        private IWebElement sizeSelector;

        [FindsBy(How = How.ClassName, Using = "e-size-picker-option__group")]
        private IList<IWebElement> sizesList;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Dodaj do koszyka')]")]
        private IWebElement addToBasketButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Przejdź do koszyka')]")]
        private IWebElement goToBasket;


        public void clickAddToBasket()
        {
            TimeSpan time = new TimeSpan();
            time = TimeSpan.FromSeconds(10);
            var wait = new WebDriverWait(driver, time);
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Dodaj do koszyka')]")));

            addToBasketButton.Click();
        }


        //TODO: add basket page here 
        public void clicGoToBasket()
        {
            TimeSpan time = new TimeSpan();
            time = TimeSpan.FromSeconds(10);
            var wait = new WebDriverWait(driver, time);
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Przejdź do koszyka')]")));

            goToBasket.Click();
        }

        public string getSKU()
        {
            return sku.GetAttribute("innerHTML");
        }

        public Dictionary<string, IWebElement> getAvaliableSizesTabel()
        {
            TimeSpan time = new TimeSpan();
            time = TimeSpan.FromSeconds(10);

            var wait = new WebDriverWait(driver, time);
            var ekement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(),'Załaduj skan')]")));

            Dictionary<string, IWebElement> avaliableSizesTabel = new Dictionary<string, IWebElement>();

            Console.WriteLine("LIST:");

            foreach(IWebElement element in sizesList)
            {
                string sizeText = element.GetAttribute("innerHTML");
                Console.WriteLine(sizeText);
                StringAssert.IsMatch(string.Empty, sizeText);

                avaliableSizesTabel.Add(sizeText, element);
            }


            return avaliableSizesTabel;
        }

        public void selectSize(string size)
        {
            Dictionary<string, IWebElement> sizes = getAvaliableSizesTabel();

            
            foreach(KeyValuePair<string, IWebElement> element in sizes)
            {
                bool isSelected = false;
                if(element.Key.Contains(size))
                {
                    element.Value.Click();
                    isSelected = true;
                    Thread.Sleep(4000);
                    break;
                }

                Assert.IsFalse(isSelected, "ERR: No size selected!"); 
            }

        }

        public void clickSizeSelector()
        {
            sizeSelector.Click();
        }
    }
}

