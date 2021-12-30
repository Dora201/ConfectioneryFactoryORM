namespace ConfectioneryFactory.Demo.Tests
{
    using System;
    using NUnit.Framework;
    using ConfectioneryFactory.Domain;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            var ingredient = new Ingredient(1, "�����", 40);
            var product = new Product(1, "����������", "������", 100, ingredient);

            var expected = $"1) ������ <<����������>> - 100�(�����������: 1. ����� - 40�)";

            var actual = product.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_EmptyIngredient_Success()
        {
            var book = new Product(1, "��������", "�������", 40);

            var expected = "1) ������� <<��������>> - 40�";

            var actual = book.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Ctor_ValidDataEmptyIngredients_Success()
        {
            Assert.DoesNotThrow(() => _ = new Product(1, "��������", "�������", 40));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        [TestCase("\r")]
        [TestCase("\t")]
        public void Ctor_WrongDataNullTypeEmptyIngredients_Fail(string wrongType)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Product(1, "��������", wrongType, 40));
        }

        [Test]
        public void Ctor_ValidData_Success()
        {
            var ingredient = new Ingredient(1, "�����", 40);

            Assert.DoesNotThrow(() => _ = new Product(1, "����������", "������", 100, ingredient));
        }
    }
}