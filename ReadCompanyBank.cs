using NUnit.Framework;

namespace Tests.Automation.AutomatedTests.Companies
{
    [TestFixture]
    class ReadCompanyBank : Generic
    {
        [OneTimeSetUp]
        public void Inicial_Actions()
        {
            // Arrange
            // -

            // Act
            Click_MenuOptions();

            Click_Companies_MenuOption();

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
        public void Get_TheBankText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedDescriptionTableName = "Banco";
            var textToValidateNIBAddAction = "C_NIB123456789";

            // Act
            Click_NewButton();

            Click_DropdownBank();
            Click_OptionInsideDropdown();

            var inputNIB = Get_FieldNIB();
            inputNIB.SendKeys(textToValidateNIBAddAction);

            Click_AddButton();

            var actualNewButtonName = Get_Bank_Text_Table();

            // Assert
            Assert.AreEqual(expectedDescriptionTableName, actualNewButtonName);
        }

        [Test]
        public void Get_TheNIBText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedDescriptionTableName = "NIB";
            var textToValidateNIBAddAction = "C_NIB123456789";

            // Act
            Click_DropdownBank();
            Click_OptionInsideDropdown();

            var inputNIB = Get_FieldNIB();
            inputNIB.SendKeys(textToValidateNIBAddAction);

            Click_AddButton();

            var actualNewButtonName = Get_NIB_Text_Table();

            // Assert
            Assert.AreEqual(expectedDescriptionTableName, actualNewButtonName);
        }
    }
}