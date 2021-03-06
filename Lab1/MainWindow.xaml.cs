﻿using System.Windows;
using Lab1.ViewModels;

/*
Попросіть користувача ввести дату свого народження. Для цього використайте елемент управління DatePicker.
Розрахуйте вік користувача.
Перевірте, чи вік користувача правильний. Наприклад, якщо користувач ще не народився чи йому більше ніж 135 років,
    виведіть повідомлення про помилку. (використайте клас MessageBox для відображення)
Виведіть вік користувача в TextBlock
Якщо сьогодні день народження користувача, виведіть приємне повідомлення.
Обчислить знак зодіаку користувача відповідно до західної та китайської астрологічної системи. 
    Якщо ви не знайомі з цими астрологічними системами, перегляньте їх в Інтернеті.
Виведіть обидва знаки зодіаку в TextBlock-и.
 */

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext= new MainWindowViewModel();
        }
    }
}
