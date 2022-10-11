using Tests.Automation.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Security.Cryptography;

namespace Tests.Automation.AutomatedTests.ProfessionalCategories
{
    [TestFixture]
    class CreateProfessionalCategory : Generic
    {
        [OneTimeSetUp]
        public void Inicial_Actions()
        {
            // Arrange
            // -

            // Act
            Click_MenuOptions();

            Click_ProfessionalCategory_MenuOption();

            expectedNumberOfRowsBefore = Get_NumberOfRows_InsideTheTable();

            // Assert
            // -
        }

        [Test]
        public void Get_ThePageUrl_Returns_IfAreEqual()
        {
            // Arrange
            var urlPage = "/professional-categories";

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
            var expectedPageTitle = "Categorias Profissionais";

            // Act
            var actualPageTitle = Get_PageTitles();

            // Assert
            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

        [Test]
        public void Get_ThePageSubTitle_Returns_IfAreEqual()
        {
            // Arrange
            var expectedPageSubTitle = "Criar Categoria Profissional";

            // Act
            var actualPageSubTitle = Get_PageSubTitles(expectedPageSubTitle);

            // Assert
            Assert.AreEqual(expectedPageSubTitle, actualPageSubTitle);
        }

        [Test]
        public void Get_TheDescriptionText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedDescriptionName = "Descrição";

            // Act
            var actualDescriptionInputName = Get_Description_Text();

            // Assert
            Assert.AreEqual(expectedDescriptionName, actualDescriptionInputName);
        }

        [Test]
        public void Get_TheIsActiveText_Returns_IfAreEqual()
        {
            // Arrange
            var expetedIsDisplayedName = "Activo";

            // Act
            var actualIsDisplayedInputName = Get_IsActive_Text();

            // Assert
            Assert.AreEqual(expetedIsDisplayedName, actualIsDisplayedInputName);
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
        public void Fill_FieldDescription_InBlank_Returns_ErrorMessage()
        {
            // Arrange
            var expectedErrorMessageInBlank = "Campo obrigatório!";
            var emptyText = "";

            // Act
            Click_NewButton();

            var inputDescription = Get_FieldDescription();
            inputDescription.SendKeys(emptyText);
            inputDescription.SendKeys(Keys.Tab);

            var actualErrorMessageBlank = Get_ErrorMessages(expectedErrorMessageInBlank);

            // Assert
            Assert.AreEqual(expectedErrorMessageInBlank, actualErrorMessageBlank);
        }

        [Test]
        public void Fill_FieldDescription_WithLessThan3Characters_Returns_ErrorMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedErrorMessage = "Min. 3 car.";
            var textWith2Chars = "ab";
            var numberMaxChars = 30;

            // Act
            var inputDescription = Get_FieldDescription();
            inputDescription.SendKeys(textWith2Chars);
            inputDescription.SendKeys(Keys.Tab);

            var actualErrorMessage = Get_ErrorMessages(expectedErrorMessage);

            var expectedInputValue = inputDescription.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldDescription_WithMoreThan3Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedWarningMessage = "Max. 30 car.";
            var textWith6Chars = "Test M";
            var numberMaxChars = 30;

            // Act
            var inputDescription = Get_FieldDescription();
            inputDescription.Clear();
            inputDescription.SendKeys(textWith6Chars);
            inputDescription.SendKeys(Keys.Tab);

            var actualWarningMessage = Get_WarningMessages(expectedWarningMessage);

            var expectedInputValue = inputDescription.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedWarningMessage, actualWarningMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldDescription_WithMoreThan15Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedwarningFieldMessage = "Max. 30 car.";
            var textWith16Chars = "Test More Than 3";
            var numberMaxChars = 30;

            // Act
            var inputDescription = Get_FieldDescription();
            inputDescription.Clear();
            inputDescription.SendKeys(textWith16Chars);
            inputDescription.SendKeys(Keys.Tab);

            var actualWarningFieldMessage = Get_WarningMessages(expectedwarningFieldMessage);

            var expectedInputValue = inputDescription.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedwarningFieldMessage, actualWarningFieldMessage);
            Assert.LessOrEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Fill_FieldDescription_WithMoreThan30Characters_Returns_WarningMessage_And_NumberOfCharsInserted()
        {
            // Arrange
            var expectedwarningFieldMessage = "Max. 30 car.";
            var textWith31Chars = "Teste More Than 30 Characters T";
            var numberMaxChars = 30;

            // Act
            var inputDescription = Get_FieldDescription();
            inputDescription.Clear();
            inputDescription.SendKeys(textWith31Chars);

            var actualWarningFieldMessage = Get_WarningMessages(expectedwarningFieldMessage);

            var expectedInputValue = inputDescription.GetAttribute("value");
            int numberOfChars = expectedInputValue.Length;

            // Assert
            Assert.AreEqual(expectedwarningFieldMessage, actualWarningFieldMessage);
            Assert.AreEqual(numberOfChars, numberMaxChars);
        }

