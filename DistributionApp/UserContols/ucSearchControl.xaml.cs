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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DistributionApp.UserContols
{
    /// <summary>
    /// Interaction logic for ucSearchControl.xaml
    /// </summary>
    public partial class ucSearchControl : UserControl
    {
        #region [dependency property]

        public string Field1TextBlock
        {
            get { return (string)GetValue(Field1TextBlockProperty); }
            set { SetValue(Field1TextBlockProperty, value); }
        }

        public static readonly DependencyProperty Field1TextBlockProperty =
            DependencyProperty.Register("Field1TextBlock", typeof(string),
              typeof(ucSearchControl), new PropertyMetadata(string.Empty));

        public string Field2TextBlock
        {
            get { return (string)GetValue(Field2TextBlockProperty); }
            set { SetValue(Field2TextBlockProperty, value); }
        }

        public static readonly DependencyProperty Field2TextBlockProperty =
            DependencyProperty.Register("Field2TextBlock", typeof(string),
              typeof(ucSearchControl), new PropertyMetadata(string.Empty));

        public string Field3TextBlock
        {
            get { return (string)GetValue(Field3TextBlockProperty); }
            set { SetValue(Field3TextBlockProperty, value); }
        }

        public static readonly DependencyProperty Field3TextBlockProperty =
            DependencyProperty.Register("Field3TextBlock", typeof(string),
              typeof(ucSearchControl), new PropertyMetadata(string.Empty));

        public string Field4TextBlock
        {
            get { return (string)GetValue(Field4TextBlockProperty); }
            set { SetValue(Field4TextBlockProperty, value); }
        }

        public static readonly DependencyProperty Field4TextBlockProperty =
            DependencyProperty.Register("Field4TextBlock", typeof(string),
              typeof(ucSearchControl), new PropertyMetadata(string.Empty));

        public string Field5TextBlock
        {
            get { return (string)GetValue(Field5TextBlockProperty); }
            set { SetValue(Field5TextBlockProperty, value); }
        }

        public static readonly DependencyProperty Field5TextBlockProperty =
            DependencyProperty.Register("Field5TextBlock", typeof(string),
              typeof(ucSearchControl), new PropertyMetadata(string.Empty));


        public string Field1TextBox
        {
            get { return (string)GetValue(Field1TextBoxProperty); }
            set { SetValue(Field1TextBoxProperty, value); }
        }

        public static readonly DependencyProperty Field1TextBoxProperty =
            DependencyProperty.Register("Field1TextBox", typeof(string), typeof(ucSearchControl),
                new PropertyMetadata(string.Empty));

        public string Field2TextBox
        {
            get { return (string)GetValue(Field2TextBoxProperty); }
            set { SetValue(Field2TextBoxProperty, value); }
        }

        public static readonly DependencyProperty Field2TextBoxProperty =
            DependencyProperty.Register("Field2TextBox", typeof(string), typeof(ucSearchControl),
                new PropertyMetadata(string.Empty));

        public string Field3TextBox
        {
            get { return (string)GetValue(Field3TextBoxProperty); }
            set { SetValue(Field3TextBoxProperty, value); }
        }

        public static readonly DependencyProperty Field3TextBoxProperty =
            DependencyProperty.Register("Field3TextBox", typeof(string), typeof(ucSearchControl),
                new PropertyMetadata(string.Empty));

        public string Field4TextBox
        {
            get { return (string)GetValue(Field4TextBoxProperty); }
            set { SetValue(Field4TextBoxProperty, value); }
        }

        public static readonly DependencyProperty Field4TextBoxProperty =
            DependencyProperty.Register("Field4TextBox", typeof(string), typeof(ucSearchControl),
                new PropertyMetadata(string.Empty));

        public string Field5TextBox
        {
            get { return (string)GetValue(Field5TextBoxProperty); }
            set { SetValue(Field5TextBoxProperty, value); }
        }

        public static readonly DependencyProperty Field5TextBoxProperty =
            DependencyProperty.Register("Field5TextBox", typeof(string), typeof(ucSearchControl),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SearchCommandProperty =
                DependencyProperty.Register("SearchCommand", typeof(ICommand), typeof(ucSearchControl));

        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }


        #endregion

        public ucSearchControl()
        {
            InitializeComponent();
        }
    }
}
