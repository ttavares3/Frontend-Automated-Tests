using NUnit.Framework;

namespace Tests.Automation.AutomatedTests.ProfessionalCategories
{
    [TestFixture]
    class RemoveProfessionalCategory : Generic
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

            Click_RemoveButton();

            // Assert
            // -
        }

        [Test]
        public void Get_ThePopupConfirmMessage_Returns_IfAreEqual()
        {
            // Arrange
            var expectedPopUpConfirmMessage = "Queres remover este registo?";

            // Act
            var actualPopUpConfirmMessage = Get_PopupConfirmMessage();

            // Assert
            Assert.AreEqual(expectedPopUpConfirmMessage, actualPopUpConfirmMessage);
        }

        [Test]
        public void Get_ThePopupCancelButtonText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedCancelButtonName = "Cancelar";

            // Act
            Click_RemoveButton();

            var actualPopUpCancelButtonName = Get_PopupCancelButton_Text();

            // Assert
            Assert.AreEqual(expectedCancelButtonName, actualPopUpCancelButtonName);
        }

        [Test]
        public void Get_ThePopupConfirmButtonText_Returns_IfAreEqual()
        {
            // Arrange
            var expectedConfirmButtonName = "Confirmar";

            // Act
            var actualConfirmButtonName = Get_PopupConfirmButton_Text();

            // Assert
            Assert.AreEqual(expectedConfirmButtonName, actualConfirmButtonName);
        }

        [Test]
        public void Click_ThePopupConfirmButton_Returns_SuccessMessage_DeleteTheRecord_And_GiveNumberOfLinesAfter()
        {
            // Arrange
            var expectedRemoveMessage = "Categoria Profissional removida com sucesso!";

            // Act
            Click_RemoveButton();

            Click_PopupConfirmButton();

            var actualRemoveMessage = Get_SuccessMessages(expectedRemoveMessage);

            var expectedNumberOfRowsAfter = Get_NumberOfRows_InsideTheTable();

            // Assert
            Assert.AreEqual(expectedRemoveMessage, actualRemoveMessage);
            Assert.Less(expectedNumberOfRowsAfter, expectedNumberOfRowsBefore);
        }

        [Test]
        public void Click_ThePopupCancelButton_Returns_TheCorrectPageUrl_CancelsThePopupOperation_And_GiveNumberOfLinesAfter()
        {
            // Arrange
            var urlPage = "/professional-categories";

            // Act
            Click_PopupCancelButton();

            var returnUrl = Get_DefaultUrl() + urlPage;

            var currentUrl = driver.Url;

            var expectedNumberOfRowsAfter = Get_NumberOfRows_InsideTheTable();

            // Assert
            Assert.AreEqual(currentUrl, returnUrl);
            Assert.AreEqual(expectedNumberOfRowsAfter, expectedNumberOfRowsBefore);
        }
    }
}