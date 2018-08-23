﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DistributionApp.UserContols
{
    /// <summary>
    /// Interaction logic for ucNumericTextBox.xaml
    /// </summary>
    public partial class ucNumericTextBox : UserControl
    {
        public static DependencyProperty TxtBoxValueProperty = DependencyProperty.Register("TxtBoxValue", typeof(string), typeof(ucNumericTextBox));

        public string TxtBoxValue
        {
            get { return (string)GetValue(TxtBoxValueProperty); }
            set { SetValue(TxtBoxValueProperty, value);  }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == TxtBoxValueProperty)
            {
                // Do whatever you want with it
                textbox.Text = TxtBoxValue;
            }
        }

        public ucNumericTextBox()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
