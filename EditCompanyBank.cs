using NUnit.Framework;
using OpenQA.Selenium;

namespace Tests.Automation.AutomatedTests.Companies
{
    [TestFixture]
    class EditCompanyBank : Generic
    {
        [OneTimeSetUp]
        public void Inicial_Actions()
        {
            // Arrange
            // -

            // Act
            Click_MenuOptions();

            Click_Companies_MenuOption();

            Click_EditButton();

            // Assert
            // -
        }

        [Test]
        public void Get_ThePageTitle_Returns_IfAreEqual()
        {
            // Arrange
            var expectedPageTitle = "Empresas";

            // Act
            var actualPageTitle = Get_PageTitles();

            // Assert
            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

        [Test]
        public void Get_ThePageSubTitle_Returns_IfAreEqual()
        {
            // Arrange
            var expectedPageSubTitle = "Actualizar Empresa";

            // Act
            var actualPageSubTitle = Get_PageSubTitles(expectedPageSubTitle);

            // Assert
            Assert.AreEqual(expectedPageSubTitle, actualPageSubTitle);
        }

        [Test]
        public void Get_TheSubTitleBankSection_Returns_IfAreEqual()
        {
            // Arrange
            var expectedPageSubTitleBank = "Bancos";

            // Act
            var actualPageSubTitleBank = Get_PageSubTitle_BankSection();

            // Assert
            Assert.AreEqual(expectedPageSubTitleBank, actualPageSubTitleBank);
        }

        [Test]
        public void Get_TheDropdownText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedDropdownName = "Banco";

            // Act
            var actualDropdownInputName = Get_DropdownBank_Text();

            // Assert
            Assert.AreEqual(expectedDropdownName, actualDropdownInputName);
        }

        [Test]
        public void Get_TheNIBText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedNIBName = "NIB";

            // Act
            var actualNIBInputName = Get_NIB_Text();

            // Assert
            Assert.AreEqual(expectedNIBName, actualNIBInputName);
        }

        [Test]
        public void Get_TheBackButtonText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedBackButtonName = "Voltar";

            // Act
            var actualBackButtonName = Get_BackButton_Text();

