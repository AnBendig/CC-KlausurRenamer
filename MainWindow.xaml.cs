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

            datTestDate.Text = System.DateTime.Today.Date.GetDateTimeFormats('d')[1];
        }

        private string computeFileName()
        {
            string fileName = txtCourseNo.Text + "_Doz_" + txtTrainFName.Text + "_" + txtTrainLName.Text + "_TN_" + txtStudFName.Text + "_" + txtStudLName.Text + "_" + datTestDate.Text.Replace(".", string.Empty); ;

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
            string[] source = { "ä", "ö", "ü" };
            string[] target = { "ae", "oe", "ue" };
            for (int counter = 0; counter <= source.Length; counter++)
            {
                value = value.Replace(source[counter], target[counter]);
            }
            return value;
        }
    }
}