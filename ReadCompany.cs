using NUnit.Framework;

namespace Tests.Automation.AutomatedTests.Companies
{
    [TestFixture]
    class ReadCompany : Generic
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
        public void Get_ThePageUrl_Returns_IfAreEqual()
        {
            // Arrange
            var expectedPageTitle = "Empresas";

            // Act
            var actualPageTitle = Get_PageTitles();

            // Assert
            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

        [Test]
        public void Get_TheNewButtonText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedNewButtonName = "add Novo";

            // Act
            var actualNewButtonName = Get_NewButton_Text();

            // Assert
            Assert.AreEqual(expectedNewButtonName, actualNewButtonName);
        }

        [Test]
        public void Get_TheNameText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedDescriptionTableName = "Nome";

            // Act
            var actualNewButtonName = Get_Name_Text_Table();

            // Assert
            Assert.AreEqual(expectedDescriptionTableName, actualNewButtonName);
        }

        [Test]
        public void Get_TheNIFText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedDescriptionTableName = "NIF";

            // Act
            var actualNewButtonName = Get_NIF_Text_Table();

            // Assert
            Assert.AreEqual(expectedDescriptionTableName, actualNewButtonName);
        }

        [Test]
        public void Get_TheHasIncomesText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedDescriptionTableName = "Tem Rendas";

            // Act
            var actualNewButtonName = Get_HasIncomes_Text_Table();

            // Assert
            Assert.AreEqual(expectedDescriptionTableName, actualNewButtonName);
        }

        [Test]
        public void Get_TheIsActiveText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedShowTableName = "Activo";

            // Act
            var actualNewButtonName = Get_Active_Text_CompanyTable();

            // Assert
            Assert.AreEqual(expectedShowTableName, actualNewButtonName);
        }
    }
}