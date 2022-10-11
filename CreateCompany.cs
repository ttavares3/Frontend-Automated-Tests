using Automation.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Security.Cryptography;


namespace Tests.Automation.AutomatedTests.Companies
{
    [TestFixture]
    class CreateCompany : Generic
    {
        [OneTimeSetUp]
        public void Inicial_Actions()
        {
            // Arrange
            // -

            // Act
            Click_MenuOptions();

            Click_Companies_MenuOption();

            expectedNumberOfRowsBefore = Get_NumberOfRows_InsideTheTable();

            Click_NewButton();

            // Assert
            // -
        }

        [Test]
        public void Get_ThePageUrl_Returns_IfAreEqual()
        {
            // Arrange
            var urlPage = "/company";

            // Act
            var returnUrlPage = Get_DefaultUrl() + urlPage;

            var currentUrl = driver.Url;

            // Assert
            Assert.AreEqual(currentUrl, returnUrlPage);
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
            var expectedPageSubTitle = "Criar Empresa";

            // Act
            var actualPageSubTitle = Get_PageSubTitles(expectedPageSubTitle);

            // Assert
            Assert.AreEqual(expectedPageSubTitle, actualPageSubTitle);
        }

        [Test]
        public void Get_TheNameText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedDescriptionName = "Nome";

            // Act
            var actualDescriptionInputName = Get_Name_Text();

            // Assert
            Assert.AreEqual(expectedDescriptionName, actualDescriptionInputName);
        }

        [Test]
        public void Get_TheNIFText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedNIFName = "NIF";

            // Act
            var actualNIFInputName = Get_NIF_Text();

