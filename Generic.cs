using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Automation.AutomatedTests
{
    [TestFixture]
    public class Generic
    {
        public IWebDriver driver;
        public int expectedNumberOfRowsBefore;
        public string expectedDescriptionValueBefore;
        public string expectedNIFValueBefore;

        [OneTimeSetUp]
        public void Initialize_Test()
        {
            // Arrange
            // -

            // Act
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("env_url");

            Thread.Sleep(1000);
        }

        public string Get_DefaultUrl()
        {
            // Arrange
            // -

            // Act
            return "env_url";
        }

        //Login actions
        public void Insert_EmailAndPassword()
        {
            // Arrange
            var emailLogin = "user_email";
            var passwordLogin = "user_pass";

            // Act
            var inputEmail = Get_FieldEmail();
            inputEmail.SendKeys(emailLogin);

            Click_NextButton();

            var inputPassword = Get_FieldPassword();
            inputPassword.SendKeys(Decode_Password(passwordLogin));
        }

        public void Click_NextButton()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.XPath("//*[@id=\"idSIButton9\"]")).Click();
        }

        public string Decode_Password(string passwordLogin)
        {
            // Arrange
            var encodePassword = Convert.FromBase64String(passwordLogin);
            string decodePassword = Encoding.UTF8.GetString(encodePassword);

            // Act
            return decodePassword;
        }

        public void Click_LoginButton()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.XPath("//*[@id=\"idSIButton9\"]")).Click();
        }

        public void Click_ConsentButton()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.XPath("//*[@id=\"idSIButton9\"]")).Click();
        }

        //Menu options
        public void Click_MenuOptions()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.XPath("/html/body/app-root/mat-drawer-container/mat-drawer/div/app-sidebar/mat-tree/mat-nested-tree-node[5]/li/div/button")).Click();
            driver.FindElement(By.XPath("/html/body/app-root/mat-drawer-container/mat-drawer/div/app-sidebar/mat-tree/mat-nested-tree-node[5]/li/ul/mat-nested-tree-node[2]/li/div/button")).Click();
        }

        public void Click_ProfessionalCategory_MenuOption()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.XPath("/html/body/app-root/mat-drawer-container/mat-drawer/div/app-sidebar/mat-tree/mat-nested-tree-node[5]/li/ul/mat-nested-tree-node/li/ul/mat-nested-tree-node[3]/li/div/button")).Click();
        }

        public void Click_Companies_MenuOption()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.XPath("/html/body/app-root/mat-drawer-container/mat-drawer/div/app-sidebar/mat-tree/mat-nested-tree-node[5]/li/ul/mat-nested-tree-node[2]/li/ul/mat-nested-tree-node[6]/li/div/button")).Click();
        }

        public void Click_CostCenter_MenuOptions()
        {
            // Arrange
            Thread.Sleep(9000);

            // Act
            driver.FindElement(By.XPath("/html/body/app-root/mat-drawer-container/mat-drawer/div/app-sidebar/div/div/ngx-simplebar/div[1]/div[2]/div/div/div/mat-tree/mat-nested-tree-node[4]/li/a/button")).Click();
            driver.FindElement(By.XPath("/html/body/app-root/mat-drawer-container/mat-drawer/div/app-sidebar/div/div/ngx-simplebar/div[1]/div[2]/div/div/div/mat-tree/mat-nested-tree-node[4]/li/ul/mat-nested-tree-node/li/a")).Click();
        }

        //Get all titles names
        public string Get_PageTitles()
        {
            // Arrange
            var searchDriver = driver.FindElement(By.ClassName("page-title")).Text;

            // Act
            return searchDriver.Replace("\r\naddNovo", "");
        }

        public string Get_PageSubTitles(string subTitles)
        {
            // Arrange
            var listElementsMatCard = driver.FindElements(By.ClassName("pageSubTitle"));

            // Act
            foreach (IWebElement element in listElementsMatCard)
            {
                subTitles = element.Text;
            }
            return subTitles;
        }

        public string Get_PageSubTitle_BankSection()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("pageSubTitleBank")).Text;
        }

        //Get fields names
        public string Get_Description_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("fieldDescriptionText")).Text;
        }
        public string Get_Description_Value()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("descriptionText")).Text;
        }

        public string Get_Name_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("fieldNameText")).Text;
        }
        public string Get_Name_Value()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("nameText")).Text;
        }

        public string Get_NIF_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("fieldNifText")).Text;
        }
        public string Get_NIF_Value()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("nifText")).Text;
        }

        public string Get_DropdownBank_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("fieldBankText")).Text;
        }
        public string Get_DropdownBank_Value()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("bankText")).Text;
        }

        public string Get_NIB_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("fieldNibText")).Text;
        }
        public string Get_NIB_Value()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("nibText")).Text;
        }

        public string Get_IsActive_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("fieldIsActiveText")).Text;
        }

        public string Get_HasIncomes_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("fieldHasIncomesText")).Text;
        }

        //Get filters Names
        public string Get_FilterCode_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("filterCodeText")).Text;
        }

        public string Get_FilterDescriptionOrClient_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("filterDescriptionOrClientText")).Text;
        }

        public string Get_FilterPeriod_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("filterPeriodText")).Text;
        }

        public string Get_FilterBeginDate_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("filterBeginDateText")).Text;
        }

        public string Get_FilterEndDate_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("filterEndDateText")).Text;
        }

        public string Get_FilterIsActive_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("filterIsActiveText")).Text;
        }

        public string Get_FilterIsSuspend_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("filterIsSuspendText")).Text;
        }

        //Get table names
        public string Get_Description_Text_Table()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("tableTextDescription")).Text;
        }

        public string Get_Active_Text_ProfessionalCategoryTable()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("tableTextisActive")).Text;
        }

        public string Get_Name_Text_Table()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("tableTextName")).Text;
        }

        public string Get_NIF_Text_Table()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("tableTextNif")).Text;
        }

        public string Get_HasIncomes_Text_Table()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("tableTextHasIncomes")).Text;
        }

        public string Get_Active_Text_CompanyTable()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("tableTextIsActive")).Text;
        }

        public string Get_Bank_Text_Table()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("tableTextBank")).Text;
        }

        public string Get_NIB_Text_Table()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("tableTextNib")).Text;
        }

        public int Get_NumberOfRows_InsideTheTable()
        {
            // Arrange
            Thread.Sleep(2000);

            var getTable = driver.FindElement(By.ClassName("mat-table"));

            // Act
            List<IWebElement> trLines = new List<IWebElement>(getTable.FindElements(By.ClassName("mat-row")));

            return trLines.Count();
        }

        //Get options names inside dropdown
        public string Get_OptionValue_InsideDropdown()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("fieldOptionText")).Text;
        }

        //To do
        public string Get_elements_FromTable()
        {
            // Arrange
            Thread.Sleep(1000);

            var getTable = driver.FindElement(By.ClassName("mat-table"));

            // Act
            List<IWebElement> trLines = new List<IWebElement>(getTable.FindElements(By.ClassName("mat-row")));

            var cellsText = "";

            foreach (var elemTr in trLines)
            {
                List<IWebElement> tdCells = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));

                if (tdCells.Count > 0)
                {
                    foreach (var elemTd in tdCells)
                    {
                        cellsText = cellsText + elemTd.Text;
                    }
                }
            }
            return cellsText;
        }

        //Get buttons names
        public string Get_NewButton_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("buttonNew")).Text;
        }

        public string Get_BackButton_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("buttonBack")).Text;
        }

        public string Get_SaveButton_Text()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("buttonSave")).Text;
        }

        public string Get_ClearButton_Text()
        {
            // Arrange
            var searchDriver = driver.FindElement(By.Id("buttonClear")).Text;

            // Act
            return searchDriver.Replace("undo ", "");
        }

        public string Get_SearchButton_Text()
        {
            // Arrange
            var searchDriver = driver.FindElement(By.Id("buttonSearch")).Text;

            // Act
            return searchDriver.Replace("search ", "");
        }

        //Get fields and buttons
        public IWebElement Get_FieldDescription()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.CssSelector("input[formControlName=description]"));
        }

        public IWebElement Get_FieldName()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.CssSelector("input[formControlName=name]"));
        }

        public IWebElement Get_FieldNIF()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.CssSelector("input[formControlName=nif]"));
        }

        public IWebElement Get_FieldNIB()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.CssSelector("input[formControlName=nib]"));
        }

        public IWebElement Get_FieldEmail()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.CssSelector("#i0116"));
        }

        public IWebElement Get_FieldPassword()
        {
            // Arrange
            Thread.Sleep(2000);

            // Act
            return driver.FindElement(By.CssSelector("#i0118"));
        }

        public IWebElement Get_FieldCode()
        {
            // Arrange
            Thread.Sleep(2000);

            // Act
            return driver.FindElement(By.CssSelector("input[formControlName=code]"));
        }

        public IWebElement Get_FieldDescriptionOrClient()
        {
            // Arrange
            Thread.Sleep(2000);

            // Act
            return driver.FindElement(By.CssSelector("input[formControlName=descriptionOrClient]"));
        }

        public IWebElement Get_FieldBeginDate()
        {
            // Arrange
            Thread.Sleep(2000);

            // Act
            return driver.FindElement(By.CssSelector("input[formControlName=beginOn]"));
        }

        public IWebElement Get_FieldEndDate()
        {
            // Arrange
            Thread.Sleep(2000);

            // Act
            return driver.FindElement(By.CssSelector("input[formControlName=endOn]"));
        }

        public IWebElement Get_FieldIsSupend()
        {
            // Arrange
            Thread.Sleep(2000);

            // Act
            return driver.FindElement(By.XPath("//*[@id=\"ngForm\"]/div[2]/div[1]/mat-form-field/div/div[1]/div[3]"));
        }

        public IWebElement Get_FieldIsActive()
        {
            // Arrange
            Thread.Sleep(2000);

            // Act
            return driver.FindElement(By.XPath("//*[@id=\"mat-select-value-3\"]"));
        }

        public IWebElement Get_ToggleIsActive()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("fieldIsActiveText-input"));
        }

        public IWebElement Get_ToggleHasIncomes()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("fieldHasIncomesText-input"));
        }

        public IWebElement Get_SaveButton()
        {
            // Arrange
            Thread.Sleep(2000);

            // Act
            return driver.FindElement(By.Id("buttonSave"));
        }
        public IWebElement Get_AddButton()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("buttonAdd"));
        }

        public IWebElement ClickableClass_Toggle()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.ClassName("mat-slide-toggle-thumb"));
        }

        //Get buttons and fields to click
        public void Click_DropdownBank()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            driver.FindElement(By.XPath("//*[@id=\"ngFormBank\"]/div/div[1]/mat-form-field/div/div[1]/div[3]")).Click();
        }

        public void Click_DropdownIsSuspend()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            driver.FindElement(By.XPath("//*[@id=\"ngForm\"]/div[2]/div[1]/mat-form-field/div/div[1]/div[3]")).Click();
        }

        public void Click_DropdownIsActive()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            driver.FindElement(By.XPath("//*[@id=\"mat-select-value-3\"]")).Click();
        }

        public void Click_DropdownOption1_IsSuspend()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("filterIsSuspendOption1Text")).Click();
        }

        public void Click_DropdownOption0_IsSuspend()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("filterIsSuspendOption0Text")).Click();
        }

        public void Click_DropdownOption1_IsActive()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("filterIsActiveOption1Text")).Click();
        }

        public void Click_DropdownOption0_IsActive()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("filterIsActiveOption0Text")).Click();
        }

        public void Click_OptionInsideDropdown()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("fieldOptionText")).Click();
        }

        public void Click_AddButton()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("buttonAdd")).Click();
        }

        public void Click_CleanButton()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("buttonClear")).Click();
        }

        public void Click_SaveButton()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("buttonSave")).Click();
        }

        public void Click_BackButton()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("buttonBack")).Click();
        }

        public void Click_EditButton()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            driver.FindElement(By.ClassName("edit")).Click();
        }

        public void Click_RemoveButton()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            driver.FindElement(By.ClassName("delete")).Click();
        }

        public void Click_NewButton()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("buttonNew")).Click();
        }

        //Get Popups
        public string Get_PopupConfirmMessage()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("confirmMsg")).Text;
        }

        public string Get_PopupWarningMessage()
        {
            // Arrange
            // -

            // Act
            return driver.FindElement(By.Id("warningMsg")).Text;
        }

        public string Get_PopupCancelButton_Text()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("buttonCancel")).Text;
        }

        public string Get_PopupConfirmButton_Text()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act
            return driver.FindElement(By.Id("buttonConfirm")).Text;
        }

        public void Click_PopupCancelButton()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("buttonCancel")).Click();
        }

        public void Click_PopupConfirmButton()
        {
            // Arrange
            // -

            // Act
            driver.FindElement(By.Id("buttonConfirm")).Click();
        }

        //Get success messages after actions
        public string Get_WarningMessages(string errorMsg)
        {
            // Arrange
            var listElementsMatHint = driver.FindElements(By.Id("requiredMsg"));

            // Act
            foreach (IWebElement element in listElementsMatHint)
            {
                errorMsg = element.Text;
            }
            return errorMsg;
        }

        public string Get_ErrorMessages(string errorMsg)
        {
            // Arrange
            Thread.Sleep(1000);
            var listElementsMatError = driver.FindElements(By.ClassName("mat-error"));

            // Act
            foreach (IWebElement element in listElementsMatError)
            {
                errorMsg = element.Text;
            }
            return errorMsg;
        }

        public string Get_SuccessMessages(string successMsgs)
        {
            // Arrange
            Thread.Sleep(2000);
            var listElementsSnackBar = driver.FindElements(By.ClassName("cdk-overlay-pane"));

            // Act
            foreach (IWebElement element in listElementsSnackBar)
            {
                successMsgs = element.Text;
            }
            return successMsgs.Replace("\r\nOK", "");
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
            // Arrange
            Thread.Sleep(1000);

            // Act              
            driver.Quit();
        }
    }
}