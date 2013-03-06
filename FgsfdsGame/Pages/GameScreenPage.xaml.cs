#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using FgsfdsGame.Model;

#endregion

namespace FgsfdsGame.Pages
{
    /// <summary>
    /// Interaction logic for GameScreenPage.xaml
    /// </summary>
    public partial class GameScreenPage : Page
    {
        public GameScreenPage()
        {
            InitializeComponent();
            GameManager.Instance.Update += new EventHandler(RefreshSource);
        }

        private void RefreshSource(object sender, EventArgs e)
        {
            ((ObjectDataProvider) Resources["ScreenData"]).Refresh();
        }

        private void ChoiceButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            if (button == null) return;
            var choice = (GameChoice) button.DataContext;
            choice.Process();
        }
    }
}