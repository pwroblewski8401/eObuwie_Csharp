using System;
namespace eObuwie.Pages
{
    public class TestPage
    {
        IWebDriver driver;
        public TestPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}

