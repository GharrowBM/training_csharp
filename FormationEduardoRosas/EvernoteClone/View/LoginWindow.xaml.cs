﻿using EvernoteClone.ViewModel;
using System;
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

namespace EvernoteClone.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginVM vm;
        public LoginWindow()
        {
            InitializeComponent();

            vm = Resources["vm"] as LoginVM;
            vm.Authenticated += Vm_Authenticated;
        }

        private void Vm_Authenticated(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
