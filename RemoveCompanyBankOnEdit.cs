using NUnit.Framework;

namespace Tests.Automation.AutomatedTests.Companies
{
    [TestFixture]
    class RemoveCompanyBankOnEdit : Generic
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
        public void Get_ThePopupConfirmMessage_Returns_IfAreEqual_OnEdit()
        {
            // Arrange
            var expectedPopUpConfirmMessage = "Queres remover este registo?";

            // Act
            var actualPopUpConfirmMessage = Get_PopupConfirmMessage();

            // Assert
            Assert.AreEqual(expectedPopUpConfirmMessage, actualPopUpConfirmMessage);
        }

        [Test]
        public void Get_ThePopupWarningMessage_Returns_IfAreEqual_OnEdit()
        {
            // Arrange
            var expectedPopUpConfirmMessage = "O registo será removido apenas quando gravares as alterações feitas.";

            // Act
            var actualPopUpConfirmMessage = Get_PopupWarningMessage();

            // Assert
            Assert.AreEqual(expectedPopUpConfirmMessage, actualPopUpConfirmMessage);
        }

        [Test]
        public void Get_ThePopupCancelButtonText_Returns_IfAreEqual_OnEdit()
        {
            // Arrange
            var expectedCancelButtonName = "Cancelar";
            var textToValidateNIBAddAction = "C_NIB123456789";

            // Act
            Click_DropdownBank();
            Click_OptionInsideDropdown();

            var inputNIB = Get_FieldNIB();
            inputNIB.SendKeys(textToValidateNIBAddAction);

            Click_AddButton();

            Click_RemoveButton();

            var actualPopUpCancelButtonName = Get_PopupCancelButton_Text();

            // Assert
            Assert.AreEqual(expectedCancelButtonName, actualPopUpCancelButtonName);
        }

        [Test]
        public void Get_ThePopupConfirmButtonText_Returns_IfAreEqual_OnEdit()
        {
            // Arrange
            var expectedConfirmButtonName = "Confirmar";

            // Act
            var actualConfirmButtonName = Get_PopupConfirmButton_Text();

            // Assert
            Assert.AreEqual(expectedConfirmButtonName, actualConfirmButtonName);
        }

        [Test]
        public void Click_ThePopupConfirmButton_Returns_DeleteTheRecord_OnEdit()
        {
            // Arrange
            // -

            // Act
            Click_RemoveButton();

            Click_PopupConfirmButton();

            // Assert
            // -
        }

        [Test]
        public void Click_ThePopupCancelButton_Returns_CancelsThePopupOperation_OnEdit()
        {
            // Arrange
            var textToValidateNIBAddAction = "C_NIB123456789";

            // Act
            var inputNIB = Get_FieldNIB();
            inputNIB.SendKeys(textToValidateNIBAddAction);

            Click_DropdownBank();
            Click_OptionInsideDropdown();

            Click_AddButton();

            Click_RemoveButton();

            Click_PopupCancelButton();

            // Assert
            // -
        }
    }
}