        [Test]
        public void Get_TheIsActiveStatus_Returns_StatusEqualsTrue()
        {
            // Arrange
            // -

            // Act
            var statusToggle = Get_ToggleIsActive().Enabled;

            // Assert
            Assert.IsTrue(statusToggle);
        }

        [Test]
        public void Get_TheIsActiveStatus_Returns_StatusEqualsFalse()
        {
            // Arrange
            // -

            // Act
            ClickableClass_Toggle().Click();

            var statusToggle = Get_ToggleIsActive().Selected;

            // Assert
            Assert.IsFalse(statusToggle);
        }

        [Test]
        public void Click_SaveButton_Returns_SuccessMessage_TheCorrectPageUrl_TheNewLineAdded_And_NewValues()
        {
            // Arrange
            var expectedCreateMessage = "Categoria Profissional criada com sucesso!";
            var textToValidateSaveAction = $"C_Test Save button { RandomNumberExtesions.randomNumber(0,100) }";
            var urlPage = "/professional-categories";

            // Act
            Click_NewButton();

            var inputDescription = Get_FieldDescription();
            inputDescription.Clear();
            inputDescription.SendKeys(textToValidateSaveAction);

            Click_SaveButton();

            var actualCreateMessage = Get_SuccessMessages(expectedCreateMessage);

            var returnUrlPage = Get_DefaultUrl() + urlPage;

            var currentUrl = driver.Url;

            var expectedNumberOfRowsAfter = Get_NumberOfRows_InsideTheTable();

            var actualDescriptionValue = Get_Description_Value();

            // Assert
            Assert.AreEqual(expectedCreateMessage, actualCreateMessage);
            Assert.AreEqual(currentUrl, returnUrlPage);
            Assert.Greater(expectedNumberOfRowsAfter, expectedNumberOfRowsBefore);
            Assert.AreEqual(textToValidateSaveAction, actualDescriptionValue);
        }

        [Test]
        public void Click_BackButton_Returns_TheCorrectPageUrl_And_IfTheTableHasNoChanges()
        {
            // Arrange
            var textToValidateBackAction = "C_Test Back button";
            var urlPage = "/professional-categories";

            // Act
            Click_NewButton();

            var inputDescription = Get_FieldDescription();
            inputDescription.SendKeys(textToValidateBackAction);

            Click_BackButton();

            var returnUrlPage = Get_DefaultUrl() + urlPage;

            var currentUrl = driver.Url;

            var expectedNumberOfRowsAfter = Get_NumberOfRows_InsideTheTable();

            var actualDescriptionValue = Get_Description_Value();

            // Assert
            Assert.AreEqual(currentUrl, returnUrlPage);
            Assert.AreEqual(expectedNumberOfRowsAfter, expectedNumberOfRowsBefore);
            Assert.AreNotEqual(textToValidateBackAction, actualDescriptionValue);
        }
    }
}