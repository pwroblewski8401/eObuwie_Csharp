using System;
namespace eObuwie.Pages
{
    public class HomePage
    {

        private IWebDriver driver;


        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

            PageFactory.InitElements(driver, this);

            Thread.Sleep(5000);

            if (ifAgreementIsVisble() == true)
            {
                btnAcceptClick();
            }

            //None other wait works
            Thread.Sleep(5000);
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Zgoda')]")]
        [CacheLookup]
        private IWebElement btnAccept;

        [FindsBy(How = How.XPath, Using = "//header/div[4]/div[1]/form[1]/input[1]")]
        [CacheLookup]
        private IWebElement textBoxSearch;


        public void btnAcceptClick()
        {
            btnAccept.Click();
        }

        public bool ifAgreementIsVisble()
        {
            if (btnAccept.Displayed && btnAccept.Enabled)
            {
                return true;
            }
            else
                return false;
        }

        public String getSearchText()
        {
            return textBoxSearch.Text;
        }

        public SearchPage searchForText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/div[4]/div[1]/form[1]/input[1]")));

            textBoxSearch.SendKeys(text);
            textBoxSearch.Submit();
            return new SearchPage(driver);

        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

    }
}

