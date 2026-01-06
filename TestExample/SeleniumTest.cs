using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample
{
    [TestClass]
    public sealed class SeleniumTest
    {
        //initialisere WebDriver
        //Gør driver til en klassevariabel så alle testmetoder kan bruge den
        //driver gør det muligt at styre browseren
        private static IWebDriver driver;

        //Setup metode der kører en gang før alle tests
        [ClassInitialize]
        //TestContext parameter er nødvendig for ClassInitialize metoder
        //kommer fra MSTest frameworket som ligger i Microsoft.VisualStudio.TestTools.UnitTesting
        public static void Setup(TestContext context)
        {
            //vælger Chrome som browser der testes i
            ChromeOptions options = new ChromeOptions();
            //tilføjer argument for at køre browseren i headless mode (uden GUI)
            //gør testene hurtigere og undgår at åbne synlige browser vinduer
            options.AddArguments("--headless=new");
            driver = new ChromeDriver();
            //navigerer til den lokale webside der skal testes
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
        }

        //Cleanup metode der kører en gang efter alle tests
        //sørger for at lukke browseren og rydde op efter testene
        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestButtonExists()
        {
            //Act
            IWebElement button = driver.FindElement(By.Id("btnShow"));
            var btnTag = button.TagName;

            //Assert
            Assert.AreEqual("button", btnTag);
        }
        [TestMethod]
        public void TestShowListAppears()
        {
            // Arrange
            IWebElement showButton = driver.FindElement(By.Id("btnShow"));

            // Act
            showButton.Click();

            // Wait for the list to appear (v-show sets display: block)
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //gør at vi venter på at elementet med id "list" bliver synligt i 5 sekunder
            IWebElement list = wait.Until(drv =>
            {
                var elem = drv.FindElement(By.Id("list"));
                return elem.Displayed ? elem : null;
            });

            // Assert
            Assert.IsTrue(list.Displayed);
        }

    }
}
