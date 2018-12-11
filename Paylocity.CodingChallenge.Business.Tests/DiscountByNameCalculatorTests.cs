using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.CodingChallenge.Entities;

namespace Paylocity.CodingChallenge.Business.Tests
{
    [TestClass]
    public class DiscountByNameCalculatorTests
    {
        [TestMethod]
        public void verify_no_discount_if_name_does_not_start_with_letter_a()
        {
            // Arrange
            var testPerson = new Person() { Name = "NameThatDoesntStartWithA" };
            var objectUnderTest = new DiscountByNameCalculator();

            // Act
            var discountRate = objectUnderTest.GetDiscountRate(testPerson);

            // Assert
            Assert.IsTrue(discountRate == 0.0);
        }

        [TestMethod]
        public void verify_10_percent_discount_rate_if_name_starts_with_letter_a()
        {
            // Arrange
            var testPerson = new Person() { Name = "ANameThatStartsWithLetterA" };
            var objectUnderTest = new DiscountByNameCalculator();

            // Act
            var discountRate = objectUnderTest.GetDiscountRate(testPerson);

            // Assert
            Assert.IsTrue(discountRate == 0.10);
        }

        [TestMethod]
        public void verify_no_discount_if_person_is_null()
        {
            // Arrange
            Person testPerson = null;
            var objectUnderTest = new DiscountByNameCalculator();

            // Act
            var discountRate = objectUnderTest.GetDiscountRate(testPerson);

            // Assert
            Assert.IsTrue(discountRate == 0.0);
        }

        [TestMethod]
        public void verify_no_discount_if_person_name_is_null()
        {
            // Arrange
            Person testPerson = new Person();
            var objectUnderTest = new DiscountByNameCalculator();

            // Act
            var discountRate = objectUnderTest.GetDiscountRate(testPerson);

            // Assert
            Assert.IsTrue(discountRate == 0.0);
        }
    }
}
