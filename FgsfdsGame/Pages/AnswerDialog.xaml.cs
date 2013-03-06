using System;
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
using System.Windows.Shapes;

namespace FgsfdsGame.Pages
{
    /// <summary>
    /// Interaction logic for AnswerDialog.xaml
    /// </summary>
    public partial class AnswerDialog : Window
    {
        public string Question { get; set; }
        public string RightAnswer { get; set; }
        public AnswerDialog()
        {
            InitializeComponent();
        }

        private void OKButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = AnswerBox.Text == RightAnswer;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
