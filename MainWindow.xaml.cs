using System;
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

namespace CC_KlausurRenamer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtStudFName.Text = Properties.Settings.Default.StudentFName;
            txtStudLName.Text = Properties.Settings.Default.StudentLName;
            datTestDate.Text = System.DateTime.Today.Date.GetDateTimeFormats('d')[1];
        }

        private string computeFileName()
        {
            string fileName = txtCourseNo.Text + "_Doz_" + txtTrainFName.Text + "_" + txtTrainLName.Text + "_TN_" + txtStudFName.Text + "_" + txtStudLName.Text + "_" + datTestDate.Text.Replace(".", string.Empty); ;

            fileName = fileFriendlyFormat(fileName);

            if (!(txtCourseNo.Text.Equals("") || txtTrainFName.Text.Equals("") || txtTrainLName.Text.Equals("") || txtStudFName.Text.Equals("") || txtStudLName.Text.Equals("") || datTestDate.Text.Equals("")))
            {
                btn_Copy.IsEnabled = true;
                txtFileName.IsEnabled = true;
            }

            return fileName;
        }

        private void calcFileName(object sender, TextChangedEventArgs e)
        {
            txtFileName.Text = computeFileName();
        }

        private void btn_Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtFileName.Text);
        }

        private string fileFriendlyFormat(string value)
        {
            string[] source = { "ä", "ö", "ü", "Ä", "Ö", "Ü", "ß", " " };
            string[] target = { "ae", "oe", "ue", "Ae", "Oe", "Ue", "ss", "_" };
            for (int counter = 0; counter <= source.Length - 1; counter++)
            {
                value = value.Replace(source[counter], target[counter]);
            }
            return value;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool IsChanged = false;
            if (!(txtStudFName.Text.Equals(Properties.Settings.Default.StudentFName)))
            {
                Properties.Settings.Default.StudentFName = txtStudFName.Text;
                IsChanged = true;
            }
            if (!(txtStudLName.Text.Equals(Properties.Settings.Default.StudentLName)))
            {
                Properties.Settings.Default.StudentLName = txtStudLName.Text;
                IsChanged |= true;
            }
            if (IsChanged) Properties.Settings.Default.Save();
        }
    }
}