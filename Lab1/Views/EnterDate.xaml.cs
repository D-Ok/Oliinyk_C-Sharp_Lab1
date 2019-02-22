﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab1.Tools;
using Lab1.ViewModels;

namespace Lab1.Views
{
    /// <summary>
    /// Логика взаимодействия для EnterDate.xaml
    /// </summary>
    public partial class EnterDate : UserControl
    {
        public EnterDate()
        {
            InitializeComponent();
            DataContext = new EnterDateViewModel();
        }
    }
}
