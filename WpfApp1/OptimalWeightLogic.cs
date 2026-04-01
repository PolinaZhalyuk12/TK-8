using System;

namespace OptimalWeightCalculator
{
    public static class OptimalWeightLogic
    {
        /// <summary>
        /// Вычисляет нормальный вес в зависимости от роста и пола.
        /// </summary>
        /// <param name="height">Рост в см (130–220).</param>
        /// <param name="isMale">true - мужчина, false - женщина.</param>
        /// <returns>Нормальный вес (кг).</returns>
        public static double CalculateNormalWeight(double height, bool isMale)
        {
            double baseWeight = height - 100;
            if (isMale)
                return baseWeight * 1.13;
            else
                return baseWeight * 0.9;
        }

        /// <summary>
        /// Определяет категорию веса (ниже нормы, норма, выше нормы) с учётом ±3 кг.
        /// </summary>
        /// <param name="actualWeight">Фактический вес (кг).</param>
        /// <param name="normalWeight">Нормальный вес (кг).</param>
        /// <returns>Строка с категорией.</returns>
        public static string GetCategory(double actualWeight, double normalWeight)
        {
            double lowerBound = normalWeight - 3;
            double upperBound = normalWeight + 3;

            if (actualWeight < lowerBound)
                return "Ниже нормы";
            else if (actualWeight > upperBound)
                return "Выше нормы";
            else
                return "Норма";
        }
    }
}