            // Assert
            Assert.AreEqual(expectedBackButtonName, actualBackButtonName);
        }

        [Test]
        public void Get_TheSaveButtonText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedSaveButtonName = "Gravar";

            // Act
            var actualSaveButtonName = Get_SaveButton_Text();

            // Assert
            Assert.AreEqual(expectedSaveButtonName, actualSaveButtonName);
        }

        [Test]
        public void Fill_FieldNIB_WithLessThan3Characters_Returns_ErrorMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedErrorMessage = "Min. 3 car.";
            var textWith2Chars = "ab";
            var numberMaxChars = 21;

            // Act
            Click_EditButton();

            var inputNIB = Get_FieldNIB();
            inputNIB.Clear();
            inputNIB.SendKeys(textWith2Chars);
            inputNIB.SendKeys(Keys.Tab);

            var actualErrorMessage = Get_ErrorMessages(expectedErrorMessage);

            var expectedInputValue = inputNIB.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldNIB_WithMoreThan3Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedWarningMessage = "Max. 21 car.";
            var textWith10Chars = "Test More ";
            var numberMaxChars = 21;

            // Act
            Click_EditButton();

            var inputNIB = Get_FieldNIB();
            inputNIB.Clear();
            inputNIB.SendKeys(textWith10Chars);
            inputNIB.SendKeys(Keys.Tab);

            var actualWarningMessage = Get_WarningMessages(expectedWarningMessage);

            var expectedInputValue = inputNIB.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedWarningMessage, actualWarningMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldNIB_WithMoreThan15Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedwarningFieldMessage = "Max. 21 car.";
            var textWith16Chars = "Test More Than 3";
            var numberMaxChars = 21;

            // Act
            Click_EditButton();

            var inputNIB = Get_FieldNIB();
            inputNIB.Clear();
            inputNIB.SendKeys(textWith16Chars);
            inputNIB.SendKeys(Keys.Tab);

            var actualWarningFieldMessage = Get_WarningMessages(expectedwarningFieldMessage);

            var expectedInputValue = inputNIB.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedwarningFieldMessage, actualWarningFieldMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldNIB_WithMoreThan21Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedwarningFieldMessage = "Max. 21 car.";
            var textWith23Chars = "Test More Test 21 chars";
            var numberMaxChars = 21;

            // Act
            Click_EditButton();

            var inputNIB = Get_FieldNIB();
            inputNIB.Clear();
            inputNIB.SendKeys(textWith23Chars);
            inputNIB.SendKeys(Keys.Tab);

            var actualWarningFieldMessage = Get_WarningMessages(expectedwarningFieldMessage);

            var expectedInputValue = inputNIB.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedwarningFieldMessage, actualWarningFieldMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Edit_And_TryAdd_ActiveBankToTheList_WithoutNIB_Returns_StatusOfAddButtonEqualsTrue()
        {
            // Arrange
            var expectedStatusAddButton = "true";
            var emptyText = " ";

            // Act
            Click_EditButton();

            Click_DropdownBank();
            Click_OptionInsideDropdown();

            var inputNIB = Get_FieldNIB();
            inputNIB.Clear();
            inputNIB.SendKeys(emptyText);
            inputNIB.SendKeys(Keys.Backspace);

            var actualStatusAddButton = Get_AddButton().GetAttribute("ng-reflect-disabled");

            // Assert
            Assert.AreEqual(expectedStatusAddButton, actualStatusAddButton);
        }

        [Test]
        public void Edit_And_Add_ActiveBankAndNIBToTheList_Returns_StatusOfAddButtonEqualsFalse()
        {
            // Arrange
            var textToValidateNIBAddAction = "C_NIB123456789";
            var expectedStatusAddButton = "false";

            // Act
            Click_EditButton();

            var inputNIB = Get_FieldNIB();
            inputNIB.Clear();
            inputNIB.SendKeys(textToValidateNIBAddAction);

            Click_DropdownBank();
            Click_OptionInsideDropdown();

            var actualStatusAddButton = Get_AddButton().GetAttribute("ng-reflect-disabled");

            Click_AddButton();

            // Assert
            Assert.AreEqual(expectedStatusAddButton, actualStatusAddButton);
        }

        [Test]
        public void Click_CleanButton_AfterFillTheFields_Returns_EmptyFields()
        {
            // Arrange
            var expectedNameDropdownBank = "Banco";
            var expectedStatusFieldNIB = "false";

            // Act
            Click_EditButton();

            Click_CleanButton();

            var actualNameDropdownBank = Get_DropdownBank_Text();

            var actualStatusFieldNIB = Get_FieldNIB().GetAttribute("aria-invalid");

            // Assert
            Assert.AreEqual(expectedNameDropdownBank, actualNameDropdownBank);
            Assert.AreEqual(expectedStatusFieldNIB, actualStatusFieldNIB);
        }

        [Test]
        public void Click_CleanButton_AfterFillTheFields_Returns_IfTheSameBankAppearsAgain_InsideTheDropdown()
        {
            // Arrange
            var textToValidateNIBAddAction = "C_NIB123456789";

            // Act
            var inputNIB = Get_FieldNIB();
            inputNIB.SendKeys(textToValidateNIBAddAction);

            Click_DropdownBank();
            var expectedDropdownValue = Get_OptionValue_InsideDropdown();
            Click_OptionInsideDropdown();

            Click_CleanButton();

            Click_DropdownBank();
            var actualDropdownValue = Get_OptionValue_InsideDropdown();
            Click_OptionInsideDropdown();

            // Assert
            Assert.AreEqual(expectedDropdownValue, actualDropdownValue);
        }

        [Test]
        public void Click_SaveButton_Returns_SuccessMessage_TheCorrectPageUrl_IfTheTableHasNoChanges_And_OldValuesUpdated()
        {
            // Arrange
            var expectedCreateMessage = "Empresa actualizada com sucesso!";
            var textToValidateNIBAddAction = "C_NIB123456789";
            var urlPage = "/companies";

            // Act
            Click_DropdownBank();
            Click_OptionInsideDropdown();

            var inputNIB = Get_FieldNIB();
            inputNIB.Clear();
            inputNIB.SendKeys(textToValidateNIBAddAction);

            Click_AddButton();

            Click_SaveButton();

            var actualCreateMessage = Get_SuccessMessages(expectedCreateMessage);

            var returnUrlPage = Get_DefaultUrl() + urlPage;

            var currentUrl = driver.Url;

            // Assert
            Assert.AreEqual(expectedCreateMessage, actualCreateMessage);
            Assert.AreEqual(currentUrl, returnUrlPage);
        }

        [Test]
        public void Click_BackButton_Returns_TheCorrectPageUrl()
        {
            // Arrange
            var textToValidateNameBackAction = "C_Test Back button";
            var textToValidateNIFBackAction = "C_TestNIF";
            var textToValidateNIBAddAction = "C_NIB123456789";
            var urlPage = "/companies";

            // Act
            var inputName = Get_FieldName();
            inputName.Clear();
            inputName.SendKeys(textToValidateNameBackAction);

            var inputNIF = Get_FieldNIF();
            inputNIF.Clear();
            inputNIF.SendKeys(textToValidateNIFBackAction);

            Click_DropdownBank();
            Click_OptionInsideDropdown();

            var inputNIB = Get_FieldNIB();
            inputNIB.SendKeys(textToValidateNIBAddAction);

            Click_AddButton();

            Click_BackButton();

            var returnUrlPage = Get_DefaultUrl() + urlPage;

            var currentUrl = driver.Url;

            // Assert
            Assert.AreEqual(currentUrl, returnUrlPage);
        }
    }
}