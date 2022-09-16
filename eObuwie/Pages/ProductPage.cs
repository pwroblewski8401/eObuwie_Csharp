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


        public string getSKU()
        {
            return sku.GetAttribute("innerHTML");
        }
    }
}

