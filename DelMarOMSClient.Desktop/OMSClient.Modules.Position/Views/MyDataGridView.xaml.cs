﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OMSClient.Modules.Position.Views
{
    /// <summary>
    /// Interaction logic for MyDataGridView.xaml
    /// </summary>
    public partial class MyDataGridView : UserControl
    {
        public MyDataGridView()
        {
            InitializeComponent();            
        }

        public MyDataGridViewModel ViewModel 
        {
            set 
            {
                DataContext = value;
            }
        }
    }
}
