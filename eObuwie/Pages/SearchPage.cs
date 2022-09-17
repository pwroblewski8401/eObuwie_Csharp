using System;
namespace eObuwie.Pages
{
    public class SearchPage
    {
        private IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

            Thread.Sleep(4000);
        }


        [FindsBy(How = How.ClassName, Using = "products-list__item")]
        [CacheLookup]
        private IList<IWebElement> itemsList;

        [FindsBy(How = How.ClassName, Using = "filter-grid__link")]
        [CacheLookup]
        private IList<IWebElement> sizeSelector;



        public ProductPage clickSelectProduct(int index)
        {
            itemsList[index].Click();
            return new ProductPage(driver);
        }


        public void print()
        {
            int a = 0;
            foreach (IWebElement i in itemsList)
            {
                Console.WriteLine(a + ": " + i.TagName);
                a++;
            }
        }

        public Dictionary<string, IWebElement> getSizesList()
        {
            Dictionary<string, IWebElement> sizes = new Dictionary<string, IWebElement>(); ;

            foreach(IWebElement i in sizeSelector)
            {
                string sizeTXT = i.GetAttribute("innerHTML");
                StringAssert.IsMatch(String.Empty, sizeTXT, "ERR: size string is empty!");

                sizes.Add(sizeTXT, i);
            }

            return sizes;
        }

        public SearchPage selectSize(string sizeName)
        {
            Dictionary<string, IWebElement> sizes = getSizesList();

            foreach(KeyValuePair<string, IWebElement> element in sizes)
            {
                if (element.Key.Contains(sizeName))
                {
                    element.Value.Click();
                    return new SearchPage(driver);
                }
            }

            Console.WriteLine("ERR: NO SIZE SELECTED!");
            return new SearchPage(driver);
        }




    }
}

