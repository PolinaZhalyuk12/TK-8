using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptimalWeightCalculator;

namespace OptimalWeightCalculator.Tests
{
    /// <summary>
    /// Тестовый класс для проверки бизнес-логики вычисления оптимального веса.
    /// Содержит модульные тесты для методов CalculateNormalWeight и GetCategory.
    /// </summary>
    [TestClass]
    public class OptimalWeightLogicTests
    {
        /// <summary>
        /// Проверяет корректность расчёта нормального веса для мужчины ростом 180 см.
        /// Ожидаемое значение: (180-100)*1.13 = 90.4 кг.
        /// </summary>
        [TestMethod]
        public void CalculateNormalWeight_Male_180_Returns90_4()
        {
            double normal = OptimalWeightLogic.CalculateNormalWeight(180, true);
            Assert.AreEqual(90.4, normal, 0.001);
        }

        /// <summary>
        /// Проверяет корректность расчёта нормального веса для женщины ростом 170 см.
        /// Ожидаемое значение: (170-100)*0.9 = 63.0 кг.
        /// </summary>
        [TestMethod]
        public void CalculateNormalWeight_Female_170_Returns63()
        {
            double normal = OptimalWeightLogic.CalculateNormalWeight(170, false);
            Assert.AreEqual(63.0, normal, 0.001);
        }

        /// <summary>
        /// Проверяет, что при весе 80 кг и нормальном весе 90.4 кг выводится категория "Ниже нормы".
        /// Фактический вес меньше нижней границы (90.4 - 3 = 87.4).
        /// </summary>
        [TestMethod]
        public void GetCategory_Below_ReturnsBelow()
        {
            string category = OptimalWeightLogic.GetCategory(80, 90.4);
            Assert.AreEqual("Ниже нормы", category);
        }

        /// <summary>
        /// Проверяет, что при весе 65 кг и нормальном весе 63.0 кг выводится категория "Норма".
        /// Вес попадает в диапазон 60–66 кг (63 ± 3).
        /// </summary>
        [TestMethod]
        public void GetCategory_Normal_ReturnsNormal()
        {
            string category = OptimalWeightLogic.GetCategory(65, 63.0);
            Assert.AreEqual("Норма", category);
        }

        /// <summary>
        /// Проверяет, что при весе 95 кг и нормальном весе 84.75 кг выводится категория "Выше нормы".
        /// Фактический вес больше верхней границы (84.75 + 3 = 87.75).
        /// </summary>
        [TestMethod]
        public void GetCategory_Above_ReturnsAbove()
        {
            string category = OptimalWeightLogic.GetCategory(95, 84.75);
            Assert.AreEqual("Выше нормы", category);
        }

        /// <summary>
        /// Проверяет граничное значение: вес равен нижней границе нормы (нормальный вес - 3).
        /// Ожидается категория "Норма".
        /// </summary>
        [TestMethod]
        public void GetCategory_LowerBound_ReturnsNormal()
        {
            string category = OptimalWeightLogic.GetCategory(90.4 - 3, 90.4);
            Assert.AreEqual("Норма", category);
        }

        /// <summary>
        /// Проверяет граничное значение: вес равен верхней границе нормы (нормальный вес + 3).
        /// Ожидается категория "Норма".
        /// </summary>
        [TestMethod]
        public void GetCategory_UpperBound_ReturnsNormal()
        {
            string category = OptimalWeightLogic.GetCategory(90.4 + 3, 90.4);
            Assert.AreEqual("Норма", category);
        }

        /// <summary>
        /// Проверяет, что при весе на 0.1 кг ниже нижней границы нормы выводится категория "Ниже нормы".
        /// </summary>
        [TestMethod]
        public void GetCategory_BelowBound_ReturnsBelow()
        {
            string category = OptimalWeightLogic.GetCategory(90.4 - 3.1, 90.4);
            Assert.AreEqual("Ниже нормы", category);
        }

        /// <summary>
        /// Проверяет, что при весе на 0.1 кг выше верхней границы нормы выводится категория "Выше нормы".
        /// </summary>
        [TestMethod]
        public void GetCategory_AboveBound_ReturnsAbove()
        {
            string category = OptimalWeightLogic.GetCategory(90.4 + 3.1, 90.4);
            Assert.AreEqual("Выше нормы", category);
        }

        /// <summary>
        /// Проверяет расчёт нормального веса для мужчины ростом 200 см.
        /// Ожидаемое значение: (200-100)*1.13 = 113.0 кг.
        /// </summary>
        [TestMethod]
        public void CalculateNormalWeight_Male_200_Returns113()
        {
            double normal = OptimalWeightLogic.CalculateNormalWeight(200, true);
            Assert.AreEqual(113.0, normal, 0.001);
        }

        /// <summary>
        /// Проверяет расчёт нормального веса для женщины ростом 150 см.
        /// Ожидаемое значение: (150-100)*0.9 = 45.0 кг.
        /// </summary>
        [TestMethod]
        public void CalculateNormalWeight_Female_150_Returns45()
        {
            double normal = OptimalWeightLogic.CalculateNormalWeight(150, false);
            Assert.AreEqual(45.0, normal, 0.001);
        }
    }
}