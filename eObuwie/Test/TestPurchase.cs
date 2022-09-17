using System;
namespace eObuwie.Test
{
    public class TestPurchase
    {
        IWebDriver driver;

        [SetUp]
        public void setUp()
        {
            this.driver = new ChromeDriver();
            driver.Url = "http://eobuwie.com.pl";
        }

        [Test]
        public void addToBasket()
        {
            Pages.HomePage hp = new Pages.HomePage(driver);
            Pages.SearchPage sp;
            Pages.ProductPage pp;


            sp = hp.searchForText("Adiddas Terrex");
            sp = sp.selectSize("39");
            //sp = sp.selectSize("40");

            pp = sp.clickSelectProduct(0);

            pp.clickSizeSelector();
            pp.selectSize("39");

            pp.clickAddToBasket();
            pp.clicGoToBasket();

            

        }

        [TearDown]
        public void clear()
        {
            driver.Close();
        }
    }
}

