using System;
namespace eObuwie.Test
{
    public class TestHomePage
    {
        IWebDriver driver;
        [SetUp]
        public void setUp()
        {
            this.driver = new ChromeDriver();
            driver.Url = "http://eobuwie.com.pl";
        }

        [Test]
        public void SearchTest()
        {
            Pages.HomePage hp = new Pages.HomePage(driver);
            Pages.SearchPage sp = hp.searchForText("J311538C Black");
            Pages.ProductPage pp = sp.clickSelectProduct(0);

            if (pp.getSKU() == string.Empty)
            {
                Assert.True(false, "SKU IS NULL!!");
            }
            else
                StringAssert.IsMatch("0000200688015", pp.getSKU(), "SKU match gven SKU: 0000200688015");

        }

        [Test]
        public void LoadPage()
        {
            Pages.HomePage hp = new Pages.HomePage(driver);
            StringAssert.Contains("Sklep internetowy eobuwie.pl", hp.GetPageTitle());
        }



        [TearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}
