using System;
using System.Windows;

namespace OptimalWeightCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtHeight.Text, out double height))
            {
                ShowError("Введите корректное числовое значение роста.");
                return;
            }
            if (!double.TryParse(txtWeight.Text, out double weight))
            {
                ShowError("Введите корректное числовое значение веса.");
                return;
            }

            if (height < 130 || height > 220)
            {
                ShowError("Рост должен быть в диапазоне 130–220 см.");
                return;
            }
            if (weight < 40 || weight > 170)
            {
                ShowError("Вес должен быть в диапазоне 40–170 кг.");
                return;
            }

            bool isMale = rbMale.IsChecked == true;

            double normalWeight = OptimalWeightLogic.CalculateNormalWeight(height, isMale);
            string category = OptimalWeightLogic.GetCategory(weight, normalWeight);

            tbNormalWeight.Text = $"{normalWeight:F2} кг";
            tbCategory.Text = category;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
            tbNormalWeight.Text = "";
            tbCategory.Text = "";
        }
    }
}