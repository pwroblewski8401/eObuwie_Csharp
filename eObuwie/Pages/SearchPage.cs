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



        public ProductPage clicElement(int index)
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


    }
}