            // Assert
            Assert.AreEqual(expectedNIFName, actualNIFInputName);
        }

        [Test]
        public void Get_TheHasIncomesText_Returns_IfAreEqual()
        {
            // Arrange
            var expetedHasIncomesName = "Tem Rendas";

            // Act
            var actualHasIncomesInputName = Get_HasIncomes_Text();

            // Assert
            Assert.AreEqual(expetedHasIncomesName, actualHasIncomesInputName);
        }

        [Test]
        public void Get_TheIsActiveText_Returns_IfAreEqual()
        {
            // Arrange
            var expetedIsActiveName = "Activo";

            // Act
            var actualIsActiveInputName = Get_IsActive_Text();

            // Assert
            Assert.AreEqual(expetedIsActiveName, actualIsActiveInputName);
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
        public void Fill_FieldName_InBlank_Returns_ErrorMessage()
        {
            // Arrange
            var expectedErrorMessageInBlank = "Campo obrigatório!";
            var emptyText = " ";

            // Act
            Click_NewButton();

            var inputName = Get_FieldName();
            inputName.Clear();
            inputName.SendKeys(emptyText);
            inputName.SendKeys(Keys.Backspace);

            Click_AddButton();

            var actualErrorMessageBlank = Get_ErrorMessages(expectedErrorMessageInBlank);

            // Assert
            Assert.AreEqual(expectedErrorMessageInBlank, actualErrorMessageBlank);
        }

        [Test]
        public void Fill_FieldName_WithLessThan3Characters_Returns_ErrorMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedErrorMessage = "Min. 3 car.";
            var textWith2Chars = "abc";
            var numberMaxChars = 50;

            // Act
            var inputName = Get_FieldName();
            inputName.SendKeys(textWith2Chars);
            inputName.SendKeys(Keys.Backspace);

            Click_AddButton();

            var expectedInputValue = inputName.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            var actualErrorMessage = Get_ErrorMessages(expectedErrorMessage);

            // Assert
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldName_WithMoreThan3Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedWarningMessage = "Máx. 50 car.";
            var textWith6Chars = "Test T";
            var numberMaxChars = 50;

            // Act
            var inputName = Get_FieldName();
            inputName.Clear();
            inputName.SendKeys(textWith6Chars);

            Click_AddButton();

            var actualWarningMessage = Get_WarningMessages(expectedWarningMessage);

            var expectedInputValue = inputName.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedWarningMessage, actualWarningMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldName_WithMoreThan15Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedwarningFieldMessage = "Máx. 50 car.";
            var textWith17Chars = "Test More Than 15";
            var numberMaxChars = 50;

            // Act
            var inputName = Get_FieldName();
            inputName.Clear();
            inputName.SendKeys(textWith17Chars);

            Click_AddButton();

            var actualWarningFieldMessage = Get_WarningMessages(expectedwarningFieldMessage);

            var expectedInputValue = inputName.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedwarningFieldMessage, actualWarningFieldMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldName_WithMoreThan50Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedwarningFieldMessage = "Máx. 50 car.";
            var textWith53Chars = "Teste More Than 50 Characters Test More Than 50 Chars";
            var numberMaxChars = 50;

            // Act
            var inputName = Get_FieldName();
            inputName.Clear();
            inputName.SendKeys(textWith53Chars);

            Click_AddButton();

            var actualWarningFieldMessage = Get_WarningMessages(expectedwarningFieldMessage);

            var expectedInputValue = inputName.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedwarningFieldMessage, actualWarningFieldMessage);
            Assert.AreEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldNIF_InBlank_Returns_ErrorMessage()
        {
            // Arrange
            var expectedErrorMessageInBlank = "Campo obrigatório!";
            var emptyText = " ";

            // Act
            var inputNIF = Get_FieldNIF();
            inputNIF.Clear();
            inputNIF.SendKeys(emptyText);
            inputNIF.SendKeys(Keys.Backspace);

            Click_AddButton();

            var actualErrorMessageBlank = Get_ErrorMessages(expectedErrorMessageInBlank);

            // Assert
            Assert.AreEqual(expectedErrorMessageInBlank, actualErrorMessageBlank);
        }

        [Test]
        public void Fill_FieldNIF_WithLessThan3Characters_Returns_ErrorMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedErrorMessage = "Min. 3 car.";
            var textWith2Chars = "ab";
            var numberMaxChars = 9;

            // Act
            var inputNIF = Get_FieldNIF();
            inputNIF.Clear();
            inputNIF.SendKeys(textWith2Chars);

            Click_AddButton();

            var actualErrorMessage = Get_ErrorMessages(expectedErrorMessage);

            var expectedInputValue = inputNIF.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldNIF_WithMoreThan3Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedWarningMessage = "Máx. 9 car.";
            var textWith6Chars = "Test T";
            var numberMaxChars = 9;

            // Act
            var inputNIF = Get_FieldNIF();
            inputNIF.Clear();
            inputNIF.SendKeys(textWith6Chars);

            Click_AddButton();

            var actualWarningMessage = Get_WarningMessages(expectedWarningMessage);

            var expectedInputValue = inputNIF.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedWarningMessage, actualWarningMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldNIF_WithMoreThan9Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedwarningFieldMessage = "Máx. 9 car.";
            var textWith10Chars = "Test More T";
            var numberMaxChars = 9;

            // Act
            var inputNIF = Get_FieldNIF();
            inputNIF.Clear();
            inputNIF.SendKeys(textWith10Chars);

            Click_AddButton();

            var actualWarningFieldMessage = Get_WarningMessages(expectedwarningFieldMessage);

            var expectedInputValue = inputNIF.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedwarningFieldMessage, actualWarningFieldMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Get_TheIsActiveStatus_Returns_StatusEqualsTrue()
        {
            // Arrange
            // -

            // Act
            var statusToggle = Get_ToggleIsActive().Selected;

            // Assert
            Assert.IsTrue(statusToggle);
        }

        [Test]
        public void Get_HasIncomesStatus_Returns_StatusEqualsFalse()
        {
            // Arrange
            // -

            // Act
            var statusToggle = Get_ToggleHasIncomes().Selected;

            // Assert
            Assert.IsFalse(statusToggle);
        }

        [Test]
        public void Click_SaveButton_Returns_SuccessMessage_TheCorrectPageUrl_TheNewLineAdded_And_NewValues()
        {
            // Arrange            
            var expectedCreateMessage = "Empresa criada com sucesso!";
            var textToValidateNameSaveAction = $"C_Save button{ RandomNumberExtesions.randomNumber(0,100) }";
            var textToValidateNIFSaveAction = $"C_TNIF{ RandomNumberExtesions.randomNumber(0,100) }";
            var urlPage = "/companies";

            // Act
            Click_NewButton();

            var inputName = Get_FieldName();
            inputName.Clear();
            inputName.SendKeys(textToValidateNameSaveAction);

            Click_AddButton();

            var inputNIF = Get_FieldNIF();
            inputNIF.Clear();
            inputNIF.SendKeys(textToValidateNIFSaveAction);
            inputNIF.SendKeys(Keys.Tab);

            Click_SaveButton();

            var actualCreateMessage = Get_SuccessMessages(expectedCreateMessage);

            var expectedNumberOfRowsAfter = Get_NumberOfRows_InsideTheTable();

            var actualNameValue = Get_Name_Value();

            var actualNIFValue = Get_NIF_Value();

            var returnUrlPage = Get_DefaultUrl() + urlPage;

            var currentUrl = driver.Url;

            // Assert
            Assert.AreEqual(expectedCreateMessage, actualCreateMessage);
            Assert.AreEqual(currentUrl, returnUrlPage);
            Assert.Greater(expectedNumberOfRowsAfter, expectedNumberOfRowsBefore);
            Assert.AreEqual(textToValidateNameSaveAction, actualNameValue);
            Assert.AreEqual(textToValidateNIFSaveAction, actualNIFValue);
        }

        [Test]
        public void Click_BackButton_Returns_TheCorrectPageUrl_And_IfTheTableHasNoChanges()
        {
            // Arrange
            var textToValidateNameBackAction = "C_Test Back button";
            var textToValidateNIFBackAction = "C_NIFTest";
            var urlPage = "/companies";

            // Act
            var inputName = Get_FieldName();
            inputName.SendKeys(textToValidateNameBackAction);

            var inputNIF = Get_FieldNIF();
            inputNIF.SendKeys(textToValidateNIFBackAction);

            Click_BackButton();

            var returnUrlPage = Get_DefaultUrl() + urlPage;

            var currentUrl = driver.Url;

            var expectedNumberOfRowsAfter = Get_NumberOfRows_InsideTheTable();

            var actualNameValue = Get_Name_Value();

            var actualNIFValue = Get_NIF_Value();

            // Assert
            Assert.AreEqual(currentUrl, returnUrlPage);
            Assert.AreEqual(expectedNumberOfRowsAfter, expectedNumberOfRowsBefore);
            Assert.AreNotEqual(textToValidateNameBackAction, actualNameValue);
            Assert.AreNotEqual(textToValidateNIFBackAction, actualNIFValue);
        }
    }
}