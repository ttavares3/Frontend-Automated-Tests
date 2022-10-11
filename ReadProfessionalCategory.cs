using NUnit.Framework;

namespace Tests.Automation.AutomatedTests.ProfessionalCategories
{
    [TestFixture]
    class ReadProfessionalCategory : Generic
    {
        [OneTimeSetUp]
        public void Inicial_Actions()
        {
            // Arrange
            // -

            // Act
            Click_MenuOptions();

            Click_ProfessionalCategory_MenuOption();

            // Assert
            // -
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
        public void Get_TheDescriptionText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedDescriptionTableName = "Descrição";

            // Act
            var actualNewButtonName = Get_Description_Text_Table();

            // Assert
            Assert.AreEqual(expectedDescriptionTableName, actualNewButtonName);
        }

        [Test]
        public void Get_TheIsActiveText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedShowTableName = "Activo";

            // Act
            var actualNewButtonName = Get_Active_Text_ProfessionalCategoryTable();

            // Assert
            Assert.AreEqual(expectedShowTableName, actualNewButtonName);
        }
    }
}