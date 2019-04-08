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

namespace _01.Basics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string APPLIED = "Settings applied!";
        private static readonly string APPLIED_STATUS = "{0}: Applied";
        private static readonly string CLEAR_FIELDS_STATUS = "Fields clear!";
        private static readonly string REFRESH_STATUS = "Refreshed!";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(APPLIED);
            PrintStatus(string.Format(APPLIED_STATUS, DescriptionText.Text));
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetControls(FieldPanel.Children);
            PrintStatus(CLEAR_FIELDS_STATUS);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            PrintStatus(REFRESH_STATUS);
        }

        private void ResetControls(UIElementCollection elements)
        {
            foreach(object ctl in elements)
            {
                if (ctl.GetType().IsSubclassOf(typeof(Panel)))
                    ResetControls(((Panel)ctl).Children);

                if (ctl.GetType() == typeof(CheckBox))
                    ((CheckBox)ctl).IsChecked = false;
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = "";
            }
        }

        private void PrintStatus(string status)
        {
            StatusText.Text = status;
        }
    }
}
