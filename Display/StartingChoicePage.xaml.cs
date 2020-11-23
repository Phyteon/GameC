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

namespace Game.Display
{
    /// <summary>
    /// Choose starting class, item and skill
    /// </summary>
    public partial class StartingChoicePage : Page
    {
        private MainWindow frameRef;
        private MenuPage parentPage;
        public StartingChoicePage(MainWindow frame, MenuPage parent)
        {
            InitializeComponent();
            frameRef = frame;
            parentPage = parent;
        }
        private void PressedOK(object sender, RoutedEventArgs e)
        {
            if (ChoiceListBox.SelectedItem == null) return;
            parentPage.StartGameRun(ChoiceListBox.SelectedItem.ToString());
        }
    }
}